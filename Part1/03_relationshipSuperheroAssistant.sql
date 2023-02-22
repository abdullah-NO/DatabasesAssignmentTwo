USE SuperHeroDb;

ALTER TABLE Assistant
ADD SuperHeroId INT NOT NULL
UNIQUE(SuperHeroId)
CONSTRAINT FK_Assistant_Superhero
FOREIGN KEY (SuperHeroId)
REFERENCES SuperHero (SuperHeroId)
ON DELETE CASCADE;