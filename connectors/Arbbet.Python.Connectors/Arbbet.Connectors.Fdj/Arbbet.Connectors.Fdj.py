import sys, os
import urllib
import requests
import json
from types import SimpleNamespace
from dotenv import load_dotenv

config_sports = '[{"id": "100", "name": "football"},{"id": "600", "name": "rugby"}]'

def getBySport(sportId):
    r = requests.get('https://www.pointdevente.parionssport.fdj.fr/api/1n2/offre?sport=' + sportId)
    if r.status_code == 200:
        return r.text

    elif r.status_code == 400:
        return

print("Lauching Connector Fdj")
# Configuration
load_dotenv();

tmp = os.getenv('POSTGRES_USERNAME')

# Building sports array
sports = json.loads(config_sports, object_hook=lambda d: SimpleNamespace(**d))

# Foreach sport
for sport in sports:
    res = getBySport(sport.id)
    res_json = json.loads(res, object_hook=lambda d: SimpleNamespace(**d))

    for event in res_json:
        print(event.competition + ':' + event.label)

# Check integritée et parametrage
# TODO: Trouver un moyen de lire la configuration et de la passer directement au threads qui seront mis
# Cible : 


# 1 -> Itération sur les sports
    # 2-> Récupération des compétitions du sport
        #3-> Itération sur les compétitions
        #4-> Récupération des cotes de cette compétition