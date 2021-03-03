from domain.Platform import Platform 

class PlatformService(object):
    def getPlatformByCode(session, code):
        platform = session.query(Platform).filter_by(Code=code).one()
        return platform


