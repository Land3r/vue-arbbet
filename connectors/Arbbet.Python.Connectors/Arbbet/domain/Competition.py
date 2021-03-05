from sqlalchemy import Column, ForeignKey, String, Numeric, Enum, DateTime
from sqlalchemy.ext.declarative import declarative_base
from sqlalchemy.orm import relationship
from sqlalchemy.dialects.postgresql import UUID
import uuid
from domain.Platform import Platform

Base = declarative_base()



