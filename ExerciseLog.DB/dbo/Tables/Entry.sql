CREATE TABLE [dbo].[Entry] (
    [EntryId]          INT      NOT NULL,
    [ExerciseGoalId]   INT      NOT NULL,
    [EntryDate]        DATETIME NOT NULL,
    [HoursExercised]   INT      NOT NULL,
    [MinutesExercised] INT      NOT NULL,
    PRIMARY KEY CLUSTERED ([EntryId] ASC),
    CONSTRAINT [FK_Entry_ExerciseGoal] FOREIGN KEY ([ExerciseGoalId]) REFERENCES [dbo].[ExerciseGoal] ([ExerciseGoalId])
);


