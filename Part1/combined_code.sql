--Script 1--
CREATE DATABASE SuperHeroDb;

--Script 2--

USE SuperHeroDb;

CREATE TABLE SuperHero (
  SuperHeroId INT NOT NULL IDENTITY(1,1),
  Name VARCHAR(255),
  Alias VARCHAR(255),
  Origin VARCHAR(255),
  PRIMARY KEY (SuperHeroId)
);

CREATE TABLE Assistant (
  AssistantId INT NOT NULL IDENTITY(1,1),
  Name VARCHAR(255),
  PRIMARY KEY (AssistantId)
);

CREATE TABLE Power (
  PowerId INT NOT NULL IDENTITY(1,1),
  Name VARCHAR(255),
  Description TEXT,
  PRIMARY KEY (PowerId)
);

--Script 3--

USE SuperHeroDb;

ALTER TABLE Assistant
ADD SuperHeroId INT NOT NULL
UNIQUE(SuperHeroId)
CONSTRAINT FK_Assistant_Superhero
FOREIGN KEY (SuperheroId)
REFERENCES SuperHero (SuperHeroId)
ON DELETE CASCADE;


--Script 4--
--Generating a junction table to link multiple tabels together.--
CREATE TABLE SuperHero_Power_Junction (
 SuperHeroId INT,
 PowerId INT,
 CONSTRAINT PK_SuperHero_Power_Junction PRIMARY KEY (SuperHeroId, PowerId),
 CONSTRAINT FK_SuperHero
 FOREIGN KEY (SuperHeroId) REFERENCES SuperHero (SuperHeroId),
 CONSTRAINT FK_Power
 FOREIGN KEY (PowerId) REFERENCES Power (PowerId)
);