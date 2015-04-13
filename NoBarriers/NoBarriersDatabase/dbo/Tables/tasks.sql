CREATE TABLE [dbo].[tasks] (
    [task_id]        INT          IDENTITY (1, 1) NOT NULL,
    [task_name]      VARCHAR (50) NOT NULL,
    [task_status_id] INT          NULL,
    [create_date]    DATETIME     CONSTRAINT [DF_tasks_create_date] DEFAULT (getdate()) NOT NULL,
    [created_by]     VARCHAR (50) CONSTRAINT [DF_tasks_created_by] DEFAULT (suser_sname()) NOT NULL,
    [update_date]    DATETIME     NULL,
    [is_active]      BIT          NOT NULL,
    [start_date]     DATETIME     NULL,
    [end_date]       DATETIME     NULL,
    [userid]         INT          NULL,
    CONSTRAINT [PK_tasks] PRIMARY KEY CLUSTERED ([task_id] ASC),
    CONSTRAINT [FK_tasks_task_status] FOREIGN KEY ([task_status_id]) REFERENCES [dbo].[task_status] ([task_status_id]),
    CONSTRAINT [FK_tasks_users] FOREIGN KEY ([userid]) REFERENCES [dbo].[users] ([user_id])
);

