USE crud_database;

-- Tablas
CREATE TABLE Roles (
    idRol INT PRIMARY KEY,
    RolName VARCHAR(50) NOT NULL
);

CREATE TABLE Persona (
    idPersona INT PRIMARY KEY,
    Nombres VARCHAR(80) NOT NULL,
    Apellidos VARCHAR(60) NOT NULL,
    Identificacion VARCHAR(10) NOT NULL,
    FechaNacimiento DATE
);

CREATE TABLE Usuarios (
    idUsuario INT PRIMARY KEY,
    UserName VARCHAR(50) NOT NULL,
    Password VARCHAR(122) NOT NULL,
    Mail VARCHAR(100),
    SesionActiva CHAR(1) NOT NULL,
    idPersona INT NOT NULL,
	Status CHAR(20) NOT NULL,
    FOREIGN KEY (idPersona) REFERENCES Persona(idPersona)
);

CREATE TABLE Sesiones (
    FechaIngreso DATE NOT NULL,
    FechaCierre DATE,
    idUsuario INT NOT NULL,
    FOREIGN KEY (idUsuario) REFERENCES Usuarios(idUsuario)
);

CREATE TABLE Rol_Usuarios (
    idRol INT NOT NULL,
    idUsuario INT NOT NULL,
    PRIMARY KEY (idRol, idUsuario),
    FOREIGN KEY (idRol) REFERENCES Roles(idRol),
    FOREIGN KEY (idUsuario) REFERENCES Usuarios(idUsuario)
);

CREATE TABLE RolOpciones (
    idOpcion INT PRIMARY KEY,
    NombreOpcion VARCHAR(50) NOT NULL
);

CREATE TABLE Rol_RolOpciones (
    Rol_idRol INT NOT NULL,
    RolOpciones_idOpciones INT NOT NULL,
    FOREIGN KEY (Rol_idRol) REFERENCES Roles(idRol),
	FOREIGN KEY (RolOpciones_idOpciones) REFERENCES RolOpciones(idOpcion)
);

GO

-- Stored Procedures
CREATE PROCEDURE InsertarPersona
    @idPersona INT,
    @Nombres VARCHAR(80),
    @Apellidos VARCHAR(60),
    @Identificacion VARCHAR(10),
    @FechaNacimiento DATE
AS
BEGIN
    INSERT INTO Persona (idPersona, Nombres, Apellidos, Identificacion, FechaNacimiento)
    VALUES (@idPersona, @Nombres, @Apellidos, @Identificacion, @FechaNacimiento);
END;

GO

CREATE PROCEDURE InsertarUsuario
    @idUsuario INT,
    @UserName VARCHAR(50),
    @Password VARCHAR(122),
    @Mail VARCHAR(100),
    @SesionActiva CHAR(1),
    @idPersona INT
AS
BEGIN
    INSERT INTO Usuarios (idUsuario, UserName, Password, Mail, SesionActiva, idPersona)
    VALUES (@idUsuario, @UserName, @Password, @Mail, @SesionActiva, @idPersona);
END;

GO

CREATE PROCEDURE InsertarRol
    @idRol INT,
    @RolName VARCHAR(50)
AS
BEGIN
    INSERT INTO Roles (idRol, RolName)
    VALUES (@idRol, @RolName);
END;

GO

CREATE PROCEDURE InsertarRolUsuario
    @idRol INT,
    @idUsuario INT
AS
BEGIN
    INSERT INTO Rol_Usuarios (idRol, idUsuario)
    VALUES (@idRol, @idUsuario);
END;

GO

CREATE PROCEDURE InsertarOpcion
    @idOpcion INT,
    @NombreOpcion VARCHAR(50)
AS
BEGIN
    INSERT INTO RolOpciones (idOpcion, NombreOpcion)
    VALUES (@idOpcion, @NombreOpcion);
END;

GO

CREATE PROCEDURE InsertarRolOpcion
    @idRol INT,
    @idOpcion INT
AS
BEGIN
    INSERT INTO Rol_RolOpciones (Rol_idRol, RolOpciones_idOpciones)
    VALUES (@idRol, @idOpcion);
END;

GO

CREATE PROCEDURE InsertarSesion
    @FechaIngreso DATE,
    @FechaCierre DATE,
    @idUsuario INT
AS
BEGIN
    INSERT INTO Sesiones (FechaIngreso, FechaCierre, idUsuario)
    VALUES (@FechaIngreso, @FechaCierre, @idUsuario);
END;
