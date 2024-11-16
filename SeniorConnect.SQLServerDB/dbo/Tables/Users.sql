CREATE TABLE [dbo].[User]
(
	[UserId] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY, 
    [FirstName] NVARCHAR(100) NOT NULL, 
    [LastName] NVARCHAR(100) NOT NULL,
    [Email] NVARCHAR(100) NOT NULL,
    [Password] NVARCHAR(50) NOT NULL, 
    [DateOfBirth] DATETIMEOFFSET NOT NULL, 
    [Zipcode] NVARCHAR(10) NOT NULL, 
    [City] NVARCHAR(50) NOT NULL, 
    [Country] NVARCHAR(50) NOT NULL, 
    [Gender] CHAR NULL, 
    [Origin] NVARCHAR(50) NULL, 
    [IBAN] CHAR(20) NOT NULL, 
    [DateOfRegistration] DATE NOT NULL, 
)
