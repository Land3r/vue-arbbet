from sqlalchemy.ext.declarative import declarative_base
from sqlalchemy.dialects.postgresql import UUID
from sqlalchemy.orm import relationship
from sqlalchemy import Table, Column, ForeignKey, String, Numeric, DateTime
import uuid

Base = declarative_base()

class Platform(Base):
    __tablename__ = 'Platforms'

    Id = Column(UUID(as_uuid=True), primary_key=True, default=uuid.uuid4)
    Code = Column(String)
    Name = Column(String)

    def __repr__(self):
        return "<Platform('%s', '%s', '%s')>" % (self.Id, self.Code, self.Name)

class Country(Base):
    __tablename__ = 'Countries'

    Id = Column(UUID(as_uuid=True), primary_key=True, default=uuid.uuid4)
    Code = Column(String)
    Name = Column(String)

    def __repr__(self):
        return "<Country('%s', '%s', '%s')>" % (self.Id, self.Code, self.Name)

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
        return "<Sport('%s', '%s', '%s', '%s', '%s', '%s', '%s')>" % (self.Id, self.Code, self.Name, self.UnifiedEntityId, self.UnifiedType, self.PlatformId, self.Platform_Id)

class Team(Base):
    __tablename__ = 'Teams'

    Id = Column(UUID(as_uuid=True), primary_key=True, default=uuid.uuid4)
    Name = Column(String)
    TeamType = Column(String)
    SportId = Column(UUID(as_uuid=True), ForeignKey('Sports.Id'))
    Sport = relationship("Sport")
    CountryId = Column(UUID(as_uuid=True), ForeignKey('Countries.Id'))
    Country = relationship("Country")
    UnifiedEntityId = Column(UUID(as_uuid=True), ForeignKey('Teams.Id'))
    UnifiedEntity = relationship("Team")
    UnifiedType = Column(String)
    PlatformId = Column(UUID(as_uuid=True), ForeignKey('Platforms.Id'))
    Platform = relationship("Platform")
    Platform_Id = Column(String)
    
    def __repr__(self):
        return "<Team('%s', '%s', '%s', '%s', '%s', '%s', '%s')>" % (self.Id, self.Name, self.CountryId, self.UnifiedEntityId, self.UnifiedType, self.PlatformId, self.Platform_Id)

eventteam_table = Table('EventTeam', Base.metadata,
                    Column('EventId', UUID(as_uuid=True), ForeignKey('Events.Id')),
                    Column('TeamId', UUID(as_uuid=True), ForeignKey('Teams.Id'))
                )

class Competition(Base):
    __tablename__ = 'Competitions'

    Id = Column(UUID(as_uuid=True), primary_key=True, default=uuid.uuid4)
    Name = Column(String)
    CountryId = Column(UUID(as_uuid=True), ForeignKey('Countries.Id'))
    Country = relationship("Country")
    UnifiedEntityId = Column(UUID(as_uuid=True), ForeignKey('Competitions.Id'))
    UnifiedEntity = relationship("Competition")
    UnifiedType = Column(String)
    PlatformId = Column(UUID(as_uuid=True), ForeignKey('Platforms.Id'))
    Platform = relationship("Platform")
    Platform_Id = Column(String)

    def __repr__(self):
        return "<Competition('%s', '%s', '%s', '%s', '%s', '%s', '%s')>" % (self.Id, self.Name, self.CountryId, self.UnifiedEntityId, self.UnifiedType, self.PlatformId, self.Platform_Id)

class Event(Base):
    __tablename__ = 'Events'

    Id = Column(UUID(as_uuid=True), primary_key=True, default=uuid.uuid4)
    Name = Column(String)
    EventType = Column(String)
    CompetitionId = Column(UUID(as_uuid=True), ForeignKey("Competitions.Id"))
    Competition = relationship("Competition")
    Participants = relationship("Team", secondary=eventteam_table)
    CreatedAt = Column(DateTime)
    UpdatedAt = Column(DateTime)
    Url = Column(String)
    UnifiedEntityId = Column(UUID(as_uuid=True), ForeignKey("Events.Id"))
    UnifiedType = Column(String)
    PlatformId = Column(UUID(as_uuid=True), ForeignKey('Platforms.Id'))
    Platform = relationship("Platform")
    Platform_Id = Column(String)

    def __repr__(self):
        return "<Event('%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s')>" % (self.Id, self.Name, self.EventType, self.CompetitionId, self.CreatedAt, self.UpdatedAt, self.Url, self.UnifiedEntityId, self.UnifiedType, self.PlatformId, self.Platform_Id)

class Bet(Base):
    __tablename__ = 'Bets'

    Id = Column(UUID(as_uuid=True), primary_key=True, default=uuid.uuid4)
    Name = Column(String)
    EventId = Column(UUID(as_uuid=True), ForeignKey("Events.Id"))
    Event = relationship("Event")
    BetType = Column(String)
    CreatedAt = Column(DateTime)
    UpdatedAt = Column(DateTime)
    ExpiresAt = Column(DateTime)
    UnifiedEntityId = Column(UUID(as_uuid=True), ForeignKey("Bets.Id"))
    UnifiedType = Column(String)
    PlatformId = Column(UUID(as_uuid=True), ForeignKey('Platforms.Id'))
    Platform = relationship("Platform")
    Platform_Id = Column(String)

    def __repr__(self):
        return "<Bet('%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s', '%s')>" % (self.Id, self.Name, self.EventId, self.BetType, self.CreatedAt, self.UpdatedAt, self.ExpiresAt, self.UnifiedEntityId, self.UnifiedType, self.PlatformId, self.Platform_Id)

class Outcome(Base):
    __tablename__ = 'Outcomes'

    Id = Column(UUID(as_uuid=True), primary_key=True, default=uuid.uuid4)
    Odd = Column(Numeric)
    OutcomeType = Column(String)
    BetId = Column(UUID(as_uuid=True), ForeignKey("Bets.Id"))
    Bet = relationship("Bet")
    TeamId = Column(UUID(as_uuid=True), ForeignKey("Teams.Id"))
    Team = relationship("Team")

    def __repr__(self):
        return "<Outcome('%s', '%s', '%s', '%s', '%s')>" % (self.Id, self.Odd, self.OutcomeType, self.BetId, self.TeamId)
