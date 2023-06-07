CREATE TABLE [dbo].[tblUsers]
(
	[Id] UNIQUEIDENTIFIER NOT NULL PRIMARY KEY DEFAULT newid(), 
    [Username] NVARCHAR(50) NULL, 
    [Password] NVARCHAR(50) NULL, 
    [Phone] NVARCHAR(50) NULL
)
