from sqlalchemy.ext.declarative import declarative_base
from sqlalchemy.dialects.postgresql import UUID
from sqlalchemy import Column, String
import uuid

Base = declarative_base()

class Sport(Base):
    __tablename__ = 'Sports'

    Id = Column(UUID(as_uuid=True), primary_key=True, default=uuid.uuid4)
    Name = Column(String)
    Code = Column(String)
    UnifiedEntityId = Column(UUID(as_uuid=True))
    UnifiedType = Column(String)
    PlatformId = Column(UUID(as_uuid=True))
    Platform_Id = Column(String)

class SportService(object):
    def getSportsByPlatform(session, platformId):
        sports = session.query(Sport).filter_by(PlatformId=platformId).all()
        return sports