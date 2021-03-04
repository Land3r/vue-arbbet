from sqlalchemy.ext.declarative import declarative_base
from sqlalchemy.dialects.postgresql import UUID
from sqlalchemy import Column, String, Numeric, Enum, DateTime
import uuid

Base = declarative_base()

class Event(Base):
    __tablename__ = 'Events'

    Id = Column(UUID(as_uuid=True), primary_key=True, default=uuid.uuid4)
    Name = Column(String)
    EventType = Column(Enum)
    CompetitionId = Column(UUID(as_uuid=True))
    CreatedAd = Column(DateTime)
    UpdatedAt = Column(DateTime)
    Url = Column(String)
    UnifiedEntityId = Column(UUID(as_uuid=True))
    UnifiedType = Column(Enum)
    PlatformId = Column(UUID(as_uuid=True))
    Platform_Id = Column(String)

class EventService(object):
    """description of class"""
    def getEventByPlatformAndPlatform_Id(session, platformId, plaform_id):
        event = session.query(Event).filter_by(PlatformId=platformId, Platform_Id = platform_id).one_or_none()
        return event