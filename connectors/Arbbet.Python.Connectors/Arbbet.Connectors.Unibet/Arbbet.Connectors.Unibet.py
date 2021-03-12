
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
from service.UnibetService2 import UnibetService

logging.basicConfig(
    format='%(asctime)s %(levelname)-8s %(message)s',
    level=logging.WARNING,
    datefmt='%Y-%m-%d %H:%M:%S')

logging.info("Lauching Connector UNIBET")

# Configuration
load_dotenv();

logging.debug("Using following configuration")
logging.debug("DB_CONNECTIONSTRING: %s", os.getenv('DB_CONNECTIONSTRING'))

sqlengine = create_engine(os.getenv('DB_CONNECTIONSTRING'), echo=False)
Session = sessionmaker(bind=sqlengine)
session = Session()
logging.debug("Connected to database")

# Retrieve Platform
platform = PlatformService.getPlatformByCode(session, 'UNI')
logging.debug("Retrieved platform from database")

# Getting sports/competitions
sports = UnibetService.getSports()
logging.info("Retrieved %d sports", len(sports))

for sport in sports:
    logging.debug("Processing %s", sport['name'])

    # FIXME: Temp: Seulement Football
    if (sport['name'] != 'Football'):
        continue

    # Preparing stats
    createdOutcomes = 0
    updatedOutcomes = 0
    createdBets = 0

    # Getting all markets for sport
    marketTypes = UnibetService.getMarketTypes(sport['platform_id'])
    total_submarkets = 0
    for market in marketTypes:
        total_submarkets += len(market['subMarkets'])

    logging.debug("Retrieved %d market types, and %d sub market (total)", len(marketTypes), total_submarkets)
    if (len(marketTypes) == 0):
        logging.debug("No markets, skipping")
        continue

    for market in marketTypes:
        for sub_market in market['subMarkets']:
            events = UnibetService.getMarketEvents(sport['platform_id'], market['name'], sub_market)

            #TODO: We get the events and outcomes
            # Like FDJ
            # Create or get competition
            # Create or get event
            # Create or get team
            
            # Now, create or get bet
            # Create or update outcomes
session.close()
logging.info('Done')