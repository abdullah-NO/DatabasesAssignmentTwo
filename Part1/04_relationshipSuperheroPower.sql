--Generating a junction table to link multiple tables together.--
USE SuperHeroDb
CREATE TABLE SuperHero_Power_Junction (
SuperHeroId INT,
PowerId INT, -- Updated data type to INT
CONSTRAINT PK_SuperHero_Power_Junction PRIMARY KEY (SuperHeroId, PowerId),
CONSTRAINT FK_SuperHero
FOREIGN KEY (SuperHeroId) REFERENCES SuperHero (SuperHeroId),
CONSTRAINT FK_Power
FOREIGN KEY (PowerId) REFERENCES Power (PowerId)
);