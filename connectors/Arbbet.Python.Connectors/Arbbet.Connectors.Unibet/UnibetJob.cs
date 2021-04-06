﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arbbet.Connectors.Dal;
using Arbbet.Connectors.Dal.Services;
using Arbbet.Connectors.Unibet.Configuration;
using Arbbet.Connectors.Unibet.Models;
using Arbbet.Connectors.Unibet.Services;
using Arbbet.Domain.Entities;
using Arbbet.Domain.Enums;

using Microsoft.Extensions.Logging;

using ShellProgressBar;

namespace Arbbet.Connectors.Unibet
{
  public class UnibetJob
  {
    private static string jobName = "UnibetJob";
    private static string platformCode = "UNI";

    private readonly ILogger<UnibetJob> _logger;
    private readonly ConnectorDbContext _context;
    private readonly UnibetService _service;

    private readonly EventService _eventService;
    private readonly SportService _sportService;
    private readonly CompetitionService _competitionService;
    private readonly CountryService _countryService;
    private readonly TeamService _teamService;
    private readonly BetService _betService;
    private readonly OutcomeService _outcomeService;

    private Platform _platform;

    public UnibetJob(ILogger<UnibetJob> logger,
      ConnectorDbContext context,
      UnibetService unibetService,
      EventService eventService,
      SportService sportService,
      CompetitionService competitionService,
      CountryService countryService,
      TeamService teamService,
      BetService betService,
      OutcomeService outcomeService)
    {
      _logger = logger;
      _context = context;
      _service = unibetService;
      _eventService = eventService;
      _sportService = sportService;
      _competitionService = competitionService;
      _countryService = countryService;
      _teamService = teamService;
      _betService = betService;
      _outcomeService = outcomeService;
    }

    public async Task<bool> Run()
    {
      try
      {

        var options = new ProgressBarOptions()
        {
          ShowEstimatedDuration = true,
          ProgressCharacter = '_'
        };

        using (var pbar = new ProgressBar(5, "Initial message", options))
        {
          pbar.Tick(); //will advance pbar to 1 out of 10.
                       //we can also advance and update the progressbar text
          pbar.Tick("Step 2 of 10");
        }

        _logger.Log(LogLevel.Information, "{0} starting", jobName) ;

        _platform = _context.Platforms.FirstOrDefault(eml => eml.Code == UnibetJob.platformCode);
        _logger.Log(LogLevel.Debug, "Platform {0} found", _platform.Name);

        var sports = await _service.GetSportsAsync();
        _logger.Log(LogLevel.Debug, "Retrieved {0} sports", sports.Count());

        foreach (PlatformSport sport in sports)
        {
          _logger.Log(LogLevel.Debug, "Processing {0}", sport.Name);

          if (sport.Name == "Football")
          {
            var markets = await _service.GetMarketsAsync(sport.Id);
            _logger.Log(LogLevel.Debug, "Retrieved {0} markets for {1}", markets.Count(), sport.Name);

            foreach (PlatformMarket market in markets)
            {
              if (MarketConfiguration.IncludedEntries.Contains(market))
              {
                _logger.Log(LogLevel.Debug, "Processing market {0} for {1}", market.Name, sport.Name);
                
                var events = await _service.GetEventsAsync(sport.Id, market.Type, market.Name);
                _logger.Log(LogLevel.Debug, "Retrieved {0} events for market {1}", events.Count(), market.Name);

                foreach (PlatformEvent platformEvent in events)
                {
                  _logger.Log(LogLevel.Debug, "Processing event {0} for {1}", platformEvent.Name, platformEvent.CompetitionName);

                  // Trying to get event for platform if exists
                  Event eventEntity = await _eventService.GetAsync(_platform.Id, platformEvent.Id);
                  if (eventEntity == null)
                  {
                    // Retrieve sport
                    Sport sportEntity = await _sportService.GetAsync(_platform.Id, sport.Id.ToString()); 

                    if (sportEntity == null)
                    {
                      sportEntity = _sportService.Create(_platform.Id, new Sport()
                      {
                        Code = sport.Name.ToUpperInvariant().Substring(0, Math.Min(sport.Name.Length, 3)),
                        Name = sport.Name,
                        Platform_Id = sport.Id.ToString(),
                        UnifiedEntityId = null,
                        UnifiedType = UnifiedType.Platform
                      });
                    }

                    // Retrieve competition + (country if defined)
                    Competition competitionEntity = await _competitionService.GetAsync(_platform.Id, platformEvent.CompetitionId);

                    if (competitionEntity == null)
                    {
                      Country countryEntity = null;
                      if (!string.IsNullOrEmpty(platformEvent.CompetitionCountryName))
                      {
                        countryEntity = _countryService.FirstOrDefault(elm => elm.Name == platformEvent.CompetitionCountryName);

                        if (countryEntity == null)
                        {
                          countryEntity = _countryService.Create(new Country()
                          {
                            Code = platformEvent.CompetitionCountryName.ToUpperInvariant().Substring(0, Math.Min(platformEvent.CompetitionCountryName.Length, 3)),
                            Name = platformEvent.Name
                          });
                        }
                      }

                      competitionEntity = _competitionService.Create(_platform.Id, new Competition
                      {
                        Name = platformEvent.CompetitionName,
                        CountryId = countryEntity?.Id,
                        Country = countryEntity,
                        Platform_Id = platformEvent.CompetitionId,
                        SportId = sportEntity.Id,
                        UnifiedEntityId = null,
                        UnifiedType = UnifiedType.Platform
                      });;
                    }

                    // Retrieve teams
                    IList<Team> participants = new List<Team>();
                    Team teamAwayEntity = _teamService.FirstOrDefault(elm => elm.Name == platformEvent.AwayTeam);

                    if (teamAwayEntity == null)
                    {
                      // FIXME: Un raccourci est prit: Pays de l'équipe = pays de la compétition.
                      teamAwayEntity = _teamService.Create(new Team()
                      {
                        CountryId = competitionEntity.CountryId,
                        Country = competitionEntity.Country,
                        Name = platformEvent.AwayTeam,
                        Platform_Id = null,
                        Sport = sportEntity,
                        SportId = sportEntity.Id,
                        TeamType = TeamType.Team, // Dans le cas du football.
                        UnifiedEntityId = null,
                        UnifiedType = UnifiedType.Platform
                      });
                    }
                    participants.Add(teamAwayEntity);

                    Team teamHomeEntity = _teamService.FirstOrDefault(elm => elm.Name == platformEvent.HomeTeam);

                    if (teamHomeEntity == null)
                    {
                      // FIXME: Un raccourci est prit: Pays de l'équipe = pays de la compétition.
                      teamHomeEntity = _teamService.Create(new Team()
                      {
                        CountryId = competitionEntity.CountryId,
                        Country = competitionEntity.Country,
                        Name = platformEvent.HomeTeam,
                        Platform_Id = null,
                        Sport = sportEntity,
                        SportId = sportEntity.Id,
                        TeamType = TeamType.Team, // Dans le cas du football.
                        UnifiedEntityId = null,
                        UnifiedType = UnifiedType.Platform
                      });
                    }
                    participants.Add(teamHomeEntity);

                    // Create Event
                    eventEntity = _eventService.Create(_platform.Id, new Event()
                    {
                      CompetitionId = competitionEntity.Id,
                      Competition = competitionEntity,
                      EventType = EventType.Match, // Dans le cas du football.
                      CreatedAt = DateTime.Now,
                      Name = platformEvent.Name,
                      Participants = participants,
                      Platform_Id = platformEvent.Id,
                      StartDate = platformEvent.StartDate,
                      UnifiedEntity = null,
                      UnifiedEntityId = null,
                      UnifiedType = UnifiedType.Platform,
                      UpdatedAt = DateTime.Now,
                      Url = platformEvent.Url
                    });
                  }

                  foreach (PlatformBet platformBet in platformEvent.Bets)
                  {
                    _logger.Log(LogLevel.Debug, "Processing bet {0}", platformBet.Type);

                    // Retrieve or create bets
                    BetType currentBetType = BetType.Win_Draw_Lose; // Dans le cas du football.
                    Bet betEntity = _betService.GetBetForEvent(eventEntity.Id, currentBetType);

                    if (betEntity == null)
                    {
                      betEntity = _betService.Create(_platform.Id, new Bet()
                      {
                        BetType = currentBetType,
                        CreatedAt = DateTime.Now,
                        EventId = eventEntity.Id,
                        Event = eventEntity,
                        UpdatedAt = DateTime.Now,
                        ExpiresAt = DateTime.Now.AddMinutes(5),
                        Name = currentBetType.ToString(),
                        Platform_Id = platformBet.Id,
                        UnifiedEntity = null,
                        UnifiedEntityId = null,
                        UnifiedType = UnifiedType.Platform,
                      });
                    }

                    IEnumerable<Outcome> outcomesEntities = _outcomeService.GetOutcomesForBet(betEntity.Id);
                    foreach (PlatformOutcome platformOutcome in platformBet.Outcomes)
                    {
                      if (outcomesEntities != null)
                      {
                        Outcome outcomeEntity = null;
                        if (!string.IsNullOrEmpty(platformOutcome.TeamName))
                        {
                          outcomeEntity = outcomesEntities.FirstOrDefault(elm => elm.OutcomeType == platformOutcome.Type && elm.Team?.Name == platformOutcome.TeamName);
                        }
                        else
                        {
                          outcomeEntity = outcomesEntities.FirstOrDefault(elm => elm.OutcomeType == platformOutcome.Type);
                        }


                        if (outcomeEntity == null)
                        {
                          Team team = _teamService.FirstOrDefault(elm => elm.Name == platformOutcome.TeamName);
                          outcomeEntity = _outcomeService.Create(new Outcome()
                          {
                            Bet = betEntity,
                            BetId = betEntity.Id,
                            Odd = platformOutcome.Odd,
                            OutcomeType = platformOutcome.Type,
                            TeamId = team?.Id,
                            Team = team,
                          });
                          _outcomeService.Create(outcomeEntity);
                        }
                        else
                        {
                          outcomeEntity.Odd = platformOutcome.Odd;
                          _outcomeService.Update(outcomeEntity);
                        }
                      }
                    }

                    await _outcomeService.CommitAsync();
                    _logger.Log(LogLevel.Debug, "Finished processing bet {0}", platformBet.Type);
                  }

                  _logger.Log(LogLevel.Debug, "Finished processing event {0}", platformEvent.Name);
                }
              }

              _logger.Log(LogLevel.Debug, "Finished processing market {0}", market.Name);
            }
          }

          _logger.Log(LogLevel.Debug, "Finished processing sport {0}", sport.Name);
        }

        _logger.Log(LogLevel.Information, "{0} stopping", jobName);
        return true;
      }
      catch (Exception ex)
      {
        _logger.Log(LogLevel.Critical, ex, "{0} exception", jobName);
        return false;
      }
      finally
      {
      }
    }
  }
}