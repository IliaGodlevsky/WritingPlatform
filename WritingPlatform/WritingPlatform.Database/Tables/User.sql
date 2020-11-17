﻿CREATE TABLE [dbo].[User]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[Name] NVARCHAR(50) NOT NULL,
	[BirthDay] DATETIME NOT NULL,
	[Login] NVARCHAR(50) NOT NULL,
	[Password] NVARCHAR(50) NOT NULL,
	[Email] NVARCHAR(50) NOT NULL,
	[IsDeleted] BINARY NOT NULL,
	CONSTRAINT PK_User PRIMARY KEY ([Id])
)
