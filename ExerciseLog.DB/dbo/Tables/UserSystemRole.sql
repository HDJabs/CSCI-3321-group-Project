CREATE TABLE [dbo].[UserSystemRole] (
    [UserId]       INT NOT NULL,
    [SystemRoldId] INT NOT NULL,
    CONSTRAINT [PK_UserSystemRole] PRIMARY KEY CLUSTERED ([UserId] ASC, [SystemRoldId] ASC),
    CONSTRAINT [FK_UserSystemRole_SystemRole] FOREIGN KEY ([SystemRoldId]) REFERENCES [dbo].[SystemRole] ([SystemRoleId]),
    CONSTRAINT [FK_UserSystemRole_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
);

