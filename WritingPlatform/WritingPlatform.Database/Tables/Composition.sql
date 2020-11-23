﻿CREATE TABLE [dbo].[Composition]
(
	[Id] INT NOT NULL IDENTITY(1,1),
	[Name] NVARCHAR(50) NOT NULL,
	[Genre] NVARCHAR(50) NOT NULL,
	[PublicationTime] DATE NOT NULL,
	[Rating] FLOAT DEFAULT 0 NOT NULL,
	[NumberOfMarks] INT DEFAULT 0 NOT NULL,
	[UserId] INT NOT NULL,
	[Content] NVARCHAR(MAX) NOT NULL,
	CONSTRAINT PK_Work PRIMARY KEY ([Id])
)