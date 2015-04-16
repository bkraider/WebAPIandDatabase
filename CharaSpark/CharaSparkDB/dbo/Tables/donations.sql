CREATE TABLE [dbo].[donations] (
    [donation_id]        INT          IDENTITY (1, 1) NOT NULL,
    [donation_amount]    MONEY        NOT NULL,
    [donation_status_id] INT          NULL,
    [create_date]        DATETIME     CONSTRAINT [DF_donations_create_date] DEFAULT (getdate()) NOT NULL,
    [created_by]         VARCHAR (50) CONSTRAINT [DF_donations_created_by] DEFAULT (suser_sname()) NOT NULL,
    [update_date]        DATETIME     NULL,
    [is_active]          BIT          NOT NULL,
    [start_date]         DATETIME     NULL,
    [end_date]           DATETIME     NULL,
    [user_id]            INT          NULL,
    [charity_name]       VARCHAR (50) NULL,
    CONSTRAINT [PK_donations] PRIMARY KEY CLUSTERED ([donation_id] ASC),
    CONSTRAINT [FK_donations_donation_status] FOREIGN KEY ([donation_status_id]) REFERENCES [dbo].[donation_status] ([donation_status_id]),
    CONSTRAINT [FK_donations_users] FOREIGN KEY ([user_id]) REFERENCES [dbo].[users] ([user_id])
);



