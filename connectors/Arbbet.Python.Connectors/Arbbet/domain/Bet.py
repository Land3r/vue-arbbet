from sqlalchemy.ext.declarative import declarative_base
from sqlalchemy.dialects.postgresql import UUID
from sqlalchemy import Column, String, Numeric, Enum, DateTime
import uuid

Base = declarative_base()

class Bet(Base):
    __tablename__ = 'Bets'

    Id = Column(UUID(as_uuid=True), primary_key=True, default=uuid.uuid4)
    Name = Column(String)
    EventId = Column(UUID(as_uuid=True))
    BetType = Column(Enum)
    CreatedAt = Column(DateTime)
    UpdatedAt = Column(DateTime)
    ExpiresAt = Column(DateTime)
    UnifiedEntityId = Column(UUID(as_uuid=True))
    UnifiedType = Column(Enum('Master', 'Platform'))
    PlatformId = Column(UUID(as_uuid=True))
    Platform_Id = Column(String)

class BetService(object):
    """description of class"""
    def getBetByPlatformAndPlatform_Id(session, platformId, platform_id):
        bet = session.query(Bet).filter_by(PlatformId = platformId, Platform_Id = platform_id).one_or_none()
        return bet