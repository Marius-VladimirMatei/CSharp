USE customerdb;

CREATE TABLE IF NOT EXISTS Users (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Username VARCHAR(100) NOT NULL,
    Password VARCHAR(100) NOT NULL,
    Role VARCHAR(50) NOT NULL
);


CREATE TABLE IF NOT EXISTS Customers (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    FirstName VARCHAR(100),
    LastName VARCHAR(100),
    Street VARCHAR(100),
    HouseNumber VARCHAR(10),
    ZipCode VARCHAR(10),
    City VARCHAR(100),
    Email VARCHAR(100)
);

INSERT INTO Users (Username, Password, Role) VALUES ('admin', 'admin', 'Admin');
INSERT INTO Users (Username, Password, Role) VALUES ('guest', 'guest', 'Guest');

SELECT * FROM customers;

SELECT * FROM users;

SHOW TABLES;

