USE [Exercise Log]
GO
/****** Object:  Table [dbo].[Entry]    Script Date: 4/24/2023 10:45:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entry](
	[EntryId] [int] IDENTITY(1,1) NOT NULL,
	[ExerciseGoalId] [int] NOT NULL,
	[EntryDate] [datetime] NOT NULL,
	[HoursExercised] [int] NOT NULL,
	[MinutesExercised] [int] NOT NULL,
 CONSTRAINT [PK__Entry__F57BD2F745B94190] PRIMARY KEY CLUSTERED 
(
	[EntryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Exercise]    Script Date: 4/24/2023 10:45:47 AM ******/
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
/****** Object:  Table [dbo].[ExerciseGoal]    Script Date: 4/24/2023 10:45:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ExerciseGoal](
	[ExerciseGoalId] [int] IDENTITY(1,1) NOT NULL,
	[ExerciseId] [int] NOT NULL,
	[UserId] [int] NOT NULL,
	[Goal] [varchar](5) NULL,
	[Total] [varchar](5) NULL,
 CONSTRAINT [PK__Exercise__407D4D3C9914EAD6] PRIMARY KEY CLUSTERED 
(
	[ExerciseGoalId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SystemRole]    Script Date: 4/24/2023 10:45:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SystemRole](
	[SystemRoleId] [int] NOT NULL,
	[SystemRoleName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_SystemRole] PRIMARY KEY CLUSTERED 
(
	[SystemRoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 4/24/2023 10:45:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[UserId] [int] IDENTITY(1,1) NOT NULL,
	[UserFirstName] [varchar](100) NULL,
	[UserLastName] [varchar](100) NULL,
	[UserName] [varchar](100) NULL,
	[UserPasswordHash] [varchar](100) NULL,
	[Salt] [varchar](25) NULL,
	[LastLogIn] [datetime] NULL,
	[DateJoined] [datetime] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserSystemRole]    Script Date: 4/24/2023 10:45:47 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserSystemRole](
	[UserId] [int] NOT NULL,
	[SystemRoldId] [int] NOT NULL,
 CONSTRAINT [PK_UserSystemRole] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[SystemRoldId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Entry] ON 
GO
INSERT [dbo].[Entry] ([EntryId], [ExerciseGoalId], [EntryDate], [HoursExercised], [MinutesExercised]) VALUES (6, 16, CAST(N'2023-04-09T08:33:00.000' AS DateTime), 0, 30)
GO
INSERT [dbo].[Entry] ([EntryId], [ExerciseGoalId], [EntryDate], [HoursExercised], [MinutesExercised]) VALUES (1007, 1019, CAST(N'2023-04-09T12:30:00.000' AS DateTime), 0, 15)
GO
INSERT [dbo].[Entry] ([EntryId], [ExerciseGoalId], [EntryDate], [HoursExercised], [MinutesExercised]) VALUES (1039, 1041, CAST(N'2023-04-09T12:30:00.000' AS DateTime), 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Entry] OFF
GO
INSERT [dbo].[Exercise] ([ExerciseId], [ExerciseName]) VALUES (1, N'Walking')
GO
INSERT [dbo].[Exercise] ([ExerciseId], [ExerciseName]) VALUES (2, N'Running')
GO
INSERT [dbo].[Exercise] ([ExerciseId], [ExerciseName]) VALUES (3, N'Skateboarding')
GO
INSERT [dbo].[Exercise] ([ExerciseId], [ExerciseName]) VALUES (4, N'Biking')
GO
SET IDENTITY_INSERT [dbo].[ExerciseGoal] ON 
GO
INSERT [dbo].[ExerciseGoal] ([ExerciseGoalId], [ExerciseId], [UserId], [Goal], [Total]) VALUES (9, 4, 11, N'01:00', N'00:00')
GO
INSERT [dbo].[ExerciseGoal] ([ExerciseGoalId], [ExerciseId], [UserId], [Goal], [Total]) VALUES (16, 4, 13, N'04:30', N'00:00')
GO
INSERT [dbo].[ExerciseGoal] ([ExerciseGoalId], [ExerciseId], [UserId], [Goal], [Total]) VALUES (1019, 1, 1013, N'02:02', N'00:15')
GO
INSERT [dbo].[ExerciseGoal] ([ExerciseGoalId], [ExerciseId], [UserId], [Goal], [Total]) VALUES (1041, 1, 1, N'04:00', N'01:00')
GO
SET IDENTITY_INSERT [dbo].[ExerciseGoal] OFF
GO
SET IDENTITY_INSERT [dbo].[User] ON 
GO
INSERT [dbo].[User] ([UserId], [UserFirstName], [UserLastName], [UserName], [UserPasswordHash], [Salt], [LastLogIn], [DateJoined]) VALUES (1, N'Justin', N'Davis', N'jdavis', N'password', N'salt', CAST(N'2003-05-07T00:00:00.000' AS DateTime), CAST(N'2023-04-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[User] ([UserId], [UserFirstName], [UserLastName], [UserName], [UserPasswordHash], [Salt], [LastLogIn], [DateJoined]) VALUES (11, N'Chinyere', N'Ejeckam', N'chichi', N'password', N'salt', CAST(N'2023-04-02T19:40:00.983' AS DateTime), CAST(N'2023-04-02T19:40:00.983' AS DateTime))
GO
INSERT [dbo].[User] ([UserId], [UserFirstName], [UserLastName], [UserName], [UserPasswordHash], [Salt], [LastLogIn], [DateJoined]) VALUES (12, N'Jacob', N'Nodes', N'jnodes', N'password', N'salt', CAST(N'2023-04-02T19:40:39.390' AS DateTime), CAST(N'2023-04-02T19:40:39.390' AS DateTime))
GO
INSERT [dbo].[User] ([UserId], [UserFirstName], [UserLastName], [UserName], [UserPasswordHash], [Salt], [LastLogIn], [DateJoined]) VALUES (13, N'Taco', N'Bell', N'tbell', N'dong', N'salt', CAST(N'2023-04-09T15:22:27.860' AS DateTime), CAST(N'2023-04-09T15:22:27.860' AS DateTime))
GO
INSERT [dbo].[User] ([UserId], [UserFirstName], [UserLastName], [UserName], [UserPasswordHash], [Salt], [LastLogIn], [DateJoined]) VALUES (1013, N'first', N'last', N'username', N'password', N'salt', CAST(N'2023-04-23T18:38:58.283' AS DateTime), CAST(N'2023-04-23T18:38:58.283' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[User] OFF
GO
ALTER TABLE [dbo].[Entry]  WITH CHECK ADD  CONSTRAINT [FK_Entry_ExerciseGoal] FOREIGN KEY([ExerciseGoalId])
REFERENCES [dbo].[ExerciseGoal] ([ExerciseGoalId])
ON DELETE CASCADE
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
ALTER TABLE [dbo].[UserSystemRole]  WITH CHECK ADD  CONSTRAINT [FK_UserSystemRole_SystemRole] FOREIGN KEY([SystemRoldId])
REFERENCES [dbo].[SystemRole] ([SystemRoleId])
GO
ALTER TABLE [dbo].[UserSystemRole] CHECK CONSTRAINT [FK_UserSystemRole_SystemRole]
GO
ALTER TABLE [dbo].[UserSystemRole]  WITH CHECK ADD  CONSTRAINT [FK_UserSystemRole_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([UserId])
GO
ALTER TABLE [dbo].[UserSystemRole] CHECK CONSTRAINT [FK_UserSystemRole_User]
GO
