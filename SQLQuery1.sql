CREATE DATABASE drzava;
USE drzava;

CREATE TABLE drzava(
  id INT IDENTITY(1, 1),
  naziv NVARCHAR(80) NOT NULL,
  kontinent NVARCHAR(80) NOT NULL,
  glavni_grad NVARCHAR(80) NOT NULL,
  povrsina INT NOT NULL,
  broj_stanovnika INT NOT NULL
);

