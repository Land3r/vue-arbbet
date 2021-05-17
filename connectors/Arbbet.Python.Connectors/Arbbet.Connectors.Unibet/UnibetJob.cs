
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Arbbet.Connectors.Dal;
using Arbbet.Connectors.Dal.Services;
using Arbbet.Connectors.Domain.Performances;
using Arbbet.Connectors.Domain.Progression;
using Arbbet.Connectors.Domain.Statistics;
using Arbbet.Connectors.Unibet.Configuration;
using Arbbet.Connectors.Unibet.Models;
using Arbbet.Connectors.Unibet.Services;
using Arbbet.Domain.Entities;
using Arbbet.Domain.Enums;
using Arbbet.Domain.ViewModels;
using Microsoft.Extensions.Logging;

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
        private readonly PerformanceStatService _performanceStatService;
        private readonly StatisticService _statisticService;

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
          OutcomeService outcomeService,
          PerformanceStatService performanceStatService,
          StatisticService statisticService)
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
            _performanceStatService = performanceStatService;
            _statisticService = statisticService;
        }

        public async Task<bool> Run()
        {
            try
            {
                _logger.Log(LogLevel.Information, "{0} starting", jobName);

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
                                    EventDto eventEntity = await _eventService.GetAsync(_platform.Id, platformEvent.Id);
                                    if (eventEntity == null)
                                    {
                                        // Retrieve sport
                                        SportDto sportEntity = await _sportService.GetAsync(_platform.Id, sport.Id.ToString());

                                        if (sportEntity == null)
                                        {
                                            sportEntity = _sportService.Create(_platform.Id, new SportDto()
                                            {
                                                Id = Guid.NewGuid(),
                                                Code = sport.Name.ToUpperInvariant().Substring(0, Math.Min(sport.Name.Length, 3)),
                                                Name = sport.Name,
                                                Platform_Id = sport.Id.ToString(),
                                                UnifiedEntityId = null,
                                                UnifiedType = UnifiedType.Platform
                                            });
                                            _statisticService.Add(StatisticEvent.Create, typeof(Sport));
                                        }

                                        // Retrieve competition + (country if defined)
                                        CompetitionDto competitionEntity = await _competitionService.GetAsync(_platform.Id, platformEvent.CompetitionId);

                                        if (competitionEntity == null)
                                        {
                                            CountryDto countryEntity = null;
                                            if (!string.IsNullOrEmpty(platformEvent.CompetitionCountryName))
                                            {
                                                countryEntity = _countryService.FirstOrDefault(elm => elm.Name == platformEvent.CompetitionCountryName);

                                                if (countryEntity == null)
                                                {
                                                    countryEntity = _countryService.Create(new CountryDto()
                                                    {
                                                        Id = Guid.NewGuid(),
                                                        Code = platformEvent.CompetitionCountryName.ToUpperInvariant().Substring(0, Math.Min(platformEvent.CompetitionCountryName.Length, 3)),
                                                        Name = platformEvent.CompetitionCountryName
                                                    });
                                                    _statisticService.Add(StatisticEvent.Create, typeof(Country));
                                                }
                                            }

                                            competitionEntity = _competitionService.Create(_platform.Id, new CompetitionDto
                                            {
                                                Id = Guid.NewGuid(),
                                                Name = platformEvent.CompetitionName,
                                                CountryId = countryEntity?.Id,
                                                Platform_Id = platformEvent.CompetitionId,
                                                SportId = sportEntity.Id,
                                                UnifiedEntityId = null,
                                                UnifiedType = UnifiedType.Platform
                                            });
                                            _statisticService.Add(StatisticEvent.Create, typeof(Competition));
                                        }

                                        // Retrieve teams
                                        IList<TeamDto> participants = new List<TeamDto>();
                                        TeamDto teamAwayEntity = _teamService.FirstOrDefault(elm => elm.Name == platformEvent.AwayTeam);

                                        if (teamAwayEntity == null)
                                        {
                                            // FIXME: Un raccourci est prit: Pays de l'équipe = pays de la compétition.
                                            teamAwayEntity = _teamService.Create(new TeamDto()
                                            {
                                                Id = Guid.NewGuid(),
                                                CountryId = competitionEntity.CountryId,
                                                Name = platformEvent.AwayTeam,
                                                Platform_Id = null,
                                                SportId = sportEntity.Id,
                                                TeamType = TeamType.Team, // Dans le cas du football.
                                                UnifiedEntityId = null,
                                                UnifiedType = UnifiedType.Platform
                                            });
                                            await _teamService.CommitAsync();

                                            _statisticService.Add(StatisticEvent.Create, typeof(Team));
                                        }
                                        participants.Add(teamAwayEntity);

                                        TeamDto teamHomeEntity = _teamService.FirstOrDefault(elm => elm.Name == platformEvent.HomeTeam);

                                        if (teamHomeEntity == null)
                                        {
                                            // FIXME: Un raccourci est prit: Pays de l'équipe = pays de la compétition.
                                            teamHomeEntity = _teamService.Create(new TeamDto()
                                            {
                                                Id = Guid.NewGuid(),
                                                CountryId = competitionEntity.CountryId,
                                                Name = platformEvent.HomeTeam,
                                                Platform_Id = null,
                                                SportId = sportEntity.Id,
                                                TeamType = TeamType.Team, // Dans le cas du football.
                                                UnifiedEntityId = null,
                                                UnifiedType = UnifiedType.Platform
                                            });
                                            await _teamService.CommitAsync();

                                            _statisticService.Add(StatisticEvent.Create, typeof(Team));
                                        }
                                        participants.Add(teamHomeEntity);

                                        // Create Event
                                        eventEntity = _eventService.Create(_platform.Id, new EventDto()
                                        {
                                            Id = Guid.NewGuid(),
                                            CompetitionId = competitionEntity.Id,
                                            EventType = EventType.Match, // Dans le cas du football.
                                            CreatedAt = DateTime.Now,
                                            Name = platformEvent.Name,
                                            Participants = participants,
                                            Platform_Id = platformEvent.Id,
                                            StartDate = platformEvent.StartDate,
                                            UnifiedEntityId = null,
                                            UnifiedType = UnifiedType.Platform,
                                            UpdatedAt = DateTime.Now,
                                            Url = platformEvent.Url
                                        });
                                        _statisticService.Add(StatisticEvent.Create, typeof(Event));
                                    }

                                    foreach (PlatformBet platformBet in platformEvent.Bets)
                                    {
                                        _logger.Log(LogLevel.Debug, "Processing bet {0}", platformBet.Type);

                                        // Retrieve or create bets
                                        BetType currentBetType = BetType.Win_Draw_Lose; // Dans le cas du football.
                                        BetDto betEntity = _betService.GetBetForEvent(eventEntity.Id, currentBetType);

                                        if (betEntity == null)
                                        {
                                            betEntity = _betService.Create(_platform.Id, new BetDto()
                                            {
                                                Id = Guid.NewGuid(),
                                                BetType = currentBetType,
                                                CreatedAt = DateTime.Now,
                                                EventId = eventEntity.Id,
                                                UpdatedAt = DateTime.Now,
                                                ExpiresAt = DateTime.Now.AddMinutes(5),
                                                Name = currentBetType.ToString(),
                                                Platform_Id = platformBet.Id,
                                                UnifiedEntityId = null,
                                                UnifiedType = UnifiedType.Platform,
                                            });
                                            _statisticService.Add(StatisticEvent.Create, typeof(Bet));
                                        }

                                        IEnumerable<OutcomeDto> outcomesEntities = _outcomeService.GetOutcomesForBet(betEntity.Id);
                                        foreach (PlatformOutcome platformOutcome in platformBet.Outcomes)
                                        {
                                            if (outcomesEntities != null)
                                            {
                                                OutcomeDto outcomeEntity = null;
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
                                                    TeamDto team = _teamService.FirstOrDefault(elm => elm.Name == platformOutcome.TeamName);
                                                    outcomeEntity = _outcomeService.Create(new OutcomeDto()
                                                    {
                                                        Id = Guid.NewGuid(),
                                                        BetId = betEntity.Id,
                                                        Odd = platformOutcome.Odd,
                                                        OutcomeType = platformOutcome.Type,
                                                        TeamId = team?.Id
                                                    });
                                                    _statisticService.Add(StatisticEvent.Create, typeof(Outcome));
                                                }
                                                else
                                                {
                                                    outcomeEntity.Odd = platformOutcome.Odd;
                                                    _outcomeService.Update(outcomeEntity);
                                                    _statisticService.Add(StatisticEvent.Update, typeof(Outcome));
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
                IList<PerformanceStat> stats = _performanceStatService.Aggregate().ToList();
                _logger.Log(LogLevel.Information, _statisticService.GetStatisticsString());
                foreach (PerformanceStat stat in stats)
                {
                    _logger.Log(LogLevel.Information, "{0} in total for {1}", TimeSpan.FromMilliseconds(stat.TimeElapsed), stat.Type);
                }
            }
        }
    }
}
