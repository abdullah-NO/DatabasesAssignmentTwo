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