class PlatformService(object):
    def getPlatformByCode(session, code):
        platform = session.query(Platform).filter_by(Code=code).one()
        return platform

class SportService(object):
    def getSportsByPlatform(session, platformId):
        sports = session.query(Sport).filter_by(PlatformId=platformId).all()
        return sports

class CompetitionService(object):
    def getCompetitionByPlatformAndPlatform_Id(session, platformId, platform_id):
        competition = session.query(Competition).filter_by(PlatformId = platformId, Platform_Id = platform_id).one_or_none()
        return competition

    def create(session, competition):
        session.add(competition)
        return competition

class BetService(object):
    """description of class"""
    def getBetByPlatformAndPlatform_Id(session, platformId, platform_id):
        bet = session.query(Bet).filter_by(PlatformId = platformId, Platform_Id = platform_id).one_or_none()
        return bet