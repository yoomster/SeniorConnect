CREATE TABLE [dbo].[User]
(
	[UserId] INT NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL,
    [Email] NVARCHAR(70) NOT NULL,
    [Password] NVARCHAR(50) NOT NULL, 
    [DateOfBirth] DATE NOT NULL, 
    [Gender] CHAR NULL, 
    [Origin] NVARCHAR(30) NULL, 
    [IBAN] NVARCHAR(30) NOT NULL, 
    [DateOfRegistration] DATE NOT NULL, 
)
