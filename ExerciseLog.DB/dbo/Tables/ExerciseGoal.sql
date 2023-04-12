CREATE TABLE [dbo].[ExerciseGoal] (
    [ExerciseGoalId] INT         IDENTITY (1, 1) NOT NULL,
    [ExerciseId]     INT         NOT NULL,
    [UserId]         INT         NOT NULL,
    [Goal]           VARCHAR (5) NULL,
    [Total]          VARCHAR (5) NULL,
    CONSTRAINT [PK__Exercise__407D4D3C9914EAD6] PRIMARY KEY CLUSTERED ([ExerciseGoalId] ASC),
    CONSTRAINT [FK_ExerciseGoal_Exercise] FOREIGN KEY ([ExerciseId]) REFERENCES [dbo].[Exercise] ([ExerciseId]),
    CONSTRAINT [FK_ExerciseGoal_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
);




