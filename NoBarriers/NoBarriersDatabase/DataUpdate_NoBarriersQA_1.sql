/*
This script was created by Visual Studio on 4/12/2015 at 2:23 PM.
Run this script on BKRAIDER-UB.NoBarriersQA (BKRAIDER-UB\bkraider) to make it the same as BKRAIDER-UB.NoBarriers (BKRAIDER-UB\bkraider).
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
ALTER TABLE [dbo].[tasks] DROP CONSTRAINT [FK_tasks_task_status]
ALTER TABLE [dbo].[tasks] DROP CONSTRAINT [FK_tasks_users]
SET IDENTITY_INSERT [dbo].[task_status] ON
INSERT INTO [dbo].[task_status] ([task_status_id], [task_status]) VALUES (1, N'BACKLOG')
INSERT INTO [dbo].[task_status] ([task_status_id], [task_status]) VALUES (2, N'INPROGRESS')
INSERT INTO [dbo].[task_status] ([task_status_id], [task_status]) VALUES (3, N'COMPLETE')
SET IDENTITY_INSERT [dbo].[task_status] OFF
SET IDENTITY_INSERT [dbo].[tasks] ON
INSERT INTO [dbo].[tasks] ([task_id], [task_name], [task_status_id], [create_date], [created_by], [update_date], [is_active], [start_date], [end_date], [userid]) VALUES (1, N'Rake Leaves', 1, '20150101 00:00:00.000', N'bkraider', NULL, 1, '20150101 00:00:00.000', NULL, 1)
INSERT INTO [dbo].[tasks] ([task_id], [task_name], [task_status_id], [create_date], [created_by], [update_date], [is_active], [start_date], [end_date], [userid]) VALUES (2, N'Clean Garage', 2, '20150101 00:00:00.000', N'bkraider', NULL, 1, '20150101 00:00:00.000', NULL, 1)
SET IDENTITY_INSERT [dbo].[tasks] OFF
SET IDENTITY_INSERT [dbo].[users] ON
INSERT INTO [dbo].[users] ([user_id], [first_name], [middle_name], [last_name], [former_name], [login_id], [e_mail], [create_date], [created_by], [update_date], [is_active], [is_donor]) VALUES (1, N'bhanu', N'k', N'korremula', N'kiran', N'bkraider', N'bkraider@gmail.com', '20150101 00:00:00.000', N'bkraider', NULL, 1, 1)
INSERT INTO [dbo].[users] ([user_id], [first_name], [middle_name], [last_name], [former_name], [login_id], [e_mail], [create_date], [created_by], [update_date], [is_active], [is_donor]) VALUES (2, N'david', N'h', N'he', N'd', N'davidh', N'davidh@gmail.com', '20150101 00:00:00.000', N'bkraider', NULL, 1, 0)
INSERT INTO [dbo].[users] ([user_id], [first_name], [middle_name], [last_name], [former_name], [login_id], [e_mail], [create_date], [created_by], [update_date], [is_active], [is_donor]) VALUES (4, N'daniel', N'', N'du', N'u', N'danield', N'danield@gmail.com', '20150101 00:00:00.000', N'bkraider', NULL, 1, 0)
SET IDENTITY_INSERT [dbo].[users] OFF
ALTER TABLE [dbo].[tasks]
    ADD CONSTRAINT [FK_tasks_task_status] FOREIGN KEY ([task_status_id]) REFERENCES [dbo].[task_status] ([task_status_id])
ALTER TABLE [dbo].[tasks]
    ADD CONSTRAINT [FK_tasks_users] FOREIGN KEY ([userid]) REFERENCES [dbo].[users] ([user_id])
COMMIT TRANSACTION
