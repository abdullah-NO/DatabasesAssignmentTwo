USE SuperHeroDb;
INSERT INTO power(Name,Description)
VALUES 
	('Wind assailant detector','Knows when and who lets out a fart in the vecinity'),
    ('extra jump','can jump an extra centimeter vertically'),
    ('the silent picker', 'have the skills and knowledge to pick a bogger without anyone detecting it'),
	('breath of the wild','instead of fixing bad breath with toothpaste and a brush, it makes it worse');

INSERT INTO SuperHero_Power_Junction(SuperHeroId, PowerId)
VALUES 
	(1, 1),
	(2, 2),
	(3, 3),
	(1, 4),
	(2, 1),
	(3, 2);
