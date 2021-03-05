import sys, os, logging
import urllib
import json
from pprint import pprint
from types import SimpleNamespace
from dotenv import load_dotenv
from sqlalchemy import create_engine
from sqlalchemy.orm import sessionmaker
from domain.entities import Platform, Sport, Competition, Bet
from domain.services import PlatformService, SportService, CompetitionService, BetService
from service.FdjService import FdjService

logging.basicConfig(
    format='%(asctime)s %(levelname)-8s %(message)s',
    level=logging.INFO,
    datefmt='%Y-%m-%d %H:%M:%S')

logging.info("Lauching Connector FDJ")

# Configuration
load_dotenv();

logging.debug("Using following configuration")
logging.debug("DB_CONNECTIONSTRING: %s", os.getenv('DB_CONNECTIONSTRING'))

sqlengine = create_engine(os.getenv('DB_CONNECTIONSTRING'), echo=True)
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
    # Getting all offers for sport
    offres = FdjService.getOffre(sport.Platform_Id)
    logging.debug("Retrieved %d events for %s", len(offres), sport.Name)

    for offre in offres:
        # Offres 
        logging.debug("Processing event %s:%s", offre.competition, offre.label)
        
        bet = BetService.getBetByPlatformAndPlatform_Id(session, platform.Id, offre.marketId)
        if (bet == None):
            logging.debug("Event for platform not found.")

            # Starting from the top.
            competition = CompetitionService.getCompetitionByPlatformAndPlatform_Id(session, platform.Id, offre.competitionId)

            if (competition == None):
                logging.debug("Creating competition %s", offre.competition)
                new_competition = Competition(Name=offre.competition, UnifiedType='Platform', PlatformId=platform.Id, Platform_Id=offre.competitionId)
                competition = CompetitionService.create(session, new_competition)

                pprint(competition)

            event = EventService.getEventByPlatformAndPlatform_Id(session, platform.Id)
        else:
            logging.debug("Updating odds.")
        # If outcomes already exists, then then upper chain (bet, event, competition, ... is already existing).
        # In such case, we only need to update the odd of the corresponding outcome.

        # If no exists, check if competition exists ?, create or get;
        # If no exists, check if event exists ? create or get;
        # If no exists, create bet with event

# Check integritée et parametrage
# TODO: Trouver un moyen de lire la configuration et de la passer directement au threads qui seront mis
# Cible : 


# 1 -> Itération sur les sports
    # 2-> Récupération des compétitions du sport
        #3-> Itération sur les compétitions
        #4-> Récupération des cotes de cette compétition