from sqlalchemy.ext.declarative import declarative_base
from sqlalchemy.dialects.postgresql import UUID
from sqlalchemy import Column, String, Numeric, Enum
import uuid

Base = declarative_base()

class Platform(Base):
    __tablename__ = 'Platforms'

    Id = Column(UUID(as_uuid=True), primary_key=True, default=uuid.uuid4)
    Code = Column(String)
    Name = Column(String)
