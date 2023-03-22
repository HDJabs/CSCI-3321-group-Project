CREATE TABLE [dbo].[ExerciseGoal] (
    [ExerciseGoalId] INT         NOT NULL,
    [ExerciseId]     INT         NOT NULL,
    [UserId]         INT         NOT NULL,
    [Goal]           VARCHAR (5) NOT NULL,
    [Total]          VARCHAR (5) NOT NULL,
    PRIMARY KEY CLUSTERED ([ExerciseGoalId] ASC),
    CONSTRAINT [FK_ExerciseGoal_Exercise] FOREIGN KEY ([ExerciseId]) REFERENCES [dbo].[Exercise] ([ExerciseId]),
    CONSTRAINT [FK_ExerciseGoal_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([UserId])
);


