CREATE DATABASE PortafolioVento
GO

USE PortafolioVento
GO

CREATE TABLE Automovil(
	IdAutomovil INT PRIMARY KEY IDENTITY(1,1),
	Marca VARCHAR(50),
	Modelo VARCHAR(50),
	Color VARCHAR(50),
	Imagen VARBINARY(MAX)
)
GO

CREATE TABLE Proveedor(
	IdProveedor INT PRIMARY KEY IDENTITY(1,1),
	Nombre VARCHAR(50),
	Costo INT
)
GO

CREATE TABLE AutomovilProveedor(
	IdAutomovilProveedor INT PRIMARY KEY IDENTITY(1,1),
	IdAutomovil INT FOREIGN KEY REFERENCES Automovil(IdAutomovil),
	IdProveedor INT FOREIGN KEY REFERENCES Proveedor(IdProveedor)
)
GO

INSERT INTO Automovil (Marca, Modelo, Color, Imagen) VALUES ('Volkswagen' , 'Golf', 'Rojo', NULL)
GO
INSERT INTO Automovil (Marca, Modelo, Color, Imagen) VALUES ('Nissan' , 'Versa', 'Gris', NULL)
GO
INSERT INTO Automovil (Marca, Modelo, Color, Imagen) VALUES ('Volkswagen' , 'Polo', 'Gris', NULL)
GO
INSERT INTO Automovil (Marca, Modelo, Color, Imagen) VALUES ('Chevrolet' , 'Spark', 'Blanco', NULL)
GO

INSERT INTO Proveedor (Nombre, Costo) VALUES ('General Motors', 800)
GO
INSERT INTO Proveedor (Nombre, Costo) VALUES ('Volkswagen Group', 500)
GO
INSERT INTO Proveedor (Nombre, Costo) VALUES ('Nissan Motor', 650)
GO
INSERT INTO Proveedor (Nombre, Costo) VALUES ('BMW Group', 600)
GO
INSERT INTO Proveedor (Nombre, Costo) VALUES ('Honda Motor', 500)
GO

INSERT INTO AutomovilProveedor(IdAutomovil,IdProveedor) VALUES(1, 2)
GO
INSERT INTO AutomovilProveedor(IdAutomovil,IdProveedor) VALUES(2, 3)
GO
INSERT INTO AutomovilProveedor(IdAutomovil,IdProveedor) VALUES(3, 1)
GO
INSERT INTO AutomovilProveedor(IdAutomovil,IdProveedor) VALUES(4, 1)
GO
INSERT INTO AutomovilProveedor(IdAutomovil,IdProveedor) VALUES(1, 1)
GO
INSERT INTO AutomovilProveedor(IdAutomovil,IdProveedor) VALUES(2, 3)
GO
INSERT INTO AutomovilProveedor(IdAutomovil,IdProveedor) VALUES(3, 2)
GO
INSERT INTO AutomovilProveedor(IdAutomovil,IdProveedor) VALUES(4, 2)
GO

CREATE PROCEDURE AutomovilGetAll
AS
	SELECT
		IdAutomovil,
		Marca,
		Modelo,
		Color,
		Imagen
	FROM Automovil

GO

CREATE PROCEDURE AutomovilGetById
	@IdAutomovil INT
AS
	SELECT
		IdAutomovil,
		Marca,
		Modelo,
		Color,
		Imagen
	FROM Automovil
	WHERE IdAutomovil = @IdAutomovil

GO

CREATE PROCEDURE AutomovilAdd
	@Marca VARCHAR(50),
	@Modelo VARCHAR(50),
	@Color VARCHAR(50),
	@Imagen VARBINARY(MAX)
AS
	INSERT INTO Automovil
           (Marca,
           Modelo,
           Color,
		   Imagen)
     VALUES
           (@Marca,
           @Modelo,
           @Color,
		   @Imagen)

GO

CREATE PROCEDURE AutomovilUpdate
	@IdAutomovil INT,
	@Marca VARCHAR(50),
	@Modelo VARCHAR(50),
	@Color VARCHAR(50),
	@Imagen VARBINARY(MAX)
AS
	UPDATE Automovil
	   SET Marca = @Marca,
		  Modelo = @Modelo,
		  Color = @Color,
		  Imagen = @Imagen
	 WHERE IdAutomovil = @IdAutomovil

GO

CREATE PROCEDURE AutomovilDelete
	@IdAutomovil INT
AS
	DELETE FROM Automovil
      WHERE IdAutomovil = @IdAutomovil

GO

-- Proveedor --

CREATE PROCEDURE ProveedorGetAll
AS
	SELECT IdProveedor,
		Nombre,
		Costo
	FROM Proveedor

GO

CREATE PROCEDURE ProveedorGetById
	@IdProveedor INT
AS
	SELECT IdProveedor,
		Nombre,
		Costo
	FROM Proveedor
	WHERE IdProveedor = @IdProveedor

GO

CREATE PROCEDURE ProveedorAdd
	@Nombre VARCHAR(50),
	@Costo INT
AS
	INSERT INTO Proveedor
           (Nombre,
           Costo)
     VALUES
           (@Nombre,
           @Costo)
	
GO

CREATE PROCEDURE ProveedorUpdate
	@IdProveedor INT,
	@Nombre VARCHAR(50),
	@Costo INT
AS
	UPDATE Proveedor
	SET Nombre = @Nombre,
		Costo = @Costo
	WHERE IdProveedor = @IdProveedor

GO

CREATE PROCEDURE ProveedorDelete
	@IdProveedor INT
AS
	DELETE FROM Proveedor
      WHERE IdProveedor = @IdProveedor

GO

-- AutomovilProveedor --

CREATE PROCEDURE AutomovilProveedorAsignadaByAutomovilId
	@IdAutomovil INT
AS
SELECT
	IdAutomovilProveedor,
	Automovil.IdAutomovil,
	Proveedor.IdProveedor,
	Proveedor.Nombre
	FROM AutomovilProveedor
	INNER JOIN Automovil ON Automovil.IdAutomovil = AutomovilProveedor.IdAutomovil
	INNER JOIN Proveedor ON Proveedor.IdProveedor = AutomovilProveedor.IdProveedor
	WHERE AutomovilProveedor.IdAutomovil = @IdAutomovil

GO

CREATE PROCEDURE AutomovilProveedorNOAsignadaByAutomovilId
	@IdAutomovil INT
AS
	SELECT
		Proveedor.IdProveedor,
		Proveedor.Nombre
		FROM Proveedor
		WHERE Proveedor.IdProveedor NOT IN (
								SELECT
								IdAutomovilProveedor
								FROM AutomovilProveedor
								INNER JOIN Automovil ON Automovil.IdAutomovil = AutomovilProveedor.IdAutomovil
								INNER JOIN Proveedor ON Proveedor.IdProveedor = AutomovilProveedor.IdProveedor
								WHERE AutomovilProveedor.IdAutomovil = @IdAutomovil)

GO

CREATE PROCEDURE AutomovilProveedorAdd
	@IdAutomovil INT,
	@IdProveedor INT
AS
	INSERT INTO AutomovilProveedor(IdAutomovil,IdProveedor)
	VALUES(@IdAutomovil, @IdProveedor)
	
GO

CREATE PROCEDURE AutomovilProveedorDelete
	@AutomovilProveedor INT
AS
	DELETE FROM AutomovilProveedor
	WHERE IdAutomovilProveedor = @AutomovilProveedor
GO

