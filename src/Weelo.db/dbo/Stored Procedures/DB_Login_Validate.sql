CREATE  PROCEDURE [dbo].[DB_Login_Validate]
	@Login [varchar](200),
	@Password [varchar](100)
AS
BEGIN
	SET NOCOUNT ON;
	--=====================================================================================================================
    -- Declare
    --=====================================================================================================================
	DECLARE  @error VARCHAR(max)
	IF NOT EXISTS(SELECT *
					FROM [dbo].[User]
					WHERE [User].Login=@Login and [User].Password=@Password)
	BEGIN
		RAISERROR('Login or password is not valid..',16,1)
		RETURN
	END
		
	SELECT [IdUser]
			,[Name]
			,[Email]
			,[Login]
	FROM [dbo].[User]
	Where [User].Login=@Login and [User].Password=@Password
END
