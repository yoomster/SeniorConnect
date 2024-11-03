CREATE TABLE [dbo].[Activity]
(
	[ActivityId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(500) NULL, 
    [Date] DATETIMEOFFSET NOT NULL, 
    [MaxParticipants] INT NOT NULL, 
    [MinParticipants] INT NOT NULL, 
    [Open] BIT NOT NULL, 

)
