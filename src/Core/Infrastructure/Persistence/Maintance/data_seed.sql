USE [PastExamsHub]
GO
SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Role], [Index], [StudyYear], [Gender], [Uid]) VALUES (1, N'umarkovic864@gmail.com', N'Uros', N'Markovic', 2, 16690, 4, 1, N'uros')
INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Role], [Index], [StudyYear], [Gender], [Uid]) VALUES (3, N'valenejkovic@gmail.com', N'Valentina', N'Nejkovic', 1, null, null, 2, N'valentina')
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO


USE [PastExamsHub]
GO
SET IDENTITY_INSERT [dbo].[ExamPeriods] ON 

INSERT [dbo].[ExamPeriods] ([Id], [Name], [StartDate], [EndDate], [PeriodType], [Uid]) VALUES (1, N'Januarski 2023', CAST(N'2023-01-15T15:01:57.9710000' AS DateTime2), CAST(N'2023-02-09T15:01:57.9710000' AS DateTime2), 1, N'januar23')
INSERT [dbo].[ExamPeriods] ([Id], [Name], [StartDate], [EndDate], [PeriodType], [Uid]) VALUES (2, N'Aprilski 2023', CAST(N'2023-03-25T15:01:57.9710000' AS DateTime2), CAST(N'2023-03-29T15:01:57.9710000' AS DateTime2), 2, N'april23')
INSERT [dbo].[ExamPeriods] ([Id], [Name], [StartDate], [EndDate], [PeriodType], [Uid]) VALUES (3, N'Jun 2023', CAST(N'2023-06-03T15:01:57.9710000' AS DateTime2), CAST(N'2023-07-12T15:01:57.9710000' AS DateTime2), 3, N'jun23')
INSERT [dbo].[ExamPeriods] ([Id], [Name], [StartDate], [EndDate], [PeriodType], [Uid]) VALUES (4, N'Jun II 2023', CAST(N'2023-07-01T15:01:57.9710000' AS DateTime2), CAST(N'2023-07-05T15:01:57.9710000' AS DateTime2), 4, N'jun223')
INSERT [dbo].[ExamPeriods] ([Id], [Name], [StartDate], [EndDate], [PeriodType], [Uid]) VALUES (5, N'Septembarski 2023', CAST(N'2023-08-19T15:01:57.9710000' AS DateTime2), CAST(N'2023-08-30T15:01:57.9710000' AS DateTime2), 5, N'septembar23')
INSERT [dbo].[ExamPeriods] ([Id], [Name], [StartDate], [EndDate], [PeriodType], [Uid]) VALUES (6, N'Oktobarski 2023', CAST(N'2023-09-09T15:01:57.9710000' AS DateTime2), CAST(N'2023-09-20T15:01:57.9710000' AS DateTime2), 6, N'oktobar23')
INSERT [dbo].[ExamPeriods] ([Id], [Name], [StartDate], [EndDate], [PeriodType], [Uid]) VALUES (7, N'Oktobar || 2023', CAST(N'2023-10-01T15:01:57.9710000' AS DateTime2), CAST(N'2023-10-4T15:01:57.9710000' AS DateTime2), 7, N'oktobar223')
INSERT [dbo].[ExamPeriods] ([Id], [Name], [StartDate], [EndDate], [PeriodType], [Uid]) VALUES (8, N'Decembarski 2023', CAST(N'2023-12-01T15:01:57.9710000' AS DateTime2), CAST(N'2023-12-04T15:01:57.9710000' AS DateTime2), 8, N'decembar23')
SET IDENTITY_INSERT [dbo].[ExamPeriods] OFF
GO
