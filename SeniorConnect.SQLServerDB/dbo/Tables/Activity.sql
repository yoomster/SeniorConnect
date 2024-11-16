CREATE TABLE [dbo].[Activity]
(
	[ActivityId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(500) NULL, 
    [Date] DATE NOT NULL, 
    [StartTime] TIME NOT NULL,
    [EndTime] TIME NOT NULL,
    [MaxParticipants] INT NOT NULL, 
)
