import sys, os, logging
import urllib
import json
from pprint import pprint
from datetime import datetime, timedelta
from types import SimpleNamespace
from dotenv import load_dotenv
from sqlalchemy import create_engine
from sqlalchemy.orm import sessionmaker
from domain.entities import Platform, Sport, Team, Competition, Event, Bet, Outcome
from domain.services import PlatformService, SportService, TeamService, CompetitionService, EventService, BetService, OutcomeService
from service.FdjService import FdjService

logging.basicConfig(
    format='%(asctime)s %(levelname)-8s %(message)s',
    level=logging.DEBUG,
    datefmt='%Y-%m-%d %H:%M:%S')

logging.info("Lauching Connector FDJ")

# Configuration
load_dotenv();

logging.debug("Using following configuration")
logging.debug("DB_CONNECTIONSTRING: %s", os.getenv('DB_CONNECTIONSTRING'))

sqlengine = create_engine(os.getenv('DB_CONNECTIONSTRING'), echo=False)
Session = sessionmaker(bind=sqlengine)
session = Session()
logging.debug("Connected to database")

# Retrieve Platform
platform = PlatformService.getPlatformByCode(session, 'FDJ')
logging.debug("Retrieved platform from database")

# Getting sports
sports = SportService.getSportsByPlatform(session, platform.Id)
logging.info("Retrieved %d sports", len(sports))

for sport in sports:
    logging.debug("Processing %s", sport.Name)
    # Preparing stats
    createdOutcomes = 0
    updatedOutcomes = 0
    createdBets = 0

    # Getting all offers for sport
    offres = FdjService.getOffre(sport.Platform_Id)
    logging.debug("Retrieved %d events for %s", len(offres), sport.Name)

    for offre in offres:
        # Offres 
        logging.debug("Processing event %s:%s", offre.competition, offre.label)
        
        bet = BetService.getBetByPlatformAndPlatform_Id(session, platform.Id, offre.marketId)
        if (bet == None):
            logging.debug("Event for platform not found.")

            # Should we process it ?
            if (offre.competition == 'Cotes Boostées'):
                print('Skipping event')
                continue

            # Starting from the top.
            # Competition.
            competition = CompetitionService.getCompetitionByPlatformAndPlatform_Id(session, platform.Id, offre.competitionId)

            if (competition == None):
                logging.debug("Creating competition %s", offre.competition)
                new_competition = Competition(Name=offre.competition, UnifiedType='Platform', PlatformId=platform.Id, Platform_Id=offre.competitionId)
                competition = CompetitionService.create(session, new_competition)

            # Event
            event = EventService.getEventByPlatformAndPlatform_Id(session, platform.Id, offre.eventId)

            if (event == None):
                logging.debug("Creating event %s", offre.label)
                new_event = Event(Name=offre.label, EventType='Match', CompetitionId=competition.Id, Url=offre.urlStats, CreatedAt=datetime.now(), UpdatedAt=datetime.now(), UnifiedType='Platform', PlatformId=platform.Id, Platform_Id=offre.eventId)
                event = EventService.create(session, new_event)

                # Teams
                # TODO: Split le nom de l'event par le tiret '-' pour les equipes (ent tout cas pour le football ...)
                offre_teams = offre.label.split('-')
                teams = []
                for offre_team in offre_teams:
                    team = TeamService.getTeamByPlatformAndPlatform_Id(session, platform.Id, offre_team)

                    if (team == None):

                        logging.debug("Creating team %s", offre_team)
                        new_team = Team(Name=offre_team, TeamType='Team', SportId=sport.Id, UnifiedType='Platform', PlatformId=platform.Id, Platform_Id=offre_team)
                        team = TeamService.create(session, new_team)

                    teams.append(team)

                # Linking Teams with Event
                event.participants = teams

            # And now we have created all the upper part of the bet.
            # We can now go on to analyse the available markets
            # Bets
            new_bet_bettype = None
            if (offre.marketTypeGroup == '1/N/2'):
                if (offre.marketTypeGroup == '1/N/2'):
                    new_bet_bettype = 'Win_Draw_Lose'
                else:
                    logging.error('Found offre.marketTypeGroup = %s, offre.marketType = %s', offre.marketTypeGroup, offre.marketType)
                    continue
            elif (offre.marketTypeGroup == 'Handicap'):
                if (offre.marketType == 'Handicap [0:1] (Temps Réglementaire)'):
                    new_bet_bettype = 'Handicap_0_1'
                elif (offre.marketType == 'Handicap [0:17] (Temps Réglementaire)'):
                    new_bet_bettype = 'Handicap_0_17'
                elif (offre.marketType == 'Handicap [0:20] (Temps Réglementaire)'):
                    new_bet_bettype = 'Handicap_0_20'
                elif (offre.marketType == 'Handicap [0:15] (Temps Réglementaire)'):
                    new_bet_bettype = 'Handicap_0_15'
                else:
                    logging.error('Found offre.marketTypeGroup = %s, offre.marketType = %s', offre.marketTypeGroup, offre.marketType)
                    continue
            elif (offre.marketTypeGroup == 'MT/FM'):
                if (offre.marketType == 'MT/FM (Temps Réglementaire)'):
                    new_bet_bettype = 'MiTemps_FinMatch'
                else:
                    logging.error('Found offre.marketTypeGroup = %s, offre.marketType = %s', offre.marketTypeGroup, offre.marketType)
                    continue
            elif (offre.marketTypeGroup == 'Plus/Moins'):
                if (offre.marketType == 'Plus/Moins 54,5 buts (Temps Réglementaire)'):
                    logging.error('Found offre.marketTypeGroup = %s, offre.marketType = %s', offre.marketTypeGroup, offre.marketType)
                elif (offre.marketType == 'Plus/Moins 57,5 buts (Temps Réglementaire)'):
                    logging.error('Found offre.marketTypeGroup = %s, offre.marketType = %s', offre.marketTypeGroup, offre.marketType)
                else:
                    logging.error('Found offre.marketTypeGroup = %s, offre.marketType = %s', offre.marketTypeGroup, offre.marketType)
                continue
            elif (offre.marketTypeGroup == 'Paris Spéciaux'):
                if (offre.marketType == 'Nombre de sets dans le match'):
                    logging.error('Found offre.marketTypeGroup = %s, offre.marketType = %s', offre.marketTypeGroup, offre.marketType)
                elif (offre.marketType == 'Bonus[+15%]'):
                    logging.error('Found offre.marketTypeGroup = %s, offre.marketType = %s', offre.marketTypeGroup, offre.marketType)
                elif (offre.marketType == 'Vainqueur'):
                    logging.error('Found offre.marketTypeGroup = %s, offre.marketType = %s', offre.marketTypeGroup, offre.marketType)
                elif (offre.marketType == 'Un match se finira-t-il sur un 0-0 ?'):
                    logging.error('Found offre.marketTypeGroup = %s, offre.marketType = %s', offre.marketTypeGroup, offre.marketType)
                else:
                    # Cas des vainqueurs individuels.
                    logging.error('Found offre.marketTypeGroup = %s, offre.marketType = %s', offre.marketTypeGroup, offre.marketType)
                continue
            elif (offre.marketTypeGroup == 'Résultat & les 2 marquent'):
                    if (offre.marketType == 'Résultat & les 2 marquent'):
                        logging.error('Found offre.marketTypeGroup = %s, offre.marketType = %s', offre.marketTypeGroup, offre.marketType)
                    else:
                        # Cas des vainqueurs individuels.
                        logging.error('Found offre.marketTypeGroup = %s, offre.marketType = %s', offre.marketTypeGroup, offre.marketType)
                    continue
            else:
                raise Exception('marketTypeGroup: {0}, marketType: {1} not recognized'.format(offre.marketTypeGroup, offre.marketType))

            # 300 sec = 5 min.
            logging.debug("Creating bet %s", new_bet_bettype)
            new_bet = Bet(Name=new_bet_bettype, EventId=event.Id, BetType=new_bet_bettype, CreatedAt=datetime.now(), UpdatedAt=datetime.now(), ExpiresAt=datetime.now()+timedelta(0, 300), UnifiedType='Platform', PlatformId=platform.Id, Platform_Id=offre.marketId)
            bet = BetService.create(session, new_bet)
            createdBets += 1
            
            # Commit to generate Ids and link everything together.
            session.commit()

        # Outcomes
        outcomes = OutcomeService.getOutcomesByBet(session, bet.Id)
        for offre_outcome in offre.outcomes:

            # Analyse of outcome type, and team eventually.
            current_outcome_outcometype = None
            if (offre_outcome.label == "1"):
                current_outcome_outcometype = 'Team_1_Win'
            elif (offre_outcome.label == "2"):
                current_outcome_outcometype = 'Team_2_Win'
            elif (offre_outcome.label == "N"):
                current_outcome_outcometype = 'Team_Draw'
            elif (offre_outcome.label == '1/1'):
                current_outcome_outcometype = '1_1'
            else:
                raise Exception('outcomeType not found')

            remote_outcome = list(filter(lambda x: (x.OutcomeType == current_outcome_outcometype), outcomes))

            if (len(remote_outcome) == 1):
                # Updating odd
                logging.debug("Updating outcome %s: %s -> %s", current_outcome_outcometype, remote_outcome[0].Odd, offre_outcome.cote.replace(',', '.'))
                remote_outcome[0].Odd = offre_outcome.cote.replace(',', '.')
                updatedOutcomes += 1

            else:
                # Creating Outcome.
                logging.debug("Creating outcome %s: %s", current_outcome_outcometype, offre_outcome.cote.replace(',', '.'))
                new_outcome = Outcome(Odd=offre_outcome.cote.replace(',', '.'), OutcomeType=current_outcome_outcometype, BetId=bet.Id, TeamId=None)
                outcome = OutcomeService.create(session, new_outcome)
                createdOutcomes += 1

        # Set event updated
        event.UpdatedAt = datetime.now()
        # 5 Mins
        event.ExpiresAt = datetime.now() + timedelta(0, 300)
        
        # Push outcomes updated / or created.
        session.commit()

    logging.error('Created %d bets, Created %d outcomes, Updated %d outcomes', createdBets, createdOutcomes, updatedOutcomes)

session.close()
logging.info('Done')