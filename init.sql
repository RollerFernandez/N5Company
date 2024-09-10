USE [master]
GO
/****** Object:  Database [Customermanagement]    Script Date: 6/27/2024 6:13:06 AM ******/
CREATE DATABASE [Customermanagement]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Customermanagement', FILENAME = N'/var/opt/mssql/data/Customermanagement.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Customermanagement_log', FILENAME = N'/var/opt/mssql/data/Customermanagement_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Customermanagement] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Customermanagement].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Customermanagement] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Customermanagement] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Customermanagement] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Customermanagement] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Customermanagement] SET ARITHABORT OFF 
GO
ALTER DATABASE [Customermanagement] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Customermanagement] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Customermanagement] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Customermanagement] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Customermanagement] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Customermanagement] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Customermanagement] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Customermanagement] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Customermanagement] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Customermanagement] SET  ENABLE_BROKER 
GO
ALTER DATABASE [Customermanagement] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Customermanagement] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Customermanagement] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Customermanagement] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Customermanagement] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Customermanagement] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Customermanagement] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Customermanagement] SET RECOVERY FULL 
GO
ALTER DATABASE [Customermanagement] SET  MULTI_USER 
GO
ALTER DATABASE [Customermanagement] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Customermanagement] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Customermanagement] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Customermanagement] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Customermanagement] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Customermanagement] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Customermanagement', N'ON'
GO
ALTER DATABASE [Customermanagement] SET QUERY_STORE = OFF
GO
USE [Customermanagement]
GO
/****** Object:  Schema [Admin]    Script Date: 6/27/2024 6:13:06 AM ******/
CREATE SCHEMA [Admin]
GO
/****** Object:  Table [Admin].[Employees]    Script Date: 6/27/2024 6:13:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Admin].[Employees](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Status] [char](1) NULL,
	[CreatedBy] [varchar](100) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedBy] [varchar](100) NULL,
	[UpdatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Admin].[Permissions]    Script Date: 6/27/2024 6:13:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Admin].[Permissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[EmployeeId] [int] NOT NULL,
	[PermissionTypeId] [int] NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NULL,
	[Reason] [nvarchar](200) NULL,
	[Status] [char](1) NULL,
	[CreatedBy] [varchar](100) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedBy] [varchar](100) NULL,
	[UpdatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [Admin].[PermissionTypes]    Script Date: 6/27/2024 6:13:06 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [Admin].[PermissionTypes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](200) NOT NULL,
	[Status] [char](1) NULL,
	[CreatedBy] [varchar](100) NULL,
	[CreatedAt] [datetime] NULL,
	[UpdatedBy] [varchar](100) NULL,
	[UpdatedAt] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [Admin].[Employees] ON 

INSERT [Admin].[Employees] ([Id], [Name], [Email], [LastName], [Status], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt]) VALUES (2, N'Rogelio', N'rollerfernandez@gmail.com', N'Fernandez', N'A', N'HR', CAST(N'2024-05-10T00:00:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [Admin].[Employees] OFF
GO
SET IDENTITY_INSERT [Admin].[Permissions] ON 

INSERT [Admin].[Permissions] ([Id], [EmployeeId], [PermissionTypeId], [StartDate], [EndDate], [Reason], [Status], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt]) VALUES (3, 2, 1, CAST(N'2024-06-25' AS Date), CAST(N'2024-06-25' AS Date), N'modificacion 3', N'A', N'HR', CAST(N'2024-05-10T00:00:00.000' AS DateTime), NULL, NULL)
INSERT [Admin].[Permissions] ([Id], [EmployeeId], [PermissionTypeId], [StartDate], [EndDate], [Reason], [Status], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt]) VALUES (4, 2, 2, CAST(N'2024-08-25' AS Date), CAST(N'2024-08-25' AS Date), N'modificacion 3', N'A', N'HR', CAST(N'2024-05-10T00:00:00.000' AS DateTime), NULL, NULL)

SET IDENTITY_INSERT [Admin].[Permissions] OFF
GO
SET IDENTITY_INSERT [Admin].[PermissionTypes] ON 

INSERT [Admin].[PermissionTypes] ([Id], [Name], [Description], [Status], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt]) VALUES (1, N'ADMINISTRADOR DE SISTEMA', N'ADMINISTRADOR DE SISTEMA', N'A', N'HR', CAST(N'2024-05-10T00:00:00.000' AS DateTime), NULL, NULL)
INSERT [Admin].[PermissionTypes] ([Id], [Name], [Description], [Status], [CreatedBy], [CreatedAt], [UpdatedBy], [UpdatedAt]) VALUES (2, N'ADMINISTRADOR DE MODULO', N'ADMINISTRADOR DE MODULO', N'A', N'HR', CAST(N'2024-05-10T00:00:00.000' AS DateTime), NULL, NULL)
SET IDENTITY_INSERT [Admin].[PermissionTypes] OFF
GO
ALTER TABLE [Admin].[Permissions]  WITH CHECK ADD FOREIGN KEY([EmployeeId])
REFERENCES [Admin].[Employees] ([Id])
GO
ALTER TABLE [Admin].[Permissions]  WITH CHECK ADD FOREIGN KEY([PermissionTypeId])
REFERENCES [Admin].[PermissionTypes] ([Id])
GO
USE [master]
GO
ALTER DATABASE [Customermanagement] SET  READ_WRITE 
GO
