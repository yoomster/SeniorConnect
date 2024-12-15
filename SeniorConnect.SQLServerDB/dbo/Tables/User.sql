CREATE TABLE [dbo].[User]
(
	[UserId] INT NOT NULL PRIMARY KEY IDENTITY,
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL,
    [Email] NVARCHAR(70) NOT NULL,
    [Password] NVARCHAR(50) NOT NULL,
    [DateOfBirth] Date NOT NULL,
    --1 for TRUE and 0 for FALSE
    [Gender] char, 
    [Origin] nvarchar(30),
    [Iban] nvarchar(30),
    [DateOfRegistration] Date NOT NULL,
    [StreetName] NVARCHAR(50) NOT NULL, 
	[HouseNumber] NVARCHAR(10) NOT NULL, 
	[Zipcode] NVARCHAR(10) NOT NULL, 
    [City] NVARCHAR(50) NOT NULL, 
    [Country] NVARCHAR(30) NOT NULL,
);
