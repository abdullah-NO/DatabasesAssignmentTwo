USE SuperHeroDb;

ALTER TABLE Assistant
<<<<<<< Updated upstream
ADD SuperheroId INT NULL,
CONSTRAINT FK_Assistant_Superhero
FOREIGN KEY (SuperheroId)
REFERENCES Superhero (Id)
ON DELETE SET NULL;
=======
ADD SuperHeroId INT NOT NULL
UNIQUE(SuperHeroId)
CONSTRAINT FK_Assistant_SuperHero
FOREIGN KEY (SuperHeroId)
REFERENCES SuperHero (SuperHeroId)
ON DELETE CASCADE;
>>>>>>> Stashed changes
