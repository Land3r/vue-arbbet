from sqlalchemy.ext.declarative import declarative_base
from sqlalchemy.dialects.postgresql import UUID
from sqlalchemy import Column, String, Numeric, Enum, DateTime
import uuid

Base = declarative_base()

class Competition(Base):
    __tablename__ = 'Competitions'

    Id = Column(UUID(as_uuid=True), primary_key=True, default=uuid.uuid4)
    Name = Column(String)
    CountryId = Column(UUID(as_uuid=True), foreign_key='Countries.Id')
    UnifiedEntityId = Column(UUID(as_uuid=True), foreign_key='Competitions.Id')
    UnifiedType = Column(String)
    PlatformId = Column(UUID(as_uuid=True), foreign_key='Platforms.Id')
    Platform_Id = Column(String)

class CompetitionService(object):
    """description of class"""
    def getCompetitionByPlatformAndPlatform_Id(session, platformId, platform_id):
        competition = session.query(Competition).filter_by(PlatformId = platformId, Platform_Id = platform_id).one_or_none()
        return competition

    def create(session, competition):
        session.add(competition)
        return competition