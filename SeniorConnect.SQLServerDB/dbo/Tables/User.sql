CREATE TABLE [dbo].[User]
(
	[UserId] INT NOT NULL PRIMARY KEY IDENTITY,
    [FirstName] NVARCHAR(50) NOT NULL, 
    [LastName] NVARCHAR(50) NOT NULL,
    [Email] NVARCHAR(70) NOT NULL,
    [Password] NVARCHAR(50) NOT NULL,
    [DateOfBirth] Date NOT NULL,
    [Gender] char, 
    [Origin] nvarchar(30),
    [DateOfRegistration] Date NOT NULL,
    [AddressID] INT NOT NULL, 
        CONSTRAINT [FK_User_ToAddress] 
            FOREIGN KEY ([AddressID]) REFERENCES [dbo].[Address]([AddressId]));
