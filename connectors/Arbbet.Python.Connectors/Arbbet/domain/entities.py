from sqlalchemy.ext.declarative import declarative_base
from sqlalchemy.dialects.postgresql import UUID
from sqlalchemy.orm import relationship
from sqlalchemy import Column, ForeignKey, String, Numeric, Enum, DateTime
import uuid

Base = declarative_base()

class Platform(Base):
    __tablename__ = 'Platforms'

    Id = Column(UUID(as_uuid=True), primary_key=True, default=uuid.uuid4)
    Code = Column(String)
    Name = Column(String)

    def __repr__(self):
        return "<Platform('%s', '%s', '%s')>" % (self.Id, self.Code, self.Name)

class Sport(Base):
    __tablename__ = 'Sports'

    Id = Column(UUID(as_uuid=True), primary_key=True, default=uuid.uuid4)
    Code = Column(String)
    Name = Column(String)
    UnifiedEntityId = Column(UUID(as_uuid=True))
    UnifiedType = Column(String)
    PlatformId = Column(UUID(as_uuid=True))
    Platform_Id = Column(String)

    def __repr__(self):
        return "<Sport('%s', '%s', '%s', '%s', '%s', '%s', '%s')>" % (self.Id, self.Code, self.Name, self.UnifiedEntityId, self.UnifiedType, self.PlatformId, self.PlatformId)

class Competition(Base):
    __tablename__ = 'Competitions'

    Id = Column(UUID(as_uuid=True), primary_key=True, default=uuid.uuid4)
    Name = Column(String)
    CountryId = Column(UUID(as_uuid=True), ForeignKey('Countries.Id'))
    UnifiedEntityId = Column(UUID(as_uuid=True), ForeignKey('Competitions.Id'))
    UnifiedType = Column(String)
    PlatformId = Column(UUID(as_uuid=True), ForeignKey('Platforms.Id'))
    Platform = relationship("Platform")
    Platform_Id = Column(String)

    def __repr__(self):
        return "<Competition('%s', '%s', '%s', '%s', '%s', '%s', '%s')>" % (self.Id, self.Name, self.CountryId, self.UnifiedEntityId, self.UnifiedType, self.PlatformId, self.PlatformId)


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

    def __repr__(self):
        return "<Bet('%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s')>" % (self.Id, self.Name, self.EventId, self.BetType, self.CreatedAt, self.UpdatedAt, self.ExpiresAt, self.UnifiedEntityId, self.UnifiedType, self.PlatformId, self.PlatformId)

class Outcome(Base):
    __tablename__ = 'Outcomes'

    Id = Column(UUID(as_uuid=True), primary_key=True, default=uuid.uuid4)
    Odd = Column(Numeric)
    OutcomeType = Column(Enum)
    BetId = Column(UUID(as_uuid=True))
    TeamId = Column(UUID(as_uuid=True))

    def __repr__(self):
        return "<Outcome('%s', '%s', '%s', '%s', '%s')>" % (self.Id, self.Odd, self.OutcomeType, self.BetId, self.TeamId)
