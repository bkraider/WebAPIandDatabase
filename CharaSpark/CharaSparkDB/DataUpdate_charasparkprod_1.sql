/*
This script was created by Visual Studio on 4/16/2015 at 8:50 PM.
Run this script on k8zhstkqk0.database.windows.net.charasparkprod (CharityWarrior) to make it the same as k8zhstkqk0.database.windows.net.charaspark (CharityWarrior).
This script performs its actions in the following order:
1. Disable foreign-key constraints.
2. Perform DELETE commands. 
3. Perform UPDATE commands.
4. Perform INSERT commands.
5. Re-enable foreign-key constraints.
Please back up your target database before running this script.
*/
SET NUMERIC_ROUNDABORT OFF
GO
SET XACT_ABORT, ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
/*Pointer used for text / image updates. This might not be needed, but is declared here just in case*/
DECLARE @pv binary(16)
BEGIN TRANSACTION
ALTER TABLE [dbo].[wishes] DROP CONSTRAINT [FK_wishes_wish_status]
ALTER TABLE [dbo].[wishes] DROP CONSTRAINT [FK_wishes_users]
ALTER TABLE [dbo].[donations] DROP CONSTRAINT [FK_donations_donation_status]
ALTER TABLE [dbo].[donations] DROP CONSTRAINT [FK_donations_users]
SET IDENTITY_INSERT [dbo].[users] ON
INSERT INTO [dbo].[users] ([user_id], [first_name], [middle_name], [last_name], [former_name], [login_id], [e_mail], [create_date], [created_by], [update_date], [is_active], [is_donor]) VALUES (1, N'bhanu', N'k', N'korremula', N'kiran', N'bkraider', N'bkraider@gmail.com', '20150101 00:00:00.000', N'bkraider', NULL, 1, 1)
INSERT INTO [dbo].[users] ([user_id], [first_name], [middle_name], [last_name], [former_name], [login_id], [e_mail], [create_date], [created_by], [update_date], [is_active], [is_donor]) VALUES (2, N'david', N'h', N'he', N'd', N'davidh', N'davidh@gmail.com', '20150101 00:00:00.000', N'bkraider', NULL, 1, 0)
INSERT INTO [dbo].[users] ([user_id], [first_name], [middle_name], [last_name], [former_name], [login_id], [e_mail], [create_date], [created_by], [update_date], [is_active], [is_donor]) VALUES (3, N'daniel', N'', N'du', N'u', N'danield', N'danield@gmail.com', '20150101 00:00:00.000', N'bkraider', NULL, 1, 0)
INSERT INTO [dbo].[users] ([user_id], [first_name], [middle_name], [last_name], [former_name], [login_id], [e_mail], [create_date], [created_by], [update_date], [is_active], [is_donor]) VALUES (4, N'lilly', N'l', N'l', N'u', N'lillyl', N'lillyl@gmail.com', '20150101 00:00:00.000', N'bkraider', NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[users] OFF
SET IDENTITY_INSERT [dbo].[donation_status] ON
INSERT INTO [dbo].[donation_status] ([donation_status_id], [donation_status_desc]) VALUES (1, N'IN PROGRESS')
INSERT INTO [dbo].[donation_status] ([donation_status_id], [donation_status_desc]) VALUES (2, N'COMPLETED')
INSERT INTO [dbo].[donation_status] ([donation_status_id], [donation_status_desc]) VALUES (3, N'REJECTED')
SET IDENTITY_INSERT [dbo].[donation_status] OFF
SET IDENTITY_INSERT [dbo].[wishes] ON
INSERT INTO [dbo].[wishes] ([wish_id], [wish_name], [wish_status_id], [create_date], [created_by], [update_date], [is_active], [start_date], [end_date], [user_id]) VALUES (2, N'Rake Leaves', 1, '20150415 00:00:00.000', N'bkraider', NULL, 1, '20150415 00:00:00.000', NULL, 1)
INSERT INTO [dbo].[wishes] ([wish_id], [wish_name], [wish_status_id], [create_date], [created_by], [update_date], [is_active], [start_date], [end_date], [user_id]) VALUES (3, N'Deliver lunch', 1, '20150414 00:00:00.000', N'bkraider', NULL, 1, '20150414 00:00:00.000', NULL, 2)
INSERT INTO [dbo].[wishes] ([wish_id], [wish_name], [wish_status_id], [create_date], [created_by], [update_date], [is_active], [start_date], [end_date], [user_id]) VALUES (4, N'Deliver dinner', 1, '20150414 00:00:00.000', N'bkraider', NULL, 1, '20150414 00:00:00.000', NULL, 2)
INSERT INTO [dbo].[wishes] ([wish_id], [wish_name], [wish_status_id], [create_date], [created_by], [update_date], [is_active], [start_date], [end_date], [user_id]) VALUES (5, N'Pickup laundry', 2, '20150414 00:00:00.000', N'bkraider', NULL, 1, '20150414 00:00:00.000', NULL, 3)
SET IDENTITY_INSERT [dbo].[wishes] OFF
SET IDENTITY_INSERT [dbo].[wish_status] ON
INSERT INTO [dbo].[wish_status] ([wish_status_id], [wish_status]) VALUES (1, N'BACKLOG')
INSERT INTO [dbo].[wish_status] ([wish_status_id], [wish_status]) VALUES (2, N'INPROGRESS')
INSERT INTO [dbo].[wish_status] ([wish_status_id], [wish_status]) VALUES (3, N'COMPLETE')
SET IDENTITY_INSERT [dbo].[wish_status] OFF
ALTER TABLE [dbo].[wishes]
    ADD CONSTRAINT [FK_wishes_wish_status] FOREIGN KEY ([wish_status_id]) REFERENCES [dbo].[wish_status] ([wish_status_id])
ALTER TABLE [dbo].[wishes]
    ADD CONSTRAINT [FK_wishes_users] FOREIGN KEY ([user_id]) REFERENCES [dbo].[users] ([user_id])
ALTER TABLE [dbo].[donations]
    ADD CONSTRAINT [FK_donations_donation_status] FOREIGN KEY ([donation_status_id]) REFERENCES [dbo].[donation_status] ([donation_status_id])
ALTER TABLE [dbo].[donations]
    ADD CONSTRAINT [FK_donations_users] FOREIGN KEY ([user_id]) REFERENCES [dbo].[users] ([user_id])
COMMIT TRANSACTION
