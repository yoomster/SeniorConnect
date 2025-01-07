CREATE TABLE [dbo].[Users]
(
	[UserId] INT NOT NULL PRIMARY KEY IDENTITY,
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL,
    [Email] NVARCHAR(70) NOT NULL,
    [Password] NVARCHAR(50) NOT NULL,
    [DateOfBirth] Date NOT NULL,
    [Gender] char NOT NULL, 
    [Origin] nvarchar(30) NOT NULL,
    [MaritalStatus] TINYINT NOT NULL, 
    --1 (Single), 2 (Married), 3 (Divorced), 4 (Widowed)
    [DateOfRegistration] Date NOT NULL,
    [StreetName] NVARCHAR(50) NOT NULL, 
	[HouseNumber] NVARCHAR(10) NOT NULL, 
	[Zipcode] NVARCHAR(10) NOT NULL, 
    [City] NVARCHAR(50) NOT NULL, 
    [Country] NVARCHAR(30) NOT NULL,
)


