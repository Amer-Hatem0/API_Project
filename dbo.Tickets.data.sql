SET IDENTITY_INSERT [dbo].[Tickets] ON
INSERT INTO [dbo].[Tickets] ([Id], [Type], [Status], [EventId], [BoughtBy], [Price], [Created_At], [Updated_At]) VALUES (2, 1, 1, 4, N'a', CAST(10.00 AS Decimal(18, 2)), N'2025-01-01 00:00:00', NULL)
INSERT INTO [dbo].[Tickets] ([Id], [Type], [Status], [EventId], [BoughtBy], [Price], [Created_At], [Updated_At]) VALUES (17, 2, 3, 1, N'l', CAST(11.00 AS Decimal(18, 2)), N'2025-01-01 00:00:00', N'2025-01-25 09:08:29')
INSERT INTO [dbo].[Tickets] ([Id], [Type], [Status], [EventId], [BoughtBy], [Price], [Created_At], [Updated_At]) VALUES (18, 3, 3, 1, N'string', CAST(0.00 AS Decimal(18, 2)), N'2025-01-25 00:23:54', N'2025-01-25 00:23:54')
SET IDENTITY_INSERT [dbo].[Tickets] OFF
