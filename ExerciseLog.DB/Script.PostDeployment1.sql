/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
USE [Exercise Log]
GO
INSERT [dbo].[Exercise] ([ExerciseId], [ExerciseName]) VALUES (1, N'"walking"')
GO
INSERT [dbo].[Exercise] ([ExerciseId], [ExerciseName]) VALUES (2, N'"running"')
GO
INSERT [dbo].[Exercise] ([ExerciseId], [ExerciseName]) VALUES (3, N'"skateboarding"')
GO
INSERT [dbo].[Exercise] ([ExerciseId], [ExerciseName]) VALUES (4, N'"biking"')
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([UserId], [UserFirstName], [UserLastName], [UserName], [UserPasswordHash], [Salt], [LastLogIn], [DateJoined]) VALUES (1, N'Justin', N'Davis', N'jdavis', N'password', N'salt', CAST(N'2003-05-07T00:00:00.000' AS DateTime), CAST(N'2023-04-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[User] ([UserId], [UserFirstName], [UserLastName], [UserName], [UserPasswordHash], [Salt], [LastLogIn], [DateJoined]) VALUES (11, N'Chinyere', N'Ejeckam', N'chichi', N'password', N'salt', CAST(N'2023-04-02T19:40:00.983' AS DateTime), CAST(N'2023-04-02T19:40:00.983' AS DateTime))
GO
INSERT [dbo].[User] ([UserId], [UserFirstName], [UserLastName], [UserName], [UserPasswordHash], [Salt], [LastLogIn], [DateJoined]) VALUES (12, N'Jacob', N'Nodes', N'jnodes', N'password', N'salt', CAST(N'2023-04-02T19:40:39.390' AS DateTime), CAST(N'2023-04-02T19:40:39.390' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
SET IDENTITY_INSERT [dbo].[ExerciseGoal] ON 
GO
INSERT [dbo].[ExerciseGoal] ([ExerciseGoalId], [ExerciseId], [UserId], [Goal], [Total]) VALUES (1, 3, 1, N'01:30', N'00:00')
GO
INSERT [dbo].[ExerciseGoal] ([ExerciseGoalId], [ExerciseId], [UserId], [Goal], [Total]) VALUES (2, 4, 1, N'00:30', N'00:00')
GO
SET IDENTITY_INSERT [dbo].[ExerciseGoal] OFF
GO
