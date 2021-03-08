from domain.entities import Platform, Country, Sport, Team, Competition, Event, Bet, Outcome

class PlatformService(object):
    def getPlatformByCode(session, code):
        platform = session.query(Platform).filter(Platform.Code == code).one()
        return platform

class CountryService(object):
    def getCountryByCode(session, code):
        country = session.query(Country).filter(Team.Code == code).one()
        return country

class TeamService(object):
    def getTeamByPlatformAndPlatform_Id(session, platformId, platform_id):
        team = session.query(Team).filter(Team.PlatformId == platformId, Team.Platform_Id == platform_id).one_or_none()
        return team

    def create(session, team):
        session.add(team)
        return team

class SportService(object):
    def getSportsByPlatform(session, platformId):
        sports = session.query(Sport).filter(Sport.PlatformId == platformId).all()
        return sports

class CompetitionService(object):
    def getCompetitionByPlatformAndPlatform_Id(session, platformId, platform_id):
        competition = session.query(Competition).filter(Competition.PlatformId == platformId, Competition.Platform_Id == platform_id).one_or_none()
        return competition

    def create(session, competition):
        session.add(competition)
        return competition

class EventService(object):
    def getEventByPlatformAndPlatform_Id(session, platformId, platform_id):
        event = session.query(Event).filter(Event.PlatformId == platformId, Event.Platform_Id == platform_id).one_or_none()
        return event

    def create(session, event):
        session.add(event)
        return event

class BetService(object):
    def getBetByPlatformAndPlatform_Id(session, platformId, platform_id):
        bet = session.query(Bet).filter(Bet.PlatformId == platformId, Bet.Platform_Id == platform_id).one_or_none()
        return bet

    def create(session, bet):
        session.add(bet)
        return bet

class OutcomeService(object):
    def getOutcomesByBet(session, betId):
        outcomes = session.query(Outcome).filter(Outcome.BetId == betId).all()
        return outcomes

    def create(session, outcome):
        session.add(outcome)
        return outcome