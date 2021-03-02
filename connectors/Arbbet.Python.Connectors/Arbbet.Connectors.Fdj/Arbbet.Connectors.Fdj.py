import sys, os, logging
import urllib
import requests
import json
from types import SimpleNamespace
from dotenv import load_dotenv
import psycopg2

class Platform(object):
    def __init__(self, id, code, name):
        self.id = id
        self.code = code
        self.name = name

    @property
    def id(self):
        return self._id

    @id.setter
    def id(self, value):
        self._id = value

    @property
    def name(self):
        return self._name

    @name.setter
    def name(self, value):
        self._name = value

    @property
    def code(self):
        return self._code

    @code.setter
    def code(self, value):
        self._code = value

class Sport(object):
    def __init__(self, id, code, name, idfdj):
        self.id = id
        self.code = code
        self.name = name
        self.idfdj = idfdj

    @property
    def id(self):
        return self._id

    @id.setter
    def id(self, value):
        self._id = value

    @property
    def name(self):
        return self._name

    @name.setter
    def name(self, value):
        self._name = value

    @property
    def code(self):
        return self._code

    @code.setter
    def code(self, value):
        self._code = value

    @property
    def idfdj(self):
        return self._idfdj

    @idfdj.setter
    def idfdj(self, value):
        self._idfdj = value

class Competition(object):
    def __init__(self, id, name, countryid, idfdj):
        self.id = id
        self.name = name
        self.countryid = countryid
        self.idfdj = idfdj

    @property
    def id(self):
        return self._id

    @id.setter
    def id(self, value):
        self._id = value

    @property
    def name(self):
        return self._name

    @name.setter
    def name(self, value):
        self._name = value

    @property
    def countryid(self):
        return self._countryid

    @countryid.setter
    def countryid(self, value):
        self._countryid = value

    @property
    def idfdj(self):
        return self._idfdj

    @idfdj.setter
    def idfdj(self, value):
        self._idfdj = value

class Event(object):
    def __init__(self, id, name, competitionid, idfdj):
        self.id = id
        self.name = name
        self.competitionid = competitionid
        self.idfdj = idfdj

    @property
    def id(self):
        return self._id

    @id.setter
    def id(self, value):
        self._id = value

    @property
    def name(self):
        return self._name

    @name.setter
    def name(self, value):
        self._name = value

    @property
    def competitionid(self):
        return self._competitionid

    @competitionid.setter
    def competitionid(self, value):
        self._competitionid = value

    @property
    def idfdj(self):
        return self._idfdj

    @idfdj.setter
    def idfdj(self, value):
        self._idfdj = value

class Bet(object):
    def __init__(self, id, teamaid, teambid, bettype, odd_win_a, odd_draw_a, odd_lose_a, platformid, idplatform, updatedat, espiresat, eventid):
        self.id = id
        self.teamaid = teamaid
        self.teambid = teambid
        self.bettype = bettype
        self.odd_win_a = odd_win_a
        self.odd_draw_a = odd_draw_a
        self.odd_lose_a = odd_lose_a
        self.platformid = platformid
        self.idplatform = idplatform
        self.updatedat = updatedat
        self.espiresat = espiresat
        self.eventid = eventid

    @property
    def id(self):
        return self._id

    @id.setter
    def id(self, value):
        self._id = value

    @property
    def teamaid(self):
        return self._teamaid

    @teamaid.setter
    def teamaid(self, value):
        self._teamaid = value

    @property
    def teambid(self):
        return self._teambid

    @teambid.setter
    def teambid(self, value):
        self._teambid = value

    @property
    def bettype(self):
        return self._bettype

    @bettype.setter
    def bettype(self, value):
        self._bettype = value

    @property
    def odd_win_a(self):
        return self._odd_win_a

    @odd_win_a.setter
    def odd_win_a(self, value):
        self._odd_win_a = value

    @property
    def odd_draw_a(self):
        return self._odd_draw_a

    @odd_draw_a.setter
    def odd_draw_a(self, value):
        self._odd_draw_a = value

    @property
    def odd_lose_a(self):
        return self._odd_lose_a

    @odd_lose_a.setter
    def odd_lose_a(self, value):
        self._odd_lose_a = value

    @property
    def platformid(self):
        return self._platformid

    @platformid.setter
    def platformid(self, value):
        self._platformid = value

    @property
    def idplatform(self):
        return self._idplatform

    @idplatform.setter
    def idplatform(self, value):
        self._idplatform = value

    @property
    def updatedat(self):
        return self._updatedat

    @updatedat.setter
    def updatedat(self, value):
        self._updatedat = value

    @property
    def expiresat(self):
        return self._expiresat

    @expiresat.setter
    def expiresat(self, value):
        self._expiresat = value

    @property
    def eventid(self):
        return self._eventid

    @eventid.setter
    def eventid(self, value):
        self._eventid = value

logging.basicConfig(
    format='%(asctime)s %(levelname)-8s %(message)s',
    level=logging.DEBUG,
    datefmt='%Y-%m-%d %H:%M:%S')

def getBetsBySport(sportId):
    r = requests.get('https://www.pointdevente.parionssport.fdj.fr/api/1n2/offre?sport=' + sportId)
    if r.status_code == 200:
        return r.text

    elif r.status_code == 400:
        return

def getFdjPlatform():
    cur.execute('SELECT "Id", "Code", "Name" FROM "Platforms" WHERE "Code"=\'FDJ\'')
    row = cur.fetchone()
    if (row != None):
        return Platform(row[0], row[1], row[2])
    else:
        return None


logging.info("Lauching Connector FDJ")

# Configuration
load_dotenv();

logging.debug("Using following configuration")
logging.debug("DB_CONNECTIONSTRING: %s", os.getenv('DB_CONNECTIONSTRING'))

con = psycopg2.connect(os.getenv('DB_CONNECTIONSTRING'))
cur = con.cursor()
logging.debug("Connected to database")

# Retrieve Platform
platform = getFdjPlatform()
logging.debug("Retrieved platform from database")

# Getting sports
cur.execute('SELECT "Id", "Code", "Name", "IdFdj" FROM "Sports"')
rows = cur.fetchall()
sports = []
for row in rows:
    sports.append(Sport(row[0], row[1], row[2], row[3]))
logging.info("Retrieved %d sports", len(sports))

# Getting bets for sports
for sport in sports:
    res = getBetsBySport(sport.idfdj)
    res_json = json.loads(res, object_hook=lambda d: SimpleNamespace(**d))

    for event in res_json:
        # Update if exists 
        # If no exists, check if competition exists ?, create or get;
        # If no exists, check if event exists ? create or get;
        # If no exists, create bet with event
        print(event.competition + ':' + event.label)

# Check integritée et parametrage
# TODO: Trouver un moyen de lire la configuration et de la passer directement au threads qui seront mis
# Cible : 


# 1 -> Itération sur les sports
    # 2-> Récupération des compétitions du sport
        #3-> Itération sur les compétitions
        #4-> Récupération des cotes de cette compétition