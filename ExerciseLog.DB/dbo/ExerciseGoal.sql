CREATE TABLE [dbo].[ExerciseGoal]
(
	[ExerciseGoalId] INT NOT NULL PRIMARY KEY, 
    [ExerciseId] INT NOT NULL, 
    [UserId] INT NOT NULL, 
    [Goal] VARCHAR(5) NOT NULL, 
    [Total] VARCHAR(5) NOT NULL
)
