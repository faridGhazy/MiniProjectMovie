CREATE TABLE databaseMovie;

CREATE TABLE `tableSutradara` (
  `id` INT NOT NULL,
  `namaSutradara` VARCHAR(45) NULL,
  PRIMARY KEY (`id`));

CREATE TABLE `tableAktor` (
  `id` INT NOT NULL,
  `namaAktor` VARCHAR(45) NULL,
  PRIMARY KEY (id));
  
  CREATE TABLE `tableGenre` (
  `id` INT NOT NULL,
  `namaGenre` VARCHAR(45) NULL,
  PRIMARY KEY (`id`));
  
  CREATE TABLE `tableMovie` (
  `id` INT NOT NULL,
  `namaMovie` VARCHAR(45) NULL,
  `rating` FLOAT NULL,
  `tahun` YEAR NULL,
  `sutradaraId` INT,
  `aktorId` INT NULL,
  `genreId` INT NULL,
  PRIMARY KEY (`id`),
  FOREIGN KEY (`sutradaraId`) REFERENCES `tablesutradara`(`id`),
  FOREIGN KEY (`aktorId`) REFERENCES `tableaktor`(`id`),
  FOREIGN KEY (`genreId`) REFERENCES `tablegenre`(`id`)
  );
  
  CREATE TABLE IF NOT EXISTS `databaseMovie`.`tableMovie` (
  `id` INT NOT NULL,
  `namaMovie` VARCHAR(45) NULL,
  `rating` FLOAT NULL,
  `tahun` YEAR NULL,
  `sutradaraId` INT NOT NULL,
  `aktorUtamaId` INT NOT NULL,
  PRIMARY KEY (`id`, `sutradaraId`, `aktorUtamaId`),
  INDEX `fk_tableMovie_tableSutradara1_idx` (`sutradaraId` ASC) VISIBLE,
  INDEX `fk_tableMovie_tableAktorUtama1_idx` (`aktorUtamaId` ASC) VISIBLE,
  CONSTRAINT `fk_tableMovie_tableSutradara1`
    FOREIGN KEY (`sutradaraId`)
    REFERENCES `databaseMovie`.`tableSutradara` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_tableMovie_tableAktor`
    FOREIGN KEY (`aktorUtamaId`)
    REFERENCES `databaseMovie`.`tableAktor` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB;
  
  CREATE TABLE `tableGenreMovie` (
  `movieId` INT NOT NULL,
  `sutradaraId` INT NOT NULL,
  `aktorUtamaId` INT NOT NULL,
  `genreId` INT NOT NULL,
  PRIMARY KEY (`movieId`, `sutradaraId`, `aktorUtamaId`, `genreId`),
  INDEX `fk_tableMovie_has_tableGenre_tableGenre1_idx` (`genreId` ASC) VISIBLE,
  INDEX `fk_tableMovie_has_tableGenre_tableMovie1_idx` (`movieId` ASC, `sutradaraId` ASC, `aktorUtamaId` ASC) VISIBLE,
  CONSTRAINT `fk_tableMovie_has_tableGenre_tableMovie1`
    FOREIGN KEY (`movieId` , `sutradaraId` , `aktorUtamaId`)
    REFERENCES `databaseMovie`.`tableMovie` (`id` , `sutradaraId` , `aktorUtamaId`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_tableMovie_has_tableGenre_tableGenre1`
    FOREIGN KEY (`genreId`)
    REFERENCES `databaseMovie`.`tableGenre` (`id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION);
  
#insert ke dalam table genre 
INSERT INTO `tablegenre` (`id`, `namaGenre`) VALUES ('1', 'Action');
INSERT INTO `tablegenre` (`id`, `namaGenre`) VALUES ('2', 'Adventure');
INSERT INTO `tablegenre` (`id`, `namaGenre`) VALUES ('3', 'Fantasy');
INSERT INTO `tablegenre` (`id`, `namaGenre`) VALUES ('4', 'Comedy');
INSERT INTO `tablegenre` (`id`, `namaGenre`) VALUES ('5', 'Drama');
INSERT INTO `tablegenre` (`id`, `namaGenre`) VALUES ('6', 'Horror');

#insert ke dalam table sutradara
INSERT INTO `tablesutradara` (`id`, `namaSutradara`) VALUES ('1', 'Sam Raimi');
INSERT INTO `tablesutradara` (`id`, `namaSutradara`) VALUES ('2', 'Taika Waititi');
INSERT INTO `tablesutradara` (`id`, `namaSutradara`) VALUES ('3', 'Dean Zimmerman');

#insert ke dalam table aktor
INSERT INTO `tableaktor` (`id`, `namaAktor`) VALUES ('1', 'Benedict Cumberbatch');
INSERT INTO `tableaktor` (`id`, `namaAktor`) VALUES ('2', 'Chris Hemsworth');
INSERT INTO `tableaktor` (`id`, `namaAktor`) VALUES ('3', 'Millie Bobby Brown');

select * from tableMovie;
#menampilkan semua data
SELECT m.namaMovie, m.rating, m.tahun, s.namaSutradara, a.namaAktor FROM databasemovie.tablemovie m
join tablesutradara s on m.sutradaraId = s.idtablegenremovie
join tableaktor a on m.aktorUtamaId = a.id;

select * from tablegenremovie;

SELECT m.id, m.namaMovie, m.rating, m.tahun, s.namaSutradara, a.namaAktor, group_concat('',g.namaGenre) as NamaGenre 
FROM tablegenremovie gm
join tablemovie m 
	on gm.movieId = m.id
join tablesutradara s 
	on  m.sutradaraId = s.id
join tableaktor a 
	on m.aktorUtamaId = a.id
join tablegenre g 
	on gm.genreId = g.id
group by m.id
order by gm.movieId;

