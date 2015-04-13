CREATE TABLE [dbo].[users] (
    [user_id]     INT          IDENTITY (1, 1) NOT NULL,
    [first_name]  VARCHAR (20) NOT NULL,
    [middle_name] VARCHAR (20) NULL,
    [last_name]   VARCHAR (20) NOT NULL,
    [former_name] VARCHAR (20) NULL,
    [login_id]    VARCHAR (20) NOT NULL,
    [e_mail]      VARCHAR (50) NOT NULL,
    [create_date] DATETIME     CONSTRAINT [DF_users_create_date] DEFAULT (getdate()) NOT NULL,
    [created_by]  VARCHAR (50) CONSTRAINT [DF_users_created_by] DEFAULT (suser_sname()) NOT NULL,
    [update_date] DATETIME     NULL,
    [is_active]   BIT          NOT NULL,
    [is_donor]    BIT          NOT NULL,
    CONSTRAINT [PK_users] PRIMARY KEY CLUSTERED ([user_id] ASC)
);

