CREATE TABLE [dbo].[Entry]
(
	[EntryId] INT NOT NULL PRIMARY KEY, 
    [ExerciseGoalId] INT NOT NULL, 
    [EntryDate] DATETIME NOT NULL, 
    [HoursExercised] INT NOT NULL, 
    [MinutesExercised] INT NOT NULL
)
