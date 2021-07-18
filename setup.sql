CREATE TABLE IF NOT EXISTS cars(  
    id int NOT NULL primary key AUTO_INCREMENT comment 'primary key',
    createdAt DATETIME DEFAULT CURRENT_TIMESTAMP COMMENT 'create time',
    updatedAt DATETIME DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP COMMENT 'update time',
    carMake varchar(255) comment 'Car Make',
    carModel varchar(255) comment 'Car Model',
    carYear int COMMENT 'Year Made',
    carPrice int COMMENT 'Price'
) default charset utf8 comment '';

INSERT INTO cars(carMake, carModel, carPrice, carYear) VALUES ("honda", "civic", 1990, 2000);

INSERT INTO cars(carMake, carModel, carPrice, carYear) VALUES ("toyota", "hellzyeah", 2010, 5000);

--GET ALL
 SELECT id, carMake, carModel, carPrice, carYear FROM cars ORDER BY carPrice DESC;

--Get By ID
SELECT * FROM cars WHERE id = 1;

--UPDATE 
UPDATE cars Set carModel = "accord" WHERE id = 2;

DELETE FROM cars WHERE id = 3;



 