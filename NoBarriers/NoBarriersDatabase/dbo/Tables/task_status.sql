CREATE TABLE [dbo].[task_status] (
    [task_status_id] INT          IDENTITY (1, 1) NOT NULL,
    [task_status]    VARCHAR (50) NOT NULL,
    CONSTRAINT [PK_task_status] PRIMARY KEY CLUSTERED ([task_status_id] ASC)
);

