CREATE TABLE [dbo].[User]
(
	[UserId] INT NOT NULL PRIMARY KEY, 
    [UserFirstName] VARCHAR(100) NOT NULL, 
    [UserLestName] VARCHAR(100) NOT NULL, 
    [UserName] VARCHAR(100) NOT NULL, 
    [UserPasswordHash] VARCHAR(100) NOT NULL, 
    [Salt] VARCHAR(25) NOT NULL, 
    [LastLogIn] DATETIME NOT NULL, 
    [DateJoined] DATETIME NOT NULL
)
