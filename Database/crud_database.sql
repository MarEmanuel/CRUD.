USE [master]
GO
/****** Object:  Database [crud_database]    Script Date: 9/3/2025 22:08:27 ******/
CREATE DATABASE [crud_database]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'crud_database', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\crud_database.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'crud_database_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.MSSQLSERVER\MSSQL\DATA\crud_database_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [crud_database] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [crud_database].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [crud_database] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [crud_database] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [crud_database] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [crud_database] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [crud_database] SET ARITHABORT OFF 
GO
ALTER DATABASE [crud_database] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [crud_database] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [crud_database] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [crud_database] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [crud_database] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [crud_database] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [crud_database] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [crud_database] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [crud_database] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [crud_database] SET  ENABLE_BROKER 
GO
ALTER DATABASE [crud_database] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [crud_database] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [crud_database] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [crud_database] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [crud_database] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [crud_database] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [crud_database] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [crud_database] SET RECOVERY FULL 
GO
ALTER DATABASE [crud_database] SET  MULTI_USER 
GO
ALTER DATABASE [crud_database] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [crud_database] SET DB_CHAINING OFF 
GO
ALTER DATABASE [crud_database] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [crud_database] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [crud_database] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [crud_database] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'crud_database', N'ON'
GO
ALTER DATABASE [crud_database] SET QUERY_STORE = ON
GO
ALTER DATABASE [crud_database] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [crud_database]
GO
/****** Object:  Table [dbo].[Permisos]    Script Date: 9/3/2025 22:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Permisos](
	[idPermiso] [int] IDENTITY(1,1) NOT NULL,
	[NombrePermiso] [varchar](50) NOT NULL,
	[DescripcionPermiso] [varchar](100) NOT NULL,
	[IconoPermiso] [varchar](20) NULL,
	[RutaPermiso] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[idPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Persona]    Script Date: 9/3/2025 22:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Persona](
	[idPersona] [int] IDENTITY(1,1) NOT NULL,
	[NombresPersona] [varchar](80) NOT NULL,
	[ApellidosPersona] [varchar](60) NOT NULL,
	[Identificacion] [varchar](10) NOT NULL,
	[Genero] [varchar](1) NOT NULL,
	[FechaNacimiento] [date] NOT NULL,
	[EstadoPersona] [char](1) NOT NULL,
	[EsActivo] [char](1) NOT NULL,
	[FechaCreacion] [date] NULL,
	[FechaEdicion] [date] NULL,
	[FechaEliminacion] [date] NULL,
	[UsuarioCreacion] [int] NULL,
	[UsuarioEdicion] [int] NULL,
	[UsuarioEliminacion] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idPersona] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Rol_Permiso]    Script Date: 9/3/2025 22:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Rol_Permiso](
	[idRolPermiso] [int] IDENTITY(1,1) NOT NULL,
	[idRol] [int] NOT NULL,
	[idPermiso] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idRolPermiso] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 9/3/2025 22:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[idRol] [int] IDENTITY(1,1) NOT NULL,
	[NombreRol] [varchar](50) NOT NULL,
	[DescripcionRol] [varchar](100) NOT NULL,
	[EstadoRol] [char](1) NOT NULL,
	[EsActivo] [char](1) NOT NULL,
	[FechaCreacion] [date] NULL,
	[FechaEdicion] [date] NULL,
	[FechaEliminacion] [date] NULL,
	[UsuarioCreacion] [int] NULL,
	[UsuarioEdicion] [int] NULL,
	[UsuarioEliminacion] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idRol] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sesiones]    Script Date: 9/3/2025 22:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sesiones](
	[idSesion] [int] IDENTITY(1,1) NOT NULL,
	[idUsuario] [int] NOT NULL,
	[FechaIngreso] [datetime] NULL,
	[FechaEgreso] [datetime] NULL,
	[SesionActiva] [char](1) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[idSesion] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 9/3/2025 22:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuarios](
	[idUsuario] [int] IDENTITY(1,1) NOT NULL,
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](20) NOT NULL,
	[Mail] [varchar](100) NOT NULL,
	[idPersona] [int] NOT NULL,
	[EstadoUsuario] [char](1) NOT NULL,
	[EsActivo] [char](1) NOT NULL,
	[FechaCreacion] [date] NULL,
	[FechaEdicion] [date] NULL,
	[FechaEliminacion] [date] NULL,
	[UsuarioCreacion] [int] NULL,
	[UsuarioEdicion] [int] NULL,
	[UsuarioEliminacion] [int] NULL,
	[idRol] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[idUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Permisos] ON 

INSERT [dbo].[Permisos] ([idPermiso], [NombrePermiso], [DescripcionPermiso], [IconoPermiso], [RutaPermiso]) VALUES (6, N'Dashboard', N'Para visualización del dashboard de administradores.', N'dashboard', N'administrador/dashboard')
INSERT [dbo].[Permisos] ([idPermiso], [NombrePermiso], [DescripcionPermiso], [IconoPermiso], [RutaPermiso]) VALUES (7, N'Usuarios', N'Para visualización de los usuarios existentes.', N'people', N'administrador/usuarios-registrados')
INSERT [dbo].[Permisos] ([idPermiso], [NombrePermiso], [DescripcionPermiso], [IconoPermiso], [RutaPermiso]) VALUES (8, N'Personas', N'Para visualización de las personas existentes.', N'people_alt', N'administrador/personas-registradas')
INSERT [dbo].[Permisos] ([idPermiso], [NombrePermiso], [DescripcionPermiso], [IconoPermiso], [RutaPermiso]) VALUES (9, N'Roles', N'Para visualización de los roles existentes.', N'lock_person', N'administrador/roles-registrados')
INSERT [dbo].[Permisos] ([idPermiso], [NombrePermiso], [DescripcionPermiso], [IconoPermiso], [RutaPermiso]) VALUES (10, N'Mi Usuario', N'Para visualización de los datos de la cuenta del usuario.', N'person', N'mi-usuario')
SET IDENTITY_INSERT [dbo].[Permisos] OFF
GO
SET IDENTITY_INSERT [dbo].[Persona] ON 

INSERT [dbo].[Persona] ([idPersona], [NombresPersona], [ApellidosPersona], [Identificacion], [Genero], [FechaNacimiento], [EstadoPersona], [EsActivo], [FechaCreacion], [FechaEdicion], [FechaEliminacion], [UsuarioCreacion], [UsuarioEdicion], [UsuarioEliminacion]) VALUES (1, N'Leonel David', N'Gómez', N'1', N'M', CAST(N'1990-01-01' AS Date), N'A', N'A', CAST(N'2025-02-04' AS Date), CAST(N'2025-03-03' AS Date), NULL, NULL, NULL, NULL)
INSERT [dbo].[Persona] ([idPersona], [NombresPersona], [ApellidosPersona], [Identificacion], [Genero], [FechaNacimiento], [EstadoPersona], [EsActivo], [FechaCreacion], [FechaEdicion], [FechaEliminacion], [UsuarioCreacion], [UsuarioEdicion], [UsuarioEliminacion]) VALUES (2, N'María', N'Gómez', N'0987654321', N'F', CAST(N'1985-05-15' AS Date), N'A', N'A', CAST(N'2025-02-04' AS Date), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Persona] ([idPersona], [NombresPersona], [ApellidosPersona], [Identificacion], [Genero], [FechaNacimiento], [EstadoPersona], [EsActivo], [FechaCreacion], [FechaEdicion], [FechaEliminacion], [UsuarioCreacion], [UsuarioEdicion], [UsuarioEliminacion]) VALUES (3, N'Luis', N'Rodríguez', N'1122334455', N'M', CAST(N'1992-08-20' AS Date), N'A', N'A', CAST(N'2025-02-04' AS Date), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Persona] ([idPersona], [NombresPersona], [ApellidosPersona], [Identificacion], [Genero], [FechaNacimiento], [EstadoPersona], [EsActivo], [FechaCreacion], [FechaEdicion], [FechaEliminacion], [UsuarioCreacion], [UsuarioEdicion], [UsuarioEliminacion]) VALUES (4, N'Ana', N'Fernández', N'2233445566', N'F', CAST(N'1988-12-10' AS Date), N'A', N'A', CAST(N'2025-02-04' AS Date), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Persona] ([idPersona], [NombresPersona], [ApellidosPersona], [Identificacion], [Genero], [FechaNacimiento], [EstadoPersona], [EsActivo], [FechaCreacion], [FechaEdicion], [FechaEliminacion], [UsuarioCreacion], [UsuarioEdicion], [UsuarioEliminacion]) VALUES (5, N'Angie', N'Alvarado', N'0946412221', N'F', CAST(N'1995-03-30' AS Date), N'A', N'A', CAST(N'2025-02-04' AS Date), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Persona] ([idPersona], [NombresPersona], [ApellidosPersona], [Identificacion], [Genero], [FechaNacimiento], [EstadoPersona], [EsActivo], [FechaCreacion], [FechaEdicion], [FechaEliminacion], [UsuarioCreacion], [UsuarioEdicion], [UsuarioEliminacion]) VALUES (10, N'Antonio', N'Banderas', N'10', N'M', CAST(N'2015-03-12' AS Date), N'A', N'I', CAST(N'2025-02-05' AS Date), CAST(N'2025-02-05' AS Date), CAST(N'2025-02-05' AS Date), NULL, NULL, NULL)
INSERT [dbo].[Persona] ([idPersona], [NombresPersona], [ApellidosPersona], [Identificacion], [Genero], [FechaNacimiento], [EstadoPersona], [EsActivo], [FechaCreacion], [FechaEdicion], [FechaEliminacion], [UsuarioCreacion], [UsuarioEdicion], [UsuarioEliminacion]) VALUES (11, N'Alejandra', N'Pacheco', N'0954322112', N'F', CAST(N'2003-03-01' AS Date), N'A', N'A', CAST(N'2025-02-28' AS Date), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Persona] ([idPersona], [NombresPersona], [ApellidosPersona], [Identificacion], [Genero], [FechaNacimiento], [EstadoPersona], [EsActivo], [FechaCreacion], [FechaEdicion], [FechaEliminacion], [UsuarioCreacion], [UsuarioEdicion], [UsuarioEliminacion]) VALUES (12, N'Lucrecia', N'Álvarez', N'0964322557', N'F', CAST(N'1990-12-12' AS Date), N'A', N'A', CAST(N'2025-02-28' AS Date), NULL, NULL, NULL, NULL, NULL)
INSERT [dbo].[Persona] ([idPersona], [NombresPersona], [ApellidosPersona], [Identificacion], [Genero], [FechaNacimiento], [EstadoPersona], [EsActivo], [FechaCreacion], [FechaEdicion], [FechaEliminacion], [UsuarioCreacion], [UsuarioEdicion], [UsuarioEliminacion]) VALUES (18, N'Aureliano', N'Buendía', N'0951321012', N'M', CAST(N'2025-01-10' AS Date), N'A', N'A', CAST(N'2025-03-08' AS Date), NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Persona] OFF
GO
SET IDENTITY_INSERT [dbo].[Rol_Permiso] ON 

INSERT [dbo].[Rol_Permiso] ([idRolPermiso], [idRol], [idPermiso]) VALUES (13, 2, 6)
INSERT [dbo].[Rol_Permiso] ([idRolPermiso], [idRol], [idPermiso]) VALUES (14, 2, 7)
INSERT [dbo].[Rol_Permiso] ([idRolPermiso], [idRol], [idPermiso]) VALUES (15, 2, 8)
INSERT [dbo].[Rol_Permiso] ([idRolPermiso], [idRol], [idPermiso]) VALUES (16, 2, 9)
INSERT [dbo].[Rol_Permiso] ([idRolPermiso], [idRol], [idPermiso]) VALUES (17, 2, 10)
INSERT [dbo].[Rol_Permiso] ([idRolPermiso], [idRol], [idPermiso]) VALUES (18, 1, 10)
SET IDENTITY_INSERT [dbo].[Rol_Permiso] OFF
GO
SET IDENTITY_INSERT [dbo].[Roles] ON 

INSERT [dbo].[Roles] ([idRol], [NombreRol], [DescripcionRol], [EstadoRol], [EsActivo], [FechaCreacion], [FechaEdicion], [FechaEliminacion], [UsuarioCreacion], [UsuarioEdicion], [UsuarioEliminacion]) VALUES (1, N'Usuario', N'Para usuarios con permisos necesarios.', N'A', N'A', CAST(N'2025-02-04' AS Date), CAST(N'2025-02-05' AS Date), NULL, NULL, NULL, NULL)
INSERT [dbo].[Roles] ([idRol], [NombreRol], [DescripcionRol], [EstadoRol], [EsActivo], [FechaCreacion], [FechaEdicion], [FechaEliminacion], [UsuarioCreacion], [UsuarioEdicion], [UsuarioEliminacion]) VALUES (2, N'Administrador', N'Para los administradores del sistema.', N'A', N'A', CAST(N'2025-02-04' AS Date), NULL, NULL, NULL, NULL, NULL)
SET IDENTITY_INSERT [dbo].[Roles] OFF
GO
SET IDENTITY_INSERT [dbo].[Sesiones] ON 

INSERT [dbo].[Sesiones] ([idSesion], [idUsuario], [FechaIngreso], [FechaEgreso], [SesionActiva]) VALUES (1, 1, CAST(N'2025-02-28T18:25:49.757' AS DateTime), CAST(N'2025-02-28T18:34:10.230' AS DateTime), N'I')
INSERT [dbo].[Sesiones] ([idSesion], [idUsuario], [FechaIngreso], [FechaEgreso], [SesionActiva]) VALUES (2, 1, CAST(N'2025-02-28T18:31:25.437' AS DateTime), NULL, N'A')
INSERT [dbo].[Sesiones] ([idSesion], [idUsuario], [FechaIngreso], [FechaEgreso], [SesionActiva]) VALUES (3, 1, CAST(N'2025-02-28T18:31:29.263' AS DateTime), NULL, N'A')
INSERT [dbo].[Sesiones] ([idSesion], [idUsuario], [FechaIngreso], [FechaEgreso], [SesionActiva]) VALUES (4, 2, CAST(N'2025-03-01T16:57:35.517' AS DateTime), CAST(N'2025-03-01T17:01:20.690' AS DateTime), N'I')
INSERT [dbo].[Sesiones] ([idSesion], [idUsuario], [FechaIngreso], [FechaEgreso], [SesionActiva]) VALUES (6, 2, CAST(N'2025-03-01T17:18:20.160' AS DateTime), CAST(N'2025-03-01T17:18:51.593' AS DateTime), N'I')
INSERT [dbo].[Sesiones] ([idSesion], [idUsuario], [FechaIngreso], [FechaEgreso], [SesionActiva]) VALUES (7, 1, CAST(N'2025-03-08T21:36:38.383' AS DateTime), NULL, N'A')
INSERT [dbo].[Sesiones] ([idSesion], [idUsuario], [FechaIngreso], [FechaEgreso], [SesionActiva]) VALUES (8, 1, CAST(N'2025-03-08T21:39:46.893' AS DateTime), NULL, N'A')
INSERT [dbo].[Sesiones] ([idSesion], [idUsuario], [FechaIngreso], [FechaEgreso], [SesionActiva]) VALUES (9, 1, CAST(N'2025-03-08T21:42:13.200' AS DateTime), NULL, N'A')
INSERT [dbo].[Sesiones] ([idSesion], [idUsuario], [FechaIngreso], [FechaEgreso], [SesionActiva]) VALUES (64, 1, CAST(N'2025-03-09T21:01:55.707' AS DateTime), CAST(N'2025-03-09T21:15:54.793' AS DateTime), N'I')
INSERT [dbo].[Sesiones] ([idSesion], [idUsuario], [FechaIngreso], [FechaEgreso], [SesionActiva]) VALUES (65, 1, CAST(N'2025-03-09T21:03:42.717' AS DateTime), NULL, N'A')
INSERT [dbo].[Sesiones] ([idSesion], [idUsuario], [FechaIngreso], [FechaEgreso], [SesionActiva]) VALUES (66, 1, CAST(N'2025-03-09T21:04:01.127' AS DateTime), NULL, N'A')
INSERT [dbo].[Sesiones] ([idSesion], [idUsuario], [FechaIngreso], [FechaEgreso], [SesionActiva]) VALUES (67, 1, CAST(N'2025-03-09T21:04:10.660' AS DateTime), NULL, N'A')
INSERT [dbo].[Sesiones] ([idSesion], [idUsuario], [FechaIngreso], [FechaEgreso], [SesionActiva]) VALUES (68, 1, CAST(N'2025-03-09T21:07:26.387' AS DateTime), NULL, N'A')
INSERT [dbo].[Sesiones] ([idSesion], [idUsuario], [FechaIngreso], [FechaEgreso], [SesionActiva]) VALUES (69, 1, CAST(N'2025-03-09T21:09:54.030' AS DateTime), NULL, N'A')
INSERT [dbo].[Sesiones] ([idSesion], [idUsuario], [FechaIngreso], [FechaEgreso], [SesionActiva]) VALUES (70, 1, CAST(N'2025-03-09T21:22:18.637' AS DateTime), NULL, N'A')
INSERT [dbo].[Sesiones] ([idSesion], [idUsuario], [FechaIngreso], [FechaEgreso], [SesionActiva]) VALUES (71, 1, CAST(N'2025-03-09T21:30:10.577' AS DateTime), NULL, N'A')
INSERT [dbo].[Sesiones] ([idSesion], [idUsuario], [FechaIngreso], [FechaEgreso], [SesionActiva]) VALUES (72, 1, CAST(N'2025-03-09T21:33:09.703' AS DateTime), NULL, N'A')
INSERT [dbo].[Sesiones] ([idSesion], [idUsuario], [FechaIngreso], [FechaEgreso], [SesionActiva]) VALUES (73, 1, CAST(N'2025-03-09T21:34:21.533' AS DateTime), NULL, N'A')
INSERT [dbo].[Sesiones] ([idSesion], [idUsuario], [FechaIngreso], [FechaEgreso], [SesionActiva]) VALUES (74, 1, CAST(N'2025-03-09T21:34:40.543' AS DateTime), CAST(N'2025-03-09T21:36:31.030' AS DateTime), N'I')
INSERT [dbo].[Sesiones] ([idSesion], [idUsuario], [FechaIngreso], [FechaEgreso], [SesionActiva]) VALUES (75, 1, CAST(N'2025-03-09T21:37:11.377' AS DateTime), NULL, N'A')
INSERT [dbo].[Sesiones] ([idSesion], [idUsuario], [FechaIngreso], [FechaEgreso], [SesionActiva]) VALUES (76, 1, CAST(N'2025-03-09T21:39:34.747' AS DateTime), NULL, N'A')
INSERT [dbo].[Sesiones] ([idSesion], [idUsuario], [FechaIngreso], [FechaEgreso], [SesionActiva]) VALUES (77, 1, CAST(N'2025-03-09T21:41:25.333' AS DateTime), NULL, N'A')
INSERT [dbo].[Sesiones] ([idSesion], [idUsuario], [FechaIngreso], [FechaEgreso], [SesionActiva]) VALUES (78, 1, CAST(N'2025-03-09T21:43:17.253' AS DateTime), CAST(N'2025-03-09T21:47:14.583' AS DateTime), N'I')
INSERT [dbo].[Sesiones] ([idSesion], [idUsuario], [FechaIngreso], [FechaEgreso], [SesionActiva]) VALUES (79, 1, CAST(N'2025-03-09T21:47:28.797' AS DateTime), CAST(N'2025-03-09T21:47:31.717' AS DateTime), N'I')
INSERT [dbo].[Sesiones] ([idSesion], [idUsuario], [FechaIngreso], [FechaEgreso], [SesionActiva]) VALUES (80, 1, CAST(N'2025-03-09T21:52:42.020' AS DateTime), CAST(N'2025-03-09T21:52:44.403' AS DateTime), N'I')
INSERT [dbo].[Sesiones] ([idSesion], [idUsuario], [FechaIngreso], [FechaEgreso], [SesionActiva]) VALUES (81, 2, CAST(N'2025-03-09T21:53:05.113' AS DateTime), CAST(N'2025-03-09T21:53:14.903' AS DateTime), N'I')
INSERT [dbo].[Sesiones] ([idSesion], [idUsuario], [FechaIngreso], [FechaEgreso], [SesionActiva]) VALUES (82, 1, CAST(N'2025-03-09T21:54:57.690' AS DateTime), CAST(N'2025-03-09T21:56:52.917' AS DateTime), N'I')
INSERT [dbo].[Sesiones] ([idSesion], [idUsuario], [FechaIngreso], [FechaEgreso], [SesionActiva]) VALUES (83, 1, CAST(N'2025-03-09T21:57:01.087' AS DateTime), CAST(N'2025-03-09T21:57:03.957' AS DateTime), N'I')
INSERT [dbo].[Sesiones] ([idSesion], [idUsuario], [FechaIngreso], [FechaEgreso], [SesionActiva]) VALUES (84, 1, CAST(N'2025-03-09T21:59:35.900' AS DateTime), CAST(N'2025-03-09T22:01:06.570' AS DateTime), N'I')
INSERT [dbo].[Sesiones] ([idSesion], [idUsuario], [FechaIngreso], [FechaEgreso], [SesionActiva]) VALUES (85, 1, CAST(N'2025-03-09T22:02:48.310' AS DateTime), NULL, N'A')
INSERT [dbo].[Sesiones] ([idSesion], [idUsuario], [FechaIngreso], [FechaEgreso], [SesionActiva]) VALUES (86, 1, CAST(N'2025-03-09T22:06:01.480' AS DateTime), CAST(N'2025-03-09T22:07:18.890' AS DateTime), N'I')
INSERT [dbo].[Sesiones] ([idSesion], [idUsuario], [FechaIngreso], [FechaEgreso], [SesionActiva]) VALUES (87, 2, CAST(N'2025-03-09T22:07:34.283' AS DateTime), CAST(N'2025-03-09T22:07:35.467' AS DateTime), N'I')
SET IDENTITY_INSERT [dbo].[Sesiones] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuarios] ON 

INSERT [dbo].[Usuarios] ([idUsuario], [Username], [Password], [Mail], [idPersona], [EstadoUsuario], [EsActivo], [FechaCreacion], [FechaEdicion], [FechaEliminacion], [UsuarioCreacion], [UsuarioEdicion], [UsuarioEliminacion], [idRol]) VALUES (1, N'juanito_123', N'123456789', N'juanito@gmail.com', 1, N'A', N'A', CAST(N'2025-02-05' AS Date), CAST(N'2025-02-27' AS Date), NULL, NULL, NULL, NULL, 2)
INSERT [dbo].[Usuarios] ([idUsuario], [Username], [Password], [Mail], [idPersona], [EstadoUsuario], [EsActivo], [FechaCreacion], [FechaEdicion], [FechaEliminacion], [UsuarioCreacion], [UsuarioEdicion], [UsuarioEliminacion], [idRol]) VALUES (2, N'maria_g_321', N'mochiladedora', N'mariabebe@gmail.com', 2, N'I', N'A', CAST(N'2025-02-05' AS Date), NULL, NULL, NULL, NULL, NULL, 1)
INSERT [dbo].[Usuarios] ([idUsuario], [Username], [Password], [Mail], [idPersona], [EstadoUsuario], [EsActivo], [FechaCreacion], [FechaEdicion], [FechaEliminacion], [UsuarioCreacion], [UsuarioEdicion], [UsuarioEliminacion], [idRol]) VALUES (9, N'Aurelian0', N'Marcosaureliano@10', N'abuendía@mail.com', 18, N'A', N'A', CAST(N'2025-03-08' AS Date), NULL, NULL, NULL, NULL, NULL, 1)
SET IDENTITY_INSERT [dbo].[Usuarios] OFF
GO
ALTER TABLE [dbo].[Persona] ADD  DEFAULT ('A') FOR [EstadoPersona]
GO
ALTER TABLE [dbo].[Persona] ADD  DEFAULT ('A') FOR [EsActivo]
GO
ALTER TABLE [dbo].[Roles] ADD  DEFAULT ('A') FOR [EstadoRol]
GO
ALTER TABLE [dbo].[Roles] ADD  DEFAULT ('A') FOR [EsActivo]
GO
ALTER TABLE [dbo].[Sesiones] ADD  DEFAULT ('A') FOR [SesionActiva]
GO
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT ('A') FOR [EstadoUsuario]
GO
ALTER TABLE [dbo].[Usuarios] ADD  DEFAULT ('A') FOR [EsActivo]
GO
ALTER TABLE [dbo].[Rol_Permiso]  WITH CHECK ADD  CONSTRAINT [FK_Permiso] FOREIGN KEY([idPermiso])
REFERENCES [dbo].[Permisos] ([idPermiso])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Rol_Permiso] CHECK CONSTRAINT [FK_Permiso]
GO
ALTER TABLE [dbo].[Rol_Permiso]  WITH CHECK ADD  CONSTRAINT [FK_Rol] FOREIGN KEY([idRol])
REFERENCES [dbo].[Roles] ([idRol])
ON UPDATE CASCADE
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Rol_Permiso] CHECK CONSTRAINT [FK_Rol]
GO
ALTER TABLE [dbo].[Sesiones]  WITH CHECK ADD FOREIGN KEY([idUsuario])
REFERENCES [dbo].[Usuarios] ([idUsuario])
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD FOREIGN KEY([idPersona])
REFERENCES [dbo].[Persona] ([idPersona])
GO
ALTER TABLE [dbo].[Usuarios]  WITH CHECK ADD  CONSTRAINT [FK_Usuarios_Roles] FOREIGN KEY([idRol])
REFERENCES [dbo].[Roles] ([idRol])
GO
ALTER TABLE [dbo].[Usuarios] CHECK CONSTRAINT [FK_Usuarios_Roles]
GO
/****** Object:  StoredProcedure [dbo].[DatosDashboardAdmin]    Script Date: 9/3/2025 22:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DatosDashboardAdmin]
AS
BEGIN
	 SELECT
        (SELECT COUNT(*) FROM Usuarios) AS TotalUsuarios,
		(SELECT COUNT(*) FROM Usuarios WHERE EstadoUsuario = 'A') AS UsuariosActivos,
		(SELECT COUNT(*) FROM Usuarios WHERE EstadoUsuario = 'I') AS UsuariosInactivos,
        (SELECT COUNT(*) FROM Roles) AS TotalRoles,
		(SELECT COUNT(*) FROM Roles WHERE EstadoRol = 'A') AS RolesActivos,
		(SELECT COUNT(*) FROM Roles WHERE EstadoRol = 'I') AS RolesInactivos,
        (SELECT COUNT(*) FROM Persona) AS TotalPersonas,
		(SELECT COUNT(*) FROM Persona WHERE EstadoPersona = 'A') AS PersonasActivas,
		(SELECT COUNT(*) FROM Persona WHERE EstadoPersona = 'I') AS PersonasInactivas
END;
GO
/****** Object:  StoredProcedure [dbo].[EditarPersona]    Script Date: 9/3/2025 22:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditarPersona]
	@PersonId INT,
	@PersonName VARCHAR(80),
	@PersonLastName VARCHAR(60),
	@PersonIdentification VARCHAR(10),
	@PersonGender VARCHAR(1),
	@PersonBirthDate DATE,
	@PersonStatus VARCHAR(1)
AS
BEGIN
	UPDATE
		Persona 
	SET 
		NombresPersona = @PersonName,
		ApellidosPersona = @PersonLastName,
		Identificacion = @PersonIdentification,
		Genero = @PersonGender,
		FechaNacimiento = @PersonBirthDate,
		EstadoPersona = @PersonStatus,
		FechaEdicion = GETDATE()
	WHERE
		idPersona = @PersonId
END;
GO
/****** Object:  StoredProcedure [dbo].[EditarRol]    Script Date: 9/3/2025 22:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditarRol]
	@RolId INT,
	@RolName VARCHAR(50),
	@DescripcionRol VARCHAR(100),
	@EstadoRol VARCHAR(1)
AS
BEGIN
	UPDATE
		Roles 
	SET 
		NombreRol = @RolName,
		DescripcionRol = @DescripcionRol,
		EstadoRol = @EstadoRol,
		FechaEdicion = GETDATE()
	WHERE
		idRol = @RolId
END;
GO
/****** Object:  StoredProcedure [dbo].[EditarUsuario]    Script Date: 9/3/2025 22:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EditarUsuario]
	@UserID INT,
	@UserUsername VARCHAR(50),
	@UserPassword VARCHAR(20),
	@UserMail VARCHAR(100),
	@PersonID INT,
	@UserRole INT,
	@UserStatus VARCHAR(1)
AS
BEGIN
	UPDATE
		Usuarios 
	SET 
		Username = @UserUsername,
		Password = @UserPassword,
		Mail = @UserMail,
		idPersona = @PersonID,
		idRol = @UserRole,
		EstadoUsuario = @UserStatus,
		FechaEdicion = GETDATE()
	WHERE
		idUsuario = @UserID
END;
GO
/****** Object:  StoredProcedure [dbo].[EliminarPersona]    Script Date: 9/3/2025 22:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarPersona]
	@PersonIdentification INT
AS
BEGIN
	UPDATE
		Persona 
	SET 
		EsActivo = 'I',
		FechaEliminacion = GETDATE()
	WHERE
		idPersona = @PersonIdentification
END;
GO
/****** Object:  StoredProcedure [dbo].[EliminarRol]    Script Date: 9/3/2025 22:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarRol]
	@RolId INT
AS
BEGIN
	UPDATE
		Roles 
	SET 
		EsActivo = 'I',
		FechaEliminacion = GETDATE()
	WHERE
		idRol = @RolId
END;
GO
/****** Object:  StoredProcedure [dbo].[EliminarUsuario]    Script Date: 9/3/2025 22:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[EliminarUsuario]
	@UserID INT
AS
BEGIN
	UPDATE
		Usuarios 
	SET 
		EsActivo = 'I',
		FechaEliminacion = GETDATE()
	WHERE
		idUsuario = @UserID
END;
GO
/****** Object:  StoredProcedure [dbo].[GuardarSesionActiva]    Script Date: 9/3/2025 22:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GuardarSesionActiva]
    @UserID INT
AS
BEGIN
    INSERT INTO Sesiones (idUsuario, FechaIngreso)
    VALUES (@UserID, GETDATE());
END;
GO
/****** Object:  StoredProcedure [dbo].[GuardarSesionInactiva]    Script Date: 9/3/2025 22:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GuardarSesionInactiva]
	@SessionID INT,
    @UserID INT
AS
BEGIN
    UPDATE
		Sesiones 
	SET
		FechaEgreso = GETDATE(),
		SesionActiva = 'I'
	WHERE
		idSesion = @SessionID AND
		idUsuario = @UserID;
END;
GO
/****** Object:  StoredProcedure [dbo].[IniciarSesion]    Script Date: 9/3/2025 22:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[IniciarSesion]
    @Username VARCHAR(100),
    @Password VARCHAR(100)
AS
BEGIN
    DECLARE @UserID INT;
    DECLARE @PasswordInDB VARCHAR(100);
    DECLARE @IsPasswordValid BIT;
    DECLARE @IdRol INT;
    DECLARE @RoleName VARCHAR(100);
    DECLARE @SessionID INT;

    SELECT @UserID = u.idUsuario, 
           @PasswordInDB = u.Password,
           @IdRol = r.idRol,
           @RoleName = r.NombreRol
    FROM Usuarios u
    INNER JOIN Roles r ON u.IdRol = r.idRol
    WHERE u.Username = @Username;

    IF @UserID IS NULL
    BEGIN
        SELECT 
            NULL AS UserID,
            NULL AS IdRol,
            NULL AS RoleName,
            NULL AS SessionID,
            'Usuario no encontrado.' AS Message;
        RETURN;
    END

    IF @PasswordInDB <> @Password
    BEGIN
        SELECT 
            NULL AS UserID,
            NULL AS IdRol,
            NULL AS RoleName,
            NULL AS SessionID,
            'Contraseña incorrecta.' AS Message;
        RETURN;
    END

    EXEC GuardarSesionActiva @UserID;

    SELECT TOP 1 @SessionID = s.idSesion
    FROM Sesiones s
    WHERE s.idUsuario = @UserID AND s.SesionActiva = 'A'
    ORDER BY s.FechaIngreso DESC;

    SELECT 
        @UserID AS UserID,
        @IdRol AS RoleID,
        @RoleName AS RoleName,
        @SessionID AS SessionID,
        'Inicio de sesión exitoso.' AS Message;
END;
GO
/****** Object:  StoredProcedure [dbo].[InsertarPermiso]    Script Date: 9/3/2025 22:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarPermiso]
    @PermissionName VARCHAR(50),
	@PermissionDescription VARCHAR(100),
	@PermissionIcon VARCHAR(20)
AS
BEGIN
    INSERT INTO Permisos (NombrePermiso, DescripcionPermiso, IconoPermiso)
    VALUES (@PermissionName, @PermissionDescription, @PermissionIcon);
END;
GO
/****** Object:  StoredProcedure [dbo].[InsertarPermisoDeRol]    Script Date: 9/3/2025 22:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarPermisoDeRol]
    @IDRol INT,
	@IDPermiso INT
AS
BEGIN
    INSERT INTO Rol_Permiso (idRol, idPermiso)
    VALUES (@IDRol, @IDPermiso);
END;
GO
/****** Object:  StoredProcedure [dbo].[InsertarPersona]    Script Date: 9/3/2025 22:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarPersona]
    @PersonName VARCHAR(80),
	@PersonLastName VARCHAR(60),
	@PersonID VARCHAR(10),
	@PersonGender VARCHAR(1),
	@PersonBirthDate DATE,
	@PersonStatus VARCHAR(1)
AS
BEGIN
    INSERT INTO Persona (NombresPersona, ApellidosPersona, Identificacion, Genero, FechaNacimiento, EstadoPersona, FechaCreacion)
    VALUES (@PersonName, @PersonLastName, @PersonID, @PersonGender, @PersonBirthDate, @PersonStatus, GETDATE());
END;
GO
/****** Object:  StoredProcedure [dbo].[InsertarRol]    Script Date: 9/3/2025 22:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarRol]
    @RolName VARCHAR(50),
	@RolDescription VARCHAR(100),
	@RolStatus VARCHAR(1)
AS
BEGIN
    INSERT INTO Roles (NombreRol, DescripcionRol, EstadoRol, FechaCreacion)
    VALUES (@RolName, @RolDescription, @RolStatus, GETDATE());
END;
GO
/****** Object:  StoredProcedure [dbo].[InsertarSesion]    Script Date: 9/3/2025 22:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarSesion]
    @UserID INT
AS
BEGIN
    INSERT INTO Sesiones (idUsuario, FechaIngreso)
    VALUES (@UserID, GETDATE());
END;
GO
/****** Object:  StoredProcedure [dbo].[InsertarUsuario]    Script Date: 9/3/2025 22:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[InsertarUsuario]
    @UserUsername VARCHAR(50),
	@UserPassword VARCHAR(20),
	@UserMail VARCHAR(100),
	@PersonID INT,
	@UserRole INT,
	@UserStatus VARCHAR(1)
AS
BEGIN
    INSERT INTO Usuarios (Username, Password, Mail, idPersona, idRol, EstadoUsuario, FechaCreacion)
    VALUES (@UserUsername, @UserPassword, @UserMail, @PersonID, @UserRole, @UserStatus, GETDATE());
END;
GO
/****** Object:  StoredProcedure [dbo].[LeerPersonaPorID]    Script Date: 9/3/2025 22:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LeerPersonaPorID]
	@PersonId INT
AS
BEGIN
    SELECT 
        idPersona,
		NombresPersona,
		ApellidosPersona,
		Identificacion,
		Genero,
		FechaNacimiento,
		EstadoPersona,
		EsActivo,
		FechaCreacion,
		UsuarioCreacion,
		FechaEdicion,
		UsuarioEdicion,
		FechaEliminacion,
		UsuarioEliminacion
    FROM 
        Persona
	WHERE
		idPersona = @PersonId
END;
GO
/****** Object:  StoredProcedure [dbo].[LeerPersonas]    Script Date: 9/3/2025 22:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LeerPersonas]
AS
BEGIN
    SELECT 
        idPersona,
		NombresPersona,
		ApellidosPersona,
		Identificacion,
		Genero,
		FechaNacimiento,
		EstadoPersona,
		EsActivo,
		FechaCreacion,
		UsuarioCreacion,
		FechaEdicion,
		UsuarioEdicion,
		FechaEliminacion,
		UsuarioEliminacion
    FROM 
        Persona
	WHERE
		EsActivo = 'A'
END;
GO
/****** Object:  StoredProcedure [dbo].[LeerRoles]    Script Date: 9/3/2025 22:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LeerRoles]
AS
BEGIN
    SELECT 
        idRol,
		NombreRol,
		DescripcionRol,
		EstadoRol,
		EsActivo,
		FechaCreacion,
		UsuarioCreacion,
		FechaEdicion,
		UsuarioEdicion,
		FechaEliminacion,
		UsuarioEliminacion
    FROM 
        Roles
	WHERE
		EsActivo = 'A'
END;
GO
/****** Object:  StoredProcedure [dbo].[LeerSesiones]    Script Date: 9/3/2025 22:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LeerSesiones]
AS
BEGIN
    SELECT 
        S.idSesion, S.idUsuario, CONCAT(P.NombresPersona, ' ', P.ApellidosPersona) AS 'NombresPersona',
		S.FechaIngreso, S.FechaEgreso, S.SesionActiva
    FROM 
        Sesiones S
	JOIN Usuarios U ON S.idUsuario = U.idUsuario
	JOIN Persona P ON U.idPersona = P.idPersona
END;
GO
/****** Object:  StoredProcedure [dbo].[LeerSesionPorID]    Script Date: 9/3/2025 22:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LeerSesionPorID]
	@UserID INT
AS
BEGIN
    SELECT 
        S.idSesion, S.idUsuario, CONCAT(P.NombresPersona, ' ', P.ApellidosPersona) AS 'NombresPersona',
		S.FechaIngreso, S.FechaEgreso, S.SesionActiva
    FROM 
        Sesiones S
	JOIN Usuarios U ON S.idUsuario = U.idUsuario
	JOIN Persona P ON U.idPersona = P.idPersona
	WHERE
		S.idUsuario = @UserID
END;
GO
/****** Object:  StoredProcedure [dbo].[LeerUsuarioPorID]    Script Date: 9/3/2025 22:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LeerUsuarioPorID]
	@UserID INT
AS
BEGIN
    SELECT 
        U.idUsuario, U.Username, U.Password, U.Mail, U.idPersona, 
		CONCAT(P.NombresPersona, ' ', P.ApellidosPersona) AS 'NombrePersona', R.idRol, R.NombreRol, U.EstadoUsuario, U. EsActivo,
		U.FechaCreacion, U.UsuarioCreacion, U.FechaEdicion, U.UsuarioEdicion, U.FechaEliminacion, U.UsuarioEliminacion
    FROM 
        Usuarios U
	JOIN Persona P ON U.idPersona = P.idPersona
	JOIN Roles R on U.idRol = R.idRol
	WHERE
		U.idUsuario = @UserID
END;
GO
/****** Object:  StoredProcedure [dbo].[LeerUsuarios]    Script Date: 9/3/2025 22:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LeerUsuarios]
AS
BEGIN
    SELECT 
        U.idUsuario, U.Username, U.Password, U.Mail, U.idPersona, 
		CONCAT(P.NombresPersona, ' ', P.ApellidosPersona) AS 'NombrePersona', R.idRol, R.NombreRol, U.EstadoUsuario, U. EsActivo,
		U.FechaCreacion, U.UsuarioCreacion, U.FechaEdicion, U.UsuarioEdicion, U.FechaEliminacion, U.UsuarioEliminacion
    FROM 
        Usuarios U
	JOIN Persona P ON U.idPersona = P.idPersona
	JOIN Roles R on U.idRol = R.idRol
	WHERE
		U.EsActivo = 'A'
END;
GO
/****** Object:  StoredProcedure [dbo].[ListarPermisosDeRol]    Script Date: 9/3/2025 22:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarPermisosDeRol]
    @IDRol INT
AS
BEGIN
    SELECT 
        R.NombreRol,
        P.NombrePermiso,
		P.RutaPermiso,
        P.DescripcionPermiso,
		P.IconoPermiso
    FROM 
        Roles R
    JOIN
        Rol_Permiso RP ON R.idRol = RP.idRol
    JOIN
        Permisos P ON RP.idPermiso = P.idPermiso
    WHERE
        R.idRol = @IDRol;
END;
GO
/****** Object:  StoredProcedure [dbo].[ListarPersonas]    Script Date: 9/3/2025 22:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarPersonas]
AS
BEGIN
	SELECT
		idPersona,
		CONCAT(NombresPersona, ' ', ApellidosPersona) AS 'NombrePersona'
	FROM 
		Persona
	WHERE
		EsActivo = 'A'
END;
GO
/****** Object:  StoredProcedure [dbo].[ListarRoles]    Script Date: 9/3/2025 22:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarRoles]
AS
BEGIN
	SELECT
		idRol,
		NombreRol
	FROM 
		Roles
	WHERE
		EsActivo = 'A'
END;
GO
/****** Object:  StoredProcedure [dbo].[ListarUsuarios]    Script Date: 9/3/2025 22:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[ListarUsuarios]
AS
BEGIN
	SELECT
		idUsuario,
		Username
	FROM 
		Usuarios
	WHERE
		EsActivo = 'A'
END;
GO
/****** Object:  StoredProcedure [dbo].[RegistroPersonaUsuario]    Script Date: 9/3/2025 22:08:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[RegistroPersonaUsuario]
    @PersonName VARCHAR(80),
    @PersonLastName VARCHAR(60),
    @PersonID VARCHAR(60),
    @PersonGender VARCHAR(1),
    @PersonBirthDate DATE,
    @UserUsername VARCHAR(50),
    @UserPassword VARCHAR(20),
    @UserMail VARCHAR(100)
AS
BEGIN
    DECLARE @NewPersonID INT;

    EXEC InsertarPersona @PersonName, @PersonLastName, @PersonID, @PersonGender, @PersonBirthDate, 'A';

    SELECT @NewPersonID = idPersona
    FROM Persona
    WHERE Identificacion = @PersonID

    EXEC InsertarUsuario @UserUsername, @UserPassword, @UserMail, @NewPersonID, 1, 'A';
END;
GO
USE [master]
GO
ALTER DATABASE [crud_database] SET  READ_WRITE 
GO
