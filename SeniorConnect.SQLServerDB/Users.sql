CREATE TABLE [dbo].[User]
(
	[UserId] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL,
    [Email] NVARCHAR(70) NOT NULL,
    [Password] NVARCHAR(30) NOT NULL, 
    [DateOfBirth ] DATETIMEOFFSET NOT NULL, 
    [Zipcode] NCHAR(6) NULL, 
    [DateOfRegistration] DATETIMEOFFSET NOT NULL, 
)
