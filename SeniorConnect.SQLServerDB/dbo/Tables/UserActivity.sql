﻿CREATE TABLE [dbo].[UserActivity]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
	[UserId] INT NOT NULL,
	[ActivityId] INT NOT NULL
)
