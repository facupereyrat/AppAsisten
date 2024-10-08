USE [master]
GO
/****** Object:  Database [Asistencia]    Script Date: 23/09/2024 21:10:58 ******/
CREATE DATABASE [Asistencia]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Asistencia', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Asistencia.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Asistencia_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER\MSSQL\DATA\Asistencia_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Asistencia] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Asistencia].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Asistencia] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Asistencia] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Asistencia] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Asistencia] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Asistencia] SET ARITHABORT OFF 
GO
ALTER DATABASE [Asistencia] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Asistencia] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Asistencia] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Asistencia] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Asistencia] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Asistencia] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Asistencia] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Asistencia] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Asistencia] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Asistencia] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Asistencia] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Asistencia] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Asistencia] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Asistencia] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Asistencia] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Asistencia] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Asistencia] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Asistencia] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Asistencia] SET  MULTI_USER 
GO
ALTER DATABASE [Asistencia] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Asistencia] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Asistencia] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Asistencia] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Asistencia] SET DELAYED_DURABILITY = DISABLED 
GO
USE [Asistencia]
GO
/****** Object:  Table [dbo].[Administradores]    Script Date: 23/09/2024 21:10:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Administradores](
	[IdAdministrador] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](max) NULL,
	[Apellido] [varchar](max) NULL,
	[Usuario] [nvarchar](50) NULL,
	[Contraseña] [nvarchar](50) NULL,
	[FechaRegistro] [datetime] NULL,
	[IdCuota] [int] NULL,
 CONSTRAINT [PK_Administradores] PRIMARY KEY CLUSTERED 
(
	[IdAdministrador] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Asistencias]    Script Date: 23/09/2024 21:10:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Asistencias](
	[IdAsistencia] [int] IDENTITY(1,1) NOT NULL,
	[Ingreso] [datetime] NULL,
	[Egreso] [datetime] NULL,
	[IdMiembro] [int] NULL,
 CONSTRAINT [PK_Asistencias] PRIMARY KEY CLUSTERED 
(
	[IdAsistencia] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cuota]    Script Date: 23/09/2024 21:10:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Cuota](
	[IdCuota] [int] IDENTITY(1,1) NOT NULL,
	[Monto] [datetime] NULL,
	[FechaPago] [datetime] NULL,
	[Estado] [varchar](50) NULL,
	[IdMiembro] [int] NULL,
	[IdAdministrador] [int] NULL,
 CONSTRAINT [PK_Cuota] PRIMARY KEY CLUSTERED 
(
	[IdCuota] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Miembros]    Script Date: 23/09/2024 21:10:58 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Miembros](
	[IdMiembro] [int] IDENTITY(1,1) NOT NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
	[Codigo] [nvarchar](50) NULL,
	[FechaRegistro] [nvarchar](50) NULL,
	[Estado] [varchar](50) NULL,
	[IdAdministrador] [int] NULL,
 CONSTRAINT [PK_Miembros] PRIMARY KEY CLUSTERED 
(
	[IdMiembro] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[Administradores]  WITH CHECK ADD  CONSTRAINT [FK_Administradores_Cuota] FOREIGN KEY([IdCuota])
REFERENCES [dbo].[Cuota] ([IdCuota])
GO
ALTER TABLE [dbo].[Administradores] CHECK CONSTRAINT [FK_Administradores_Cuota]
GO
ALTER TABLE [dbo].[Asistencias]  WITH CHECK ADD  CONSTRAINT [FK_Asistencias_Miembros] FOREIGN KEY([IdMiembro])
REFERENCES [dbo].[Miembros] ([IdMiembro])
GO
ALTER TABLE [dbo].[Asistencias] CHECK CONSTRAINT [FK_Asistencias_Miembros]
GO
ALTER TABLE [dbo].[Cuota]  WITH CHECK ADD  CONSTRAINT [FK_Cuota_Administradores] FOREIGN KEY([IdAdministrador])
REFERENCES [dbo].[Administradores] ([IdAdministrador])
GO
ALTER TABLE [dbo].[Cuota] CHECK CONSTRAINT [FK_Cuota_Administradores]
GO
ALTER TABLE [dbo].[Cuota]  WITH CHECK ADD  CONSTRAINT [FK_Cuota_Miembros] FOREIGN KEY([IdMiembro])
REFERENCES [dbo].[Miembros] ([IdMiembro])
GO
ALTER TABLE [dbo].[Cuota] CHECK CONSTRAINT [FK_Cuota_Miembros]
GO
ALTER TABLE [dbo].[Miembros]  WITH CHECK ADD  CONSTRAINT [FK_Miembros_Administradores] FOREIGN KEY([IdAdministrador])
REFERENCES [dbo].[Administradores] ([IdAdministrador])
GO
ALTER TABLE [dbo].[Miembros] CHECK CONSTRAINT [FK_Miembros_Administradores]
GO
USE [master]
GO
ALTER DATABASE [Asistencia] SET  READ_WRITE 
GO
