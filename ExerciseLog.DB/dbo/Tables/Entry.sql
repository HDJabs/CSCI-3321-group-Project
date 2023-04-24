CREATE TABLE [dbo].[Entry] (
    [EntryId]          INT      IDENTITY (1, 1) NOT NULL,
    [ExerciseGoalId]   INT      NOT NULL,
    [EntryDate]        DATETIME NOT NULL,
    [HoursExercised]   INT      NOT NULL,
    [MinutesExercised] INT      NOT NULL,
    CONSTRAINT [PK__Entry__F57BD2F745B94190] PRIMARY KEY CLUSTERED ([EntryId] ASC),
    CONSTRAINT [FK_Entry_ExerciseGoal] FOREIGN KEY ([ExerciseGoalId]) REFERENCES [dbo].[ExerciseGoal] ([ExerciseGoalId]) ON DELETE CASCADE
);






