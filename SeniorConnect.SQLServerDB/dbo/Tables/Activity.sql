CREATE TABLE [dbo].[Activity]
(
    [ActivityId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(50) NOT NULL, 
    [Description] NVARCHAR(500) NULL, 
    [Date] DATE NOT NULL, 
    [StartTime] TIME NOT NULL,
    [EndTime] TIME NOT NULL,
    [MaxParticipants] INT NOT NULL, 
    [AddressId] INT NOT NULL, 
    CONSTRAINT [FK_Activity_ToAddress] 
        FOREIGN KEY ([AddressId]) REFERENCES [dbo].[Address]([AddressId])
);
