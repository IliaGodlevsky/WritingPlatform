USE [master]
GO
/****** Object:  Database [WritingPlatformDatabase]    Script Date: 11/21/2020 10:47:12 ******/
CREATE DATABASE [WritingPlatformDatabase] ON  PRIMARY 
( NAME = N'WritingPlatformDatabase', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\WritingPlatformDatabase.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'WritingPlatformDatabase_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLEXPRESS\MSSQL\DATA\WritingPlatformDatabase_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [WritingPlatformDatabase].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [WritingPlatformDatabase] SET ANSI_NULL_DEFAULT OFF
GO
ALTER DATABASE [WritingPlatformDatabase] SET ANSI_NULLS OFF
GO
ALTER DATABASE [WritingPlatformDatabase] SET ANSI_PADDING OFF
GO
ALTER DATABASE [WritingPlatformDatabase] SET ANSI_WARNINGS OFF
GO
ALTER DATABASE [WritingPlatformDatabase] SET ARITHABORT OFF
GO
ALTER DATABASE [WritingPlatformDatabase] SET AUTO_CLOSE OFF
GO
ALTER DATABASE [WritingPlatformDatabase] SET AUTO_CREATE_STATISTICS ON
GO
ALTER DATABASE [WritingPlatformDatabase] SET AUTO_SHRINK OFF
GO
ALTER DATABASE [WritingPlatformDatabase] SET AUTO_UPDATE_STATISTICS ON
GO
ALTER DATABASE [WritingPlatformDatabase] SET CURSOR_CLOSE_ON_COMMIT OFF
GO
ALTER DATABASE [WritingPlatformDatabase] SET CURSOR_DEFAULT  GLOBAL
GO
ALTER DATABASE [WritingPlatformDatabase] SET CONCAT_NULL_YIELDS_NULL OFF
GO
ALTER DATABASE [WritingPlatformDatabase] SET NUMERIC_ROUNDABORT OFF
GO
ALTER DATABASE [WritingPlatformDatabase] SET QUOTED_IDENTIFIER OFF
GO
ALTER DATABASE [WritingPlatformDatabase] SET RECURSIVE_TRIGGERS OFF
GO
ALTER DATABASE [WritingPlatformDatabase] SET  DISABLE_BROKER
GO
ALTER DATABASE [WritingPlatformDatabase] SET AUTO_UPDATE_STATISTICS_ASYNC OFF
GO
ALTER DATABASE [WritingPlatformDatabase] SET DATE_CORRELATION_OPTIMIZATION OFF
GO
ALTER DATABASE [WritingPlatformDatabase] SET TRUSTWORTHY OFF
GO
ALTER DATABASE [WritingPlatformDatabase] SET ALLOW_SNAPSHOT_ISOLATION OFF
GO
ALTER DATABASE [WritingPlatformDatabase] SET PARAMETERIZATION SIMPLE
GO
ALTER DATABASE [WritingPlatformDatabase] SET READ_COMMITTED_SNAPSHOT OFF
GO
ALTER DATABASE [WritingPlatformDatabase] SET HONOR_BROKER_PRIORITY OFF
GO
ALTER DATABASE [WritingPlatformDatabase] SET  READ_WRITE
GO
ALTER DATABASE [WritingPlatformDatabase] SET RECOVERY SIMPLE
GO
ALTER DATABASE [WritingPlatformDatabase] SET  MULTI_USER
GO
ALTER DATABASE [WritingPlatformDatabase] SET PAGE_VERIFY CHECKSUM
GO
ALTER DATABASE [WritingPlatformDatabase] SET DB_CHAINING OFF
GO
USE [WritingPlatformDatabase]
GO
/****** Object:  Table [dbo].[Work]    Script Date: 11/21/2020 10:47:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Work](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Genre] [nvarchar](50) NOT NULL,
	[PublicationTime] [date] NOT NULL,
	[Rating] [float] NOT NULL,
	[UserId] [int] NOT NULL,
	[TextOfWork] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Work] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Work] ON
INSERT [dbo].[Work] ([Id], [Name], [Genre], [PublicationTime], [Rating], [UserId], [TextOfWork]) VALUES (7, N'Oliver Twist', N'fiction', CAST(0x00000000 AS Date), 0, 13, N'Once upon a time')
INSERT [dbo].[Work] ([Id], [Name], [Genre], [PublicationTime], [Rating], [UserId], [TextOfWork]) VALUES (9, N'Oliver Twist', N'fiction', CAST(0x00000000 AS Date), 0, 14, N'e')
INSERT [dbo].[Work] ([Id], [Name], [Genre], [PublicationTime], [Rating], [UserId], [TextOfWork]) VALUES (10, N'Oliver Twist', N'fiction', CAST(0xC3410B00 AS Date), 0, 14, N'Once upon a time')
SET IDENTITY_INSERT [dbo].[Work] OFF
/****** Object:  Table [dbo].[User]    Script Date: 11/21/2020 10:47:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[BirthDay] [date] NOT NULL,
	[Login] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[Email] [nvarchar](50) NOT NULL,
	[IsDeleted] [bit] NOT NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[User] ON
INSERT [dbo].[User] ([Id], [Name], [BirthDay], [Login], [Password], [Email], [IsDeleted]) VALUES (13, N'Егор', CAST(0xD1960A00 AS Date), N'Egor', N'Egor', N'Egor@gmail.com', 0)
INSERT [dbo].[User] ([Id], [Name], [BirthDay], [Login], [Password], [Email], [IsDeleted]) VALUES (14, N'Ilia', CAST(0x00000000 AS Date), N'Ilia', N'Ilia', N'Ilia', 0)
SET IDENTITY_INSERT [dbo].[User] OFF
/****** Object:  Table [dbo].[Comment]    Script Date: 11/21/2020 10:47:13 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Text] [nvarchar](1000) NOT NULL,
	[Workid] [int] NOT NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Default [DF__User__IsDeleted__47DBAE45]    Script Date: 11/21/2020 10:47:13 ******/
ALTER TABLE [dbo].[User] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
