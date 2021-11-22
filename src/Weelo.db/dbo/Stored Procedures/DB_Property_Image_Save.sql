CREATE   PROCEDURE [dbo].[DB_Property_Image_Save] 
	@idProperty int,
	@file NVARCHAR(255),
	@enabled bit
AS
BEGIN
    SET NOCOUNT ON;
    --=====================================================================================================================
    -- Declare
    --=====================================================================================================================
    Declare @error varchar(max),@IdPropertyImage int
	Begin try
		BEGIN  TRANSACTION
		INSERT PropertyImage([IdProperty],[file],[Enabled]) 
		Select @IdProperty,@file,@Enabled
		Set @IdPropertyImage = SCOPE_IDENTITY();
		COMMIT  TRANSACTION
	------------------------------------------------------------------------------
	-- send back answer
	------------------------------------------------------------------------------
	SELECT @IdPropertyImage AS IdPropertyImage
	-- - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - - -
	End Try
	Begin Catch
		-- there was an error
		If XACT_STATE() =-1
		Begin
    			Rollback WORK
		End
		If @@trancount >0
		Begin
    			Rollback WORK
		End
		If XACT_STATE() = 1
		Begin
    			Commit WORK
		End
		--Getting the error description
		Set @error = ERROR_MESSAGE();
		RaisError(@error,16,1)
		Return
	End Catch
	
END