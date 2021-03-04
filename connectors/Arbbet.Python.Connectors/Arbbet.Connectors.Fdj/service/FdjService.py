from urllib.parse import urljoin
import requests
import logging
import json
from types import SimpleNamespace


baseUrl = 'https://www.pointdevente.parionssport.fdj.fr/api/'

endpointUrl = {
    'offre': '1n2/offre?sport={0}'
}

class FdjService(object):
    def getOffre(sportId):

        if (sportId == None):
            raise Exception('sportId is null')

        url = urljoin(baseUrl, endpointUrl.get('offre').format(sportId))
        r = requests.get(url)
        
        if r.status_code == 200:
            logging.debug(r.text)
            res_object = json.loads(r.text, object_hook=lambda d: SimpleNamespace(**d))
            return res_object

        elif r.status_code == 204:
            return []

        elif r.status_code == 400:
            return

        else:
            return r
