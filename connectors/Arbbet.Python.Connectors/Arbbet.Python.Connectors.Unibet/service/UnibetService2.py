from urllib.parse import urljoin, quote_plus
import requests
import logging
import json
from types import SimpleNamespace
from datetime import datetime

from service.markets import config_markets
from service.bets import config_bets

baseUrl = 'https://www.unibet.fr/'

endpointUrl = {
    'navigation': 'zones/menulist/all.json',
    'marketTypes': 'zones/sportnode/marketfilters.json?nodeId={0}',
    'markets': 'zones/sportnode/markets.json?nodeId={0}&filter={1}&marketname={2}'
    #'markets': 'zones/sportnode/markets.json?nodeId={0}&filter=R%25C3%25A9sultat&marketname=R%25C3%25A9sultat%2520du%2520match
}

excluded_sports = [
    'Accueil Paris Sportifs',
    'Promotions',
    'Cotes Boostées',
    'Super Cotes Boostées',
    'Unibet Experience'
]

class UnibetService(object):
    def getSports():
        url = urljoin(baseUrl, endpointUrl.get('navigation'))
        r = requests.get(url)
        
        if r.status_code == 200:
            res_object = json.loads(r.text, object_hook=lambda d: SimpleNamespace(**d))

            nav = getattr(res_object, '4')
            sports = []
            for menuLevel1 in nav.menusLevel1:

                if menuLevel1.name not in excluded_sports:
                    sport = {
                        'name': menuLevel1.name,
                        'platform_id': menuLevel1.nodeId
                    }
                    sports.append(sport)

            for menuLevel1 in nav.menusLevel1More:

                if menuLevel1.name not in excluded_sports:
                    sport = {
                        'name': menuLevel1.name,
                        'platform_id': menuLevel1.nodeId
                    }
                    sports.append(sport)

            return sports

        elif r.status_code == 204:
            return []

        elif r.status_code == 400:
            return

        else:
            return r

    def getMarketTypes(sportId):
        url = urljoin(baseUrl, endpointUrl.get('marketTypes').format(sportId))
        r = requests.get(url)
        
        if r.status_code == 200:
            logging.debug(r.text)
            res_object = json.loads(r.text)

            marketTypes = []
            for prop in res_object['marketNames']:
                market = {
                    'name': prop
                }
                subMarkets = []

                for subMarket in res_object['marketNames'][prop]:
                    subMarkets.append(subMarket['name'])

                market['subMarkets'] = subMarkets

                marketTypes.append(market)
            return marketTypes

        elif r.status_code == 204:
            return []

        elif r.status_code == 400:
            return

        else:
            return r

    def getMarketEvents(sportId, marketGroup, marketName):

        shouldExploreEvent = True
        try:
            shouldExploreEvent = config_markets[marketGroup][marketName]
        except Exception:
            logging.warning('MarketGroup: %s, MarketName: %s', marketGroup, marketName)
            shouldExploreEvent = False
            pass
        
        if (shouldExploreEvent):
            url = urljoin(baseUrl, endpointUrl.get('markets').format(sportId, quote_plus(marketGroup), quote_plus(marketName)))
            r = requests.get(url)
        
            if r.status_code == 200:
                logging.debug(r.text)
                res_object = json.loads(r.text)

                events = []
                logging.debug('Retrieved %d events for this market', len(res_object['marketsByType'][0]['days'][0]['events']))

                for event in res_object['marketsByType'][0]['days'][0]['events']:

                    # Parse into a timestamp.
                    event_start_date_timestamp_str = str(event['eventStartDate'])[:-3]
                    event_start_date_timestamp_int = int(event_start_date_timestamp_str)

                    eventElm = {
                        'event_platform_id': event['eventId'],
                        'event_name': event['eventName'],
                        'competition_platform_id': event['competitionId'],
                        'competition_name': event['competitionName'],
                        'competition_country_name': None,
                        'event_start_date': datetime.fromtimestamp(event_start_date_timestamp_int),
                        'event_team_home_name': None,
                        'event_team_away_name': None,
                        'event_url': None
                    }

                    try:
                        eventElm['competition_name'] = event['competitionName'].split(', ')[1]
                        eventElm['competition_country_name'] = event['competitionName'].split(', ')[0]
                        pass
                    except Exception:
                        pass

                    bets = []
                    for market in event['markets']:

                        bet = {
                            'bet_platform_id': market['marketId'],
                            'bet_type': None
                        }

                        if (eventElm['event_team_home_name'] == None):
                            eventElm['event_team_home_name'] = market['eventHomeTeamName']

                        if (eventElm['event_team_away_name'] == None):
                            eventElm['event_team_away_name'] = market['eventAwayTeamName']

                        if (eventElm['event_url'] == None):
                            eventElm['event_url'] = market['eventFriendlyUrl']

                        if (market['marketType'] == '1x2'):
                            bet['bet_type'] = 'Win_Draw_Lose'

                        outcomes = []
                        for selection in market['selections']:

                            upper_odd = selection['currentPriceUp']
                            lower_odd = selection['currentPriceDown']
                            odd = (int(upper_odd) / int(lower_odd)) + 1

                            #TODO: Interpret market and market type.
                            outcome = {
                                'odd': odd,
                                'outcome_type': 'Individual_Winner',
                                'outcome_team_name': selection['name']
                            }
                            outcomes.append(outcome)

                        bet['outcomes'] = outcomes
                        bets.append(bet)

                    eventElm['bets'] = bets
                    events.append(eventElm)
                return events

            elif r.status_code == 204:
                return []

            elif r.status_code == 400:
                return

            else:
                return r