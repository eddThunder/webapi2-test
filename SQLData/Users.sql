CREATE TABLE [dbo].[Users] (
    Id int primary key identity,
	Username NVARCHAR (20) NULL,
	UserPassword NVARCHAR (100) NULL
);