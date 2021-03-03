from sqlalchemy.ext.declarative import declarative_base
from sqlalchemy.dialects.postgresql import UUID
from sqlalchemy import Column, String, Numeric, Enum
import uuid

Base = declarative_base()

class Outcome(Base):
    __tablename__ = 'Outcomes'

    Id = Column(UUID(as_uuid=True), primary_key=True, default=uuid.uuid4)
    Odd = Column(Numeric)
    OutcomeType = Column(Enum)
    BetId = Column(UUID(as_uuid=True))
    TeamId = Column(UUID(as_uuid=True))