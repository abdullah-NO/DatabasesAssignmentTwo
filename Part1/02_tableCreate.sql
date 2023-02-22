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
