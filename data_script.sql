
USE [PastExamsHub]

DELETE FROM [PastExamsHub].[dbo].[ExamPeriodExam]
DELETE FROM [PastExamsHub].[dbo].[ExamSolutionGrades]
DELETE FROM [PastExamsHub].[dbo].[ExamSolutions]
DELETE FROM [PastExamsHub].[dbo].[Exams]
DELETE FROM [PastExamsHub].[dbo].[ExamPeriods]
DELETE FROM [PastExamsHub].[dbo].[Courses]
DELETE FROM [PastExamsHub].[dbo].[Users]
DELETE FROM [PastExamsHub].[dbo].[Files]

GO
SET IDENTITY_INSERT [dbo].[ExamPeriods] ON 
GO
INSERT [dbo].[ExamPeriods] ([Id], [Name], [StartDate], [EndDate], [PeriodType], [IsSoftDeleted], [Uid]) VALUES (1, N'Januarski 2023', CAST(N'2023-01-15T15:01:57.9710000' AS DateTime2), CAST(N'2023-02-09T15:01:57.9710000' AS DateTime2), 1, 0, N'januar23')
GO
INSERT [dbo].[ExamPeriods] ([Id], [Name], [StartDate], [EndDate], [PeriodType], [IsSoftDeleted], [Uid]) VALUES (2, N'Aprilski 2023', CAST(N'2023-03-25T15:01:57.9710000' AS DateTime2), CAST(N'2023-03-29T15:01:57.9710000' AS DateTime2), 2, 0, N'april23')
GO
INSERT [dbo].[ExamPeriods] ([Id], [Name], [StartDate], [EndDate], [PeriodType], [IsSoftDeleted], [Uid]) VALUES (3, N'Jun 2023', CAST(N'2023-06-03T15:01:57.9710000' AS DateTime2), CAST(N'2023-07-12T15:01:57.9710000' AS DateTime2), 3, 0, N'jun23')
GO
INSERT [dbo].[ExamPeriods] ([Id], [Name], [StartDate], [EndDate], [PeriodType], [IsSoftDeleted], [Uid]) VALUES (4, N'Jun II 2023', CAST(N'2023-07-01T15:01:57.9710000' AS DateTime2), CAST(N'2023-07-05T15:01:57.9710000' AS DateTime2), 4, 0, N'jun223')
GO
INSERT [dbo].[ExamPeriods] ([Id], [Name], [StartDate], [EndDate], [PeriodType], [IsSoftDeleted], [Uid]) VALUES (5, N'Septembarski 2023', CAST(N'2023-08-19T15:01:57.9710000' AS DateTime2), CAST(N'2023-08-30T15:01:57.9710000' AS DateTime2), 5, 0, N'septembar23')
GO
INSERT [dbo].[ExamPeriods] ([Id], [Name], [StartDate], [EndDate], [PeriodType], [IsSoftDeleted], [Uid]) VALUES (6, N'Oktobarski 2023', CAST(N'2023-09-09T15:01:57.9710000' AS DateTime2), CAST(N'2023-09-20T15:01:57.9710000' AS DateTime2), 6, 0, N'oktobar23')
GO
INSERT [dbo].[ExamPeriods] ([Id], [Name], [StartDate], [EndDate], [PeriodType], [IsSoftDeleted], [Uid]) VALUES (7, N'Oktobar || 2023', CAST(N'2023-10-01T15:01:57.9710000' AS DateTime2), CAST(N'2023-10-04T15:01:57.9710000' AS DateTime2), 7, 0, N'oktobar223')
GO
INSERT [dbo].[ExamPeriods] ([Id], [Name], [StartDate], [EndDate], [PeriodType], [IsSoftDeleted], [Uid]) VALUES (8, N'Januarski 2022', CAST(N'2022-01-15T15:01:57.9710000' AS DateTime2), CAST(N'2022-02-09T15:01:57.9710000' AS DateTime2), 1, 0, N'januar22')
GO
INSERT [dbo].[ExamPeriods] ([Id], [Name], [StartDate], [EndDate], [PeriodType], [IsSoftDeleted], [Uid]) VALUES (9, N'Aprilski 2022', CAST(N'2022-03-25T15:01:57.9710000' AS DateTime2), CAST(N'2022-03-29T15:01:57.9710000' AS DateTime2), 2, 0, N'april22')
GO
INSERT [dbo].[ExamPeriods] ([Id], [Name], [StartDate], [EndDate], [PeriodType], [IsSoftDeleted], [Uid]) VALUES (10, N'Jun 2022', CAST(N'2022-06-03T15:01:57.9710000' AS DateTime2), CAST(N'2022-07-12T15:01:57.9710000' AS DateTime2), 3, 0, N'jun22')
GO
INSERT [dbo].[ExamPeriods] ([Id], [Name], [StartDate], [EndDate], [PeriodType], [IsSoftDeleted], [Uid]) VALUES (11, N'Jun II 2022', CAST(N'2022-07-01T15:01:57.9710000' AS DateTime2), CAST(N'2022-07-05T15:01:57.9710000' AS DateTime2), 4, 0, N'jun222')
GO
INSERT [dbo].[ExamPeriods] ([Id], [Name], [StartDate], [EndDate], [PeriodType], [IsSoftDeleted], [Uid]) VALUES (12, N'Septembarski 2022', CAST(N'2022-08-19T15:01:57.9710000' AS DateTime2), CAST(N'2022-08-30T15:01:57.9710000' AS DateTime2), 5, 0, N'septembar22')
GO
INSERT [dbo].[ExamPeriods] ([Id], [Name], [StartDate], [EndDate], [PeriodType], [IsSoftDeleted], [Uid]) VALUES (13, N'Oktobarski 2022', CAST(N'2022-09-09T15:01:57.9710000' AS DateTime2), CAST(N'2022-09-20T15:01:57.9710000' AS DateTime2), 6, 0, N'oktobar22')
GO
INSERT [dbo].[ExamPeriods] ([Id], [Name], [StartDate], [EndDate], [PeriodType], [IsSoftDeleted], [Uid]) VALUES (14, N'Oktobar || 2022', CAST(N'2022-10-01T15:01:57.9710000' AS DateTime2), CAST(N'2022-10-04T15:01:57.9710000' AS DateTime2), 7, 0, N'oktobar222')
GO
INSERT [dbo].[ExamPeriods] ([Id], [Name], [StartDate], [EndDate], [PeriodType], [IsSoftDeleted], [Uid]) VALUES (15, N'Januarski 2021', CAST(N'2021-01-15T15:01:57.9710000' AS DateTime2), CAST(N'2021-02-09T15:01:57.9710000' AS DateTime2), 1, 0, N'januar21')
GO
INSERT [dbo].[ExamPeriods] ([Id], [Name], [StartDate], [EndDate], [PeriodType], [IsSoftDeleted], [Uid]) VALUES (16, N'Aprilski 2021', CAST(N'2021-03-25T15:01:57.9710000' AS DateTime2), CAST(N'2021-03-29T15:01:57.9710000' AS DateTime2), 2, 0, N'april21')
GO
INSERT [dbo].[ExamPeriods] ([Id], [Name], [StartDate], [EndDate], [PeriodType], [IsSoftDeleted], [Uid]) VALUES (17, N'Jun 2021', CAST(N'2021-06-03T15:01:57.9710000' AS DateTime2), CAST(N'2021-07-12T15:01:57.9710000' AS DateTime2), 3, 0, N'jun21')
GO
INSERT [dbo].[ExamPeriods] ([Id], [Name], [StartDate], [EndDate], [PeriodType], [IsSoftDeleted], [Uid]) VALUES (18, N'Jun II 2021', CAST(N'2021-07-01T15:01:57.9710000' AS DateTime2), CAST(N'2021-07-05T15:01:57.9710000' AS DateTime2), 4, 0, N'jun221')
GO
INSERT [dbo].[ExamPeriods] ([Id], [Name], [StartDate], [EndDate], [PeriodType], [IsSoftDeleted], [Uid]) VALUES (19, N'Septembarski 2021', CAST(N'2021-08-19T15:01:57.9710000' AS DateTime2), CAST(N'2021-08-30T15:01:57.9710000' AS DateTime2), 5, 0, N'septembar21')
GO
INSERT [dbo].[ExamPeriods] ([Id], [Name], [StartDate], [EndDate], [PeriodType], [IsSoftDeleted], [Uid]) VALUES (20, N'Oktobarski 2021', CAST(N'2021-09-09T15:01:57.9710000' AS DateTime2), CAST(N'2021-09-20T15:01:57.9710000' AS DateTime2), 6, 0, N'oktobar21')
GO
INSERT [dbo].[ExamPeriods] ([Id], [Name], [StartDate], [EndDate], [PeriodType], [IsSoftDeleted], [Uid]) VALUES (21, N'Oktobar || 2021', CAST(N'2021-10-01T15:01:57.9710000' AS DateTime2), CAST(N'2021-10-04T15:01:57.9710000' AS DateTime2), 7, 0, N'oktobar221')
GO
INSERT [dbo].[ExamPeriods] ([Id], [Name], [StartDate], [EndDate], [PeriodType], [IsSoftDeleted], [Uid]) VALUES (22, N'Januarski 2019', CAST(N'2019-01-15T15:01:57.9710000' AS DateTime2), CAST(N'2019-02-09T15:01:57.9710000' AS DateTime2), 1, 0, N'januar19')
GO
INSERT [dbo].[ExamPeriods] ([Id], [Name], [StartDate], [EndDate], [PeriodType], [IsSoftDeleted], [Uid]) VALUES (23, N'Aprilski 2019', CAST(N'2019-03-25T15:01:57.9710000' AS DateTime2), CAST(N'2019-03-29T15:01:57.9710000' AS DateTime2), 2, 0, N'april19')
GO
INSERT [dbo].[ExamPeriods] ([Id], [Name], [StartDate], [EndDate], [PeriodType], [IsSoftDeleted], [Uid]) VALUES (24, N'Jun 2019', CAST(N'2019-06-03T15:01:57.9710000' AS DateTime2), CAST(N'2019-07-12T15:01:57.9710000' AS DateTime2), 3, 0, N'jun19')
GO
INSERT [dbo].[ExamPeriods] ([Id], [Name], [StartDate], [EndDate], [PeriodType], [IsSoftDeleted], [Uid]) VALUES (25, N'Jun II 2019', CAST(N'2019-07-01T15:01:57.9710000' AS DateTime2), CAST(N'2019-07-05T15:01:57.9710000' AS DateTime2), 4, 0, N'jun219')
GO
INSERT [dbo].[ExamPeriods] ([Id], [Name], [StartDate], [EndDate], [PeriodType], [IsSoftDeleted], [Uid]) VALUES (26, N'Septembarski 2019', CAST(N'2019-08-19T15:01:57.9710000' AS DateTime2), CAST(N'2019-08-30T15:01:57.9710000' AS DateTime2), 5, 0, N'septembar19')
GO
INSERT [dbo].[ExamPeriods] ([Id], [Name], [StartDate], [EndDate], [PeriodType], [IsSoftDeleted], [Uid]) VALUES (27, N'Oktobarski 2019', CAST(N'2019-09-09T15:01:57.9710000' AS DateTime2), CAST(N'2019-09-20T15:01:57.9710000' AS DateTime2), 6, 0, N'oktobar19')
GO
INSERT [dbo].[ExamPeriods] ([Id], [Name], [StartDate], [EndDate], [PeriodType], [IsSoftDeleted], [Uid]) VALUES (28, N'Oktobar || 2019', CAST(N'2019-10-01T15:01:57.9710000' AS DateTime2), CAST(N'2019-10-04T15:01:57.9710000' AS DateTime2), 7, 0, N'oktobar219')
GO
INSERT [dbo].[ExamPeriods] ([Id], [Name], [StartDate], [EndDate], [PeriodType], [IsSoftDeleted], [Uid]) VALUES (29, N'Januarski 2018', CAST(N'2018-01-15T15:01:57.9710000' AS DateTime2), CAST(N'2018-02-09T15:01:57.9710000' AS DateTime2), 1, 0, N'januar18')
GO
INSERT [dbo].[ExamPeriods] ([Id], [Name], [StartDate], [EndDate], [PeriodType], [IsSoftDeleted], [Uid]) VALUES (30, N'Aprilski 2018', CAST(N'2018-03-25T15:01:57.9710000' AS DateTime2), CAST(N'2018-03-29T15:01:57.9710000' AS DateTime2), 2, 0, N'april18')
GO
INSERT [dbo].[ExamPeriods] ([Id], [Name], [StartDate], [EndDate], [PeriodType], [IsSoftDeleted], [Uid]) VALUES (31, N'Jun 2018', CAST(N'2018-06-03T15:01:57.9710000' AS DateTime2), CAST(N'2018-07-12T15:01:57.9710000' AS DateTime2), 3, 0, N'jun18')
GO
INSERT [dbo].[ExamPeriods] ([Id], [Name], [StartDate], [EndDate], [PeriodType], [IsSoftDeleted], [Uid]) VALUES (32, N'Jun II 2018', CAST(N'2018-07-01T15:01:57.9710000' AS DateTime2), CAST(N'2018-07-05T15:01:57.9710000' AS DateTime2), 4, 0, N'jun218')
GO
INSERT [dbo].[ExamPeriods] ([Id], [Name], [StartDate], [EndDate], [PeriodType], [IsSoftDeleted], [Uid]) VALUES (33, N'Septembarski 2018', CAST(N'2018-08-19T15:01:57.9710000' AS DateTime2), CAST(N'2018-08-30T15:01:57.9710000' AS DateTime2), 5, 0, N'septembar18')
GO
INSERT [dbo].[ExamPeriods] ([Id], [Name], [StartDate], [EndDate], [PeriodType], [IsSoftDeleted], [Uid]) VALUES (34, N'Oktobarski 2018', CAST(N'2018-09-09T15:01:57.9710000' AS DateTime2), CAST(N'2018-09-20T15:01:57.9710000' AS DateTime2), 6, 0, N'oktobar18')
GO
INSERT [dbo].[ExamPeriods] ([Id], [Name], [StartDate], [EndDate], [PeriodType], [IsSoftDeleted], [Uid]) VALUES (35, N'Oktobar || 2018', CAST(N'2018-10-01T15:01:57.9710000' AS DateTime2), CAST(N'2018-10-04T15:01:57.9710000' AS DateTime2), 7, 0, N'oktobar218')
GO
SET IDENTITY_INSERT [dbo].[ExamPeriods] OFF
GO


SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Role], [Index], [StudyYear], [Gender], [FullName], [Uid]) VALUES (1, N'administrator@localhostt', N'Administrator', N'System', 1, NULL, NULL, 1, NULL, N'admin')
GO
INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Role], [Index], [StudyYear], [Gender], [FullName], [Uid]) VALUES (2, N'profesor@localhost', N'Profesor', N'Elfakovic', 3, NULL, NULL, 1, NULL, N'profesor')
GO
INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Role], [Index], [StudyYear], [Gender], [FullName], [Uid]) VALUES (3, N'profesorDragan@localhost', N'Dragan', N'Stojanovic', 3, NULL, NULL, 1, N'Dragan Stojanovic', N'profesorDragan')
GO
INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Role], [Index], [StudyYear], [Gender], [FullName], [Uid]) VALUES (8, N'profesorAleksandar@localhost', N'Aleksandar', N'Stanimirovic', 3, NULL, NULL, 1, N'Aleksandar Stanimirovic', N'pprofesorAleksandar')
GO
INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Role], [Index], [StudyYear], [Gender], [FullName], [Uid]) VALUES (9, N'profesorEmina@localhost', N'Emina', N'Milovanovic', 3, NULL, NULL, 2, N'Emina Milovanovic', N'profesorEmina')
GO
INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Role], [Index], [StudyYear], [Gender], [FullName], [Uid]) VALUES (10, N'profesorVladimir@localhost', N'Vladimir', N'Simic', 3, NULL, NULL, 1, N'Vladimir Simic', N'profesorVladimir')
GO
INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Role], [Index], [StudyYear], [Gender], [FullName], [Uid]) VALUES (11, N'profesorIvan@localhost', N'Ivan', N'Petkovic', 3, NULL, NULL, 1, N'Ivan Petkovic', N'profesorIvan')
GO
INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Role], [Index], [StudyYear], [Gender], [FullName], [Uid]) VALUES (12, N'profesorMarija@localhost', N'Marija', N'Veljanovski', 3, NULL, NULL, 2, N'Marija Veljanovski', N'profesorMarija')
GO
INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Role], [Index], [StudyYear], [Gender], [FullName], [Uid]) VALUES (13, N'profeosrIgor@localhost', N'Igor', N'Antolovic', 3, NULL, NULL, 1, N'Igor Antolovic', N'profesorIgor')
GO
INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Role], [Index], [StudyYear], [Gender], [FullName], [Uid]) VALUES (14, N'profesorNikola@localhost', N'Nikola', N'Davidovic', 3, NULL, NULL, 1, N'Nikola Davidovic', N'profesorNikola')
GO
INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Role], [Index], [StudyYear], [Gender], [FullName], [Uid]) VALUES (15, N'profeosrNatalija@localhost', N'Natalija', N'Stojanovic', 3, NULL, NULL, 2, N'Natalija Stojanovic', N'profesorNatalija')
GO
INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Role], [Index], [StudyYear], [Gender], [FullName], [Uid]) VALUES (18, N'profesorAleksandra@localhost', N'Aleksandra', N'Stojnev', 3, NULL, NULL, 2, N'Aleksandra Stojnev', N'profesorAleksandra')
GO
INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Role], [Index], [StudyYear], [Gender], [FullName], [Uid]) VALUES (19, N'studentUros@localhost', N'Uros', N'Markovic', 2, NULL, NULL, 1, N'Uros Markovic', N'studentUros')
GO
INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Role], [Index], [StudyYear], [Gender], [FullName], [Uid]) VALUES (20, N'studentPetar@localhost', N'Petar', N'Maravic', 2, NULL, NULL, 1, N'Petar Maravic', N'studentPetar')
GO
INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Role], [Index], [StudyYear], [Gender], [FullName], [Uid]) VALUES (21, N'studentVladimir@localhost', N'Vladimir', N'Milosevic', 2, NULL, NULL, 1, N'Vladimir Milosevic', N'studentVladimir')
GO
INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Role], [Index], [StudyYear], [Gender], [FullName], [Uid]) VALUES (22, N'studentAndrija@localhost', N'Andrija', N'Radosavljevic', 2, NULL, NULL, 1, N'Andrija Radosavljevic', N'studentAndrija')
GO
INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Role], [Index], [StudyYear], [Gender], [FullName], [Uid]) VALUES (23, N'studentSara@localhost', N'Sara', N'Stojanovic', 2, NULL, NULL, 2, N'Sara Stojanovic', N'studentSara')
GO
INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Role], [Index], [StudyYear], [Gender], [FullName], [Uid]) VALUES (24, N'studentMilan@localhost', N'Milan', N'Stojanovic', 2, NULL, NULL, 1, N'Milan Stojanovic', N'studentMilan')
GO
INSERT [dbo].[Users] ([Id], [Email], [FirstName], [LastName], [Role], [Index], [StudyYear], [Gender], [FullName], [Uid]) VALUES (25, N'studentDanilo@localhost', N'Danilo', N'Markovic', 2, NULL, NULL, 1, N'Danilo Markovic', N'studentDanilo')
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
SET IDENTITY_INSERT [dbo].[Courses] ON 
GO
INSERT [dbo].[Courses] ([Id], [Name], [CourseType], [StudyType], [LecturerId], [StudyYear], [Semester], [ESPB], [IsSoftDeleted], [Uid]) VALUES (1, N'Algoritmi i programiranje', 1, 1, 18, 1, 2, 6, 0, N'aip')
GO
INSERT [dbo].[Courses] ([Id], [Name], [CourseType], [StudyType], [LecturerId], [StudyYear], [Semester], [ESPB], [IsSoftDeleted], [Uid]) VALUES (2, N'Elektronske komponente', 1, 1, 11, 1, 1, 6, 0, N'elkomp')
GO
INSERT [dbo].[Courses] ([Id], [Name], [CourseType], [StudyType], [LecturerId], [StudyYear], [Semester], [ESPB], [IsSoftDeleted], [Uid]) VALUES (3, N'Fizika', 1, 1, 2, 1, 1, 6, 0, N'fizika')
GO
INSERT [dbo].[Courses] ([Id], [Name], [CourseType], [StudyType], [LecturerId], [StudyYear], [Semester], [ESPB], [IsSoftDeleted], [Uid]) VALUES (4, N'Lab praktikum - Fizika', 1, 1, 11, 1, 1, 3, 0, N'labfizika')
GO
INSERT [dbo].[Courses] ([Id], [Name], [CourseType], [StudyType], [LecturerId], [StudyYear], [Semester], [ESPB], [IsSoftDeleted], [Uid]) VALUES (5, N'Matematika 1', 1, 1, 18, 1, 1, 6, 0, N'mat1')
GO
INSERT [dbo].[Courses] ([Id], [Name], [CourseType], [StudyType], [LecturerId], [StudyYear], [Semester], [ESPB], [IsSoftDeleted], [Uid]) VALUES (6, N'Matematika 2', 1, 1, 13, 1, 2, 5, 0, N'mat2')
GO
INSERT [dbo].[Courses] ([Id], [Name], [CourseType], [StudyType], [LecturerId], [StudyYear], [Semester], [ESPB], [IsSoftDeleted], [Uid]) VALUES (7, N'Osnovi elektrotehnike 1', 1, 1, 11, 1, 1, 6, 0, N'oe1')
GO
INSERT [dbo].[Courses] ([Id], [Name], [CourseType], [StudyType], [LecturerId], [StudyYear], [Semester], [ESPB], [IsSoftDeleted], [Uid]) VALUES (8, N'Osnovi elektrotehnike 2', 1, 1, 2, 1, 2, 6, 0, N'oe2')
GO
INSERT [dbo].[Courses] ([Id], [Name], [CourseType], [StudyType], [LecturerId], [StudyYear], [Semester], [ESPB], [IsSoftDeleted], [Uid]) VALUES (9, N'Uvod u elektroniku', 1, 1, 10, 1, 2, 3, 0, N'uue')
GO
INSERT [dbo].[Courses] ([Id], [Name], [CourseType], [StudyType], [LecturerId], [StudyYear], [Semester], [ESPB], [IsSoftDeleted], [Uid]) VALUES (10, N'Uvod u inzenjerstvo', 1, 1, 15, 1, 2, 3, 0, N'uui')
GO
INSERT [dbo].[Courses] ([Id], [Name], [CourseType], [StudyType], [LecturerId], [StudyYear], [Semester], [ESPB], [IsSoftDeleted], [Uid]) VALUES (11, N'Uvod u racunarstvo', 1, 1, 10, 1, 2, 3, 0, N'uur')
GO
INSERT [dbo].[Courses] ([Id], [Name], [CourseType], [StudyType], [LecturerId], [StudyYear], [Semester], [ESPB], [IsSoftDeleted], [Uid]) VALUES (12, N'Arhitektura racunara', 1, 1, 8, 2, 1, 6, 0, N'aor')
GO
INSERT [dbo].[Courses] ([Id], [Name], [CourseType], [StudyType], [LecturerId], [StudyYear], [Semester], [ESPB], [IsSoftDeleted], [Uid]) VALUES (13, N'Baze Podataka', 1, 1, 3, 2, 1, 6, 0, N'baze')
GO
INSERT [dbo].[Courses] ([Id], [Name], [CourseType], [StudyType], [LecturerId], [StudyYear], [Semester], [ESPB], [IsSoftDeleted], [Uid]) VALUES (14, N'Digitalna elektronika', 1, 1, 10, 2, 1, 5, 0, N'digitalelekt')
GO
INSERT [dbo].[Courses] ([Id], [Name], [CourseType], [StudyType], [LecturerId], [StudyYear], [Semester], [ESPB], [IsSoftDeleted], [Uid]) VALUES (15, N'Diskretna matematika', 1, 1, 3, 2, 1, 5, 0, N'diskrmat')
GO
INSERT [dbo].[Courses] ([Id], [Name], [CourseType], [StudyType], [LecturerId], [StudyYear], [Semester], [ESPB], [IsSoftDeleted], [Uid]) VALUES (16, N'Logicko projektovanje', 2, 1, 15, 2, 2, 5, 0, N'logproj')
GO
INSERT [dbo].[Courses] ([Id], [Name], [CourseType], [StudyType], [LecturerId], [StudyYear], [Semester], [ESPB], [IsSoftDeleted], [Uid]) VALUES (17, N'Matematicki metodi', 2, 1, 15, 2, 1, 6, 0, N'mmur')
GO
INSERT [dbo].[Courses] ([Id], [Name], [CourseType], [StudyType], [LecturerId], [StudyYear], [Semester], [ESPB], [IsSoftDeleted], [Uid]) VALUES (18, N'Objektno programiranje', 1, 1, 2, 2, 2, 6, 0, N'oop')
GO
INSERT [dbo].[Courses] ([Id], [Name], [CourseType], [StudyType], [LecturerId], [StudyYear], [Semester], [ESPB], [IsSoftDeleted], [Uid]) VALUES (19, N'Programski jezici', 1, 1, 9, 2, 1, 6, 0, N'pj')
GO
INSERT [dbo].[Courses] ([Id], [Name], [CourseType], [StudyType], [LecturerId], [StudyYear], [Semester], [ESPB], [IsSoftDeleted], [Uid]) VALUES (20, N'Strukture Podataka', 1, 1, 2, 2, 2, 6, 0, N'strukture')
GO
INSERT [dbo].[Courses] ([Id], [Name], [CourseType], [StudyType], [LecturerId], [StudyYear], [Semester], [ESPB], [IsSoftDeleted], [Uid]) VALUES (21, N'Racunarski Sistemi', 1, 1, 10, 2, 1, 6, 0, N'rs')
GO
INSERT [dbo].[Courses] ([Id], [Name], [CourseType], [StudyType], [LecturerId], [StudyYear], [Semester], [ESPB], [IsSoftDeleted], [Uid]) VALUES (22, N'Teorija grafova', 2, 1, 8, 2, 1, 6, 0, N'tg')
GO
INSERT [dbo].[Courses] ([Id], [Name], [CourseType], [StudyType], [LecturerId], [StudyYear], [Semester], [ESPB], [IsSoftDeleted], [Uid]) VALUES (23, N'Verovatnoca i statistika', 2, 1, 13, 2, 2, 6, 0, N'statistika')
GO
INSERT [dbo].[Courses] ([Id], [Name], [CourseType], [StudyType], [LecturerId], [StudyYear], [Semester], [ESPB], [IsSoftDeleted], [Uid]) VALUES (24, N'Distribuirani Sistemi', 1, 1, 2, 3, 1, 6, 0, N'ds')
GO
INSERT [dbo].[Courses] ([Id], [Name], [CourseType], [StudyType], [LecturerId], [StudyYear], [Semester], [ESPB], [IsSoftDeleted], [Uid]) VALUES (25, N'Engleski jezik 1', 1, 1, 18, 3, 1, 6, 0, N'eng1')
GO
INSERT [dbo].[Courses] ([Id], [Name], [CourseType], [StudyType], [LecturerId], [StudyYear], [Semester], [ESPB], [IsSoftDeleted], [Uid]) VALUES (26, N'Engleski jezik 2', 1, 1, 13, 3, 1, 6, 0, N'eng2')
GO
INSERT [dbo].[Courses] ([Id], [Name], [CourseType], [StudyType], [LecturerId], [StudyYear], [Semester], [ESPB], [IsSoftDeleted], [Uid]) VALUES (27, N'Informacioni sistemi', 1, 1, 14, 3, 1, 6, 0, N'is')
GO
INSERT [dbo].[Courses] ([Id], [Name], [CourseType], [StudyType], [LecturerId], [StudyYear], [Semester], [ESPB], [IsSoftDeleted], [Uid]) VALUES (28, N'Mikroracunarski sistemi', 1, 1, 14, 3, 2, 6, 0, N'mkis')
GO
INSERT [dbo].[Courses] ([Id], [Name], [CourseType], [StudyType], [LecturerId], [StudyYear], [Semester], [ESPB], [IsSoftDeleted], [Uid]) VALUES (29, N'Objektno projektovanje', 1, 1, 2, 3, 1, 6, 0, N'ooproj')
GO
INSERT [dbo].[Courses] ([Id], [Name], [CourseType], [StudyType], [LecturerId], [StudyYear], [Semester], [ESPB], [IsSoftDeleted], [Uid]) VALUES (30, N'Racunarske mreze', 1, 1, 15, 3, 1, 6, 0, N'mreze')
GO
INSERT [dbo].[Courses] ([Id], [Name], [CourseType], [StudyType], [LecturerId], [StudyYear], [Semester], [ESPB], [IsSoftDeleted], [Uid]) VALUES (31, N'Sistemi baza podataka', 1, 1, 14, 3, 2, 6, 0, N'sitemibaza')
GO
INSERT [dbo].[Courses] ([Id], [Name], [CourseType], [StudyType], [LecturerId], [StudyYear], [Semester], [ESPB], [IsSoftDeleted], [Uid]) VALUES (32, N'Softversko inzenjerstvo', 1, 1, 2, 3, 2, 6, 0, N'softversko')
GO
INSERT [dbo].[Courses] ([Id], [Name], [CourseType], [StudyType], [LecturerId], [StudyYear], [Semester], [ESPB], [IsSoftDeleted], [Uid]) VALUES (33, N'Web programiranje', 1, 1, 9, 3, 2, 6, 0, N'webprog')
GO
INSERT [dbo].[Courses] ([Id], [Name], [CourseType], [StudyType], [LecturerId], [StudyYear], [Semester], [ESPB], [IsSoftDeleted], [Uid]) VALUES (34, N'Napredne baze podataka', 1, 1, 3, 4, 2, 6, 0, N'npbaze')
GO
INSERT [dbo].[Courses] ([Id], [Name], [CourseType], [StudyType], [LecturerId], [StudyYear], [Semester], [ESPB], [IsSoftDeleted], [Uid]) VALUES (35, N'Paralelni sistemi', 1, 1, 9, 4, 1, 6, 0, N'ps')
GO
INSERT [dbo].[Courses] ([Id], [Name], [CourseType], [StudyType], [LecturerId], [StudyYear], [Semester], [ESPB], [IsSoftDeleted], [Uid]) VALUES (36, N'Programski prevodioci', 1, 1, 14, 4, 1, 6, 0, N'pprevodioci')
GO
INSERT [dbo].[Courses] ([Id], [Name], [CourseType], [StudyType], [LecturerId], [StudyYear], [Semester], [ESPB], [IsSoftDeleted], [Uid]) VALUES (37, N'Racunarska grafika', 1, 1, 3, 4, 2, 6, 0, N'grafika')
GO
INSERT [dbo].[Courses] ([Id], [Name], [CourseType], [StudyType], [LecturerId], [StudyYear], [Semester], [ESPB], [IsSoftDeleted], [Uid]) VALUES (38, N'Vestacka inteligencija', 1, 1, 8, 4, 2, 6, 0, N'vestacka')
GO
INSERT [dbo].[Courses] ([Id], [Name], [CourseType], [StudyType], [LecturerId], [StudyYear], [Semester], [ESPB], [IsSoftDeleted], [Uid]) VALUES (39, N'Zastita informacija', 1, 1, 9, 4, 1, 6, 0, N'zastita')
GO
SET IDENTITY_INSERT [dbo].[Courses] OFF


GO
SET IDENTITY_INSERT [dbo].[Files] ON 
GO
INSERT [dbo].[Files] ([Id], [FileName], [FilePath], [Type], [Uid], [IsSolution]) VALUES (1, N'test-image.jpg', N'..\Infrastructure\Resources\Images\test-image.jpg', 2, N'imageTest', 0)
GO
INSERT [dbo].[Files] ([Id], [FileName], [FilePath], [Type], [Uid], [IsSolution]) VALUES (2, N'test-pdf.pdf', N'..\Infrastructure\Resources\Documents\test-pdf.pdf', 1, N'pdfTest', 0)
GO
SET IDENTITY_INSERT [dbo].[Files] OFF
GO
SET IDENTITY_INSERT [dbo].[Exams] ON 
GO
INSERT [dbo].[Exams] ([Id], [CourseId], [PeriodId], [FileId], [Type], [ExamDate], [CreatedDateTimeUtc], [NumberOfTasks], [Notes], [IsSoftDeleted], [Uid]) VALUES (1, 1, 5, 2, 1, CAST(N'2023-08-22T23:26:16.2470000' AS DateTime2), CAST(N'2024-02-07T23:27:11.7109070' AS DateTime2), 5, N'Ispit iz algoritma i programiranja', 0, N'eb729c8c-ddff-420b-8c29-9347c9696efa')
GO
INSERT [dbo].[Exams] ([Id], [CourseId], [PeriodId], [FileId], [Type], [ExamDate], [CreatedDateTimeUtc], [NumberOfTasks], [Notes], [IsSoftDeleted], [Uid]) VALUES (2, 13, 15, 2, 1, CAST(N'2021-01-22T23:26:16.2470000' AS DateTime2), CAST(N'2024-02-07T23:26:34.9465133' AS DateTime2), 2, N'Ispit iz baza', 0, N'66ddc0a7-4764-487f-9ef6-f89da6123875')
GO
INSERT [dbo].[Exams] ([Id], [CourseId], [PeriodId], [FileId], [Type], [ExamDate], [CreatedDateTimeUtc], [NumberOfTasks], [Notes], [IsSoftDeleted], [Uid]) VALUES (3, 32, 1, 2, 2, CAST(N'2023-01-22T23:26:16.2470000' AS DateTime2), CAST(N'2024-02-07T23:25:15.3136009' AS DateTime2), 4, N'Ispit iz Softverskog', 0, N'44daad75-1612-4189-80f9-7661b1fcd673')
GO
INSERT [dbo].[Exams] ([Id], [CourseId], [PeriodId], [FileId], [Type], [ExamDate], [CreatedDateTimeUtc], [NumberOfTasks], [Notes], [IsSoftDeleted], [Uid]) VALUES (4, 37, 14, 2, 1, CAST(N'2022-10-03T23:26:16.2470000' AS DateTime2), CAST(N'2024-02-07T23:24:31.8025714' AS DateTime2), 4, N'Ispit iz Grafike', 0, N'6969fd77-2c0d-4194-8182-58c3d6f1f238')
GO
INSERT [dbo].[Exams] ([Id], [CourseId], [PeriodId], [FileId], [Type], [ExamDate], [CreatedDateTimeUtc], [NumberOfTasks], [Notes], [IsSoftDeleted], [Uid]) VALUES (5, 31, 31, 2, 3, CAST(N'2018-06-13T23:26:16.2470000' AS DateTime2), CAST(N'2024-02-07T23:23:41.6987281' AS DateTime2), 2, N'Ispit iz Sisitema baza', 0, N'b526b24e-3ffa-40ad-b428-6054ceb811b3')
GO
INSERT [dbo].[Exams] ([Id], [CourseId], [PeriodId], [FileId], [Type], [ExamDate], [CreatedDateTimeUtc], [NumberOfTasks], [Notes], [IsSoftDeleted], [Uid]) VALUES (6, 2, 16, 2, 2, CAST(N'2021-03-26T23:26:16.2470000' AS DateTime2), CAST(N'2024-02-07T23:22:05.0988724' AS DateTime2), 10, N'Ispit iz Komponenti', 0, N'246a5132-0110-4a2d-9884-be364ddada94')
GO
INSERT [dbo].[Exams] ([Id], [CourseId], [PeriodId], [FileId], [Type], [ExamDate], [CreatedDateTimeUtc], [NumberOfTasks], [Notes], [IsSoftDeleted], [Uid]) VALUES (7, 19, 32, 2, 3, CAST(N'2018-07-02T23:26:16.2470000' AS DateTime2), CAST(N'2024-02-07T23:21:11.1716408' AS DateTime2), 5, N'Ispit iz Programskih jezika', 0, N'89c43eaa-fc19-4204-87df-e1b92f6fa633')
GO
SET IDENTITY_INSERT [dbo].[Exams] OFF
GO


SET IDENTITY_INSERT [dbo].[ExamPeriodExam] ON 
GO
INSERT [dbo].[ExamPeriodExam] ([Id], [ExamPeriodId], [ExamId], [Uid]) VALUES (1, 5, 1, N'63400138-e58f-4d76-b7c4-7e61aa0d33d8')
GO
INSERT [dbo].[ExamPeriodExam] ([Id], [ExamPeriodId], [ExamId], [Uid]) VALUES (2, 15, 2, N'64a3e9c2-70f1-4f11-9e12-9ab0b7c20739')
GO
INSERT [dbo].[ExamPeriodExam] ([Id], [ExamPeriodId], [ExamId], [Uid]) VALUES (3, 1, 3, N'71b38421-353c-412f-94ca-bd5546160013')
GO
INSERT [dbo].[ExamPeriodExam] ([Id], [ExamPeriodId], [ExamId], [Uid]) VALUES (4, 14, 4, N'50b45ae2-7f2a-4c58-b3af-41a286bfc27b')
GO
INSERT [dbo].[ExamPeriodExam] ([Id], [ExamPeriodId], [ExamId], [Uid]) VALUES (5, 31, 5, N'91d7cfab-12e5-43ab-b17a-a7e394fe391f')
GO
INSERT [dbo].[ExamPeriodExam] ([Id], [ExamPeriodId], [ExamId], [Uid]) VALUES (6, 16, 6, N'fba7e082-7b9b-48ba-9b79-cf0d1c2edc39')
GO
INSERT [dbo].[ExamPeriodExam] ([Id], [ExamPeriodId], [ExamId], [Uid]) VALUES (7, 32, 7, N'7d160b25-58d6-4ab6-97c9-e474ed896615')
GO
SET IDENTITY_INSERT [dbo].[ExamPeriodExam] OFF
UPDATE [dbo].[ExamPeriods] SET CreatedById = 2
UPDATE [dbo].[Exams] SET CreatedById = 2
UPDATE [dbo].[Courses] SET CreatedById = 2

GO
