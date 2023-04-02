CREATE TABLE [dbo].[User] (
    [UserId]           INT           IDENTITY (1, 1) NOT NULL,
    [UserFirstName]    VARCHAR (100) NULL,
    [UserLastName]     VARCHAR (100) NULL,
    [UserName]         VARCHAR (100) NULL,
    [UserPasswordHash] VARCHAR (100) NULL,
    [Salt]             VARCHAR (25)  NULL,
    [LastLogIn]        DATETIME      NULL,
    [DateJoined]       DATETIME      NULL,
    CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([UserId] ASC)
);


