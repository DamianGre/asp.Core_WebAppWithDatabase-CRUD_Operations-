USE master;
GO

DROP DATABASE IF EXISTS WebAppWithDatabase;
GO

CREATE DATABASE WebAppWithDatabase;
GO

USE WebAppWithDatabase;
GO

CREATE TABLE clients(
id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
name VARCHAR(100) NOT NULL,
email VARCHAR(100) NOT NULL UNIQUE,
phone VARCHAR(25) NOT NULL,
address VARCHAR(100) NOT NULL,
creation_date DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP
);
GO

INSERT INTO clients(name, email, phone, address) Values
('Jan Kowalski', 'jk@example.com', '11111111', 'Gdynia, Poland'),
('Tomasz Nowak', 'tn@example.com', '22222222', 'Warszawa, Poland'),
('Piotr Sowal', 'ps@example.com', '33333333', 'Katowice, Poland'),
('Magda Kotwica', 'mk@example.com', '44444444', 'Nysa, Poland'),
('Anna Kowal', 'ak@example.com', '55555555', 'Sopot, Poland');

