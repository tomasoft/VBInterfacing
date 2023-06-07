CREATE PROCEDURE [dbo].[usp_ValidateUser]
	@username nvarchar(20) = '',
	@password nvarchar(32) = ''
AS
	SELECT top 1 * from tblUsers where Username = @username and Password = @password
RETURN 0
