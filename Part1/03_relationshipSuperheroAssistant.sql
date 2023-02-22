USE SuperHeroDb;

ALTER TABLE Assistant
ADD SuperHeroId INT NOT NULL
UNIQUE(SuperHeroId)
CONSTRAINT FK_Assistant_SuperHero
FOREIGN KEY (SuperHeroId)
REFERENCES SuperHero (SuperHeroId)
ON DELETE CASCADE;
