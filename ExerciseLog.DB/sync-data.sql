USE [Exercise Log]
GO
/****** Object:  Table [dbo].[Entry]    Script Date: 3/29/2023 1:09:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entry](
	[EntryId] [int] NOT NULL,
	[ExerciseGoalId] [int] NOT NULL,
	[EntryDate] [datetime] NOT NULL,
	[HoursExercised] [int] NOT NULL,
	[MinutesExercised] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[EntryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Exercise]    Script Date: 3/29/2023 1:09:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Exercise](
	[ExerciseId] [int] NOT NULL,
	[ExerciseName] [varchar](100) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ExerciseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ExerciseGoal]    Script Date: 3/29/2023 1:09:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExerciseGoal](
	[ExerciseGoalId] [int] NOT NULL,
	[ExerciseId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Goal] [varchar](5) NOT NULL,
	[Total] [varchar](5) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ExerciseGoalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 3/29/2023 1:09:13 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] NOT NULL,
	[UserFirstName] [varchar](100) NOT NULL,
	[UserLestName] [varchar](100) NOT NULL,
	[UserName] [varchar](100) NOT NULL,
	[UserPasswordHash] [varchar](100) NOT NULL,
	[Salt] [varchar](25) NOT NULL,
	[LastLogIn] [datetime] NOT NULL,
	[DateJoined] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Entry]  WITH CHECK ADD  CONSTRAINT [FK_Entry_ExerciseGoal] FOREIGN KEY([ExerciseGoalId])
REFERENCES [dbo].[ExerciseGoal] ([ExerciseGoalId])
GO
ALTER TABLE [dbo].[Entry] CHECK CONSTRAINT [FK_Entry_ExerciseGoal]
GO
ALTER TABLE [dbo].[ExerciseGoal]  WITH CHECK ADD  CONSTRAINT [FK_ExerciseGoal_Exercise] FOREIGN KEY([ExerciseId])
REFERENCES [dbo].[Exercise] ([ExerciseId])
GO
ALTER TABLE [dbo].[ExerciseGoal] CHECK CONSTRAINT [FK_ExerciseGoal_Exercise]
GO
ALTER TABLE [dbo].[ExerciseGoal]  WITH CHECK ADD  CONSTRAINT [FK_ExerciseGoal_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[ExerciseGoal] CHECK CONSTRAINT [FK_ExerciseGoal_User]
GO
