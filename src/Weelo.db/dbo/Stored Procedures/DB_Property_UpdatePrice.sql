CREATE   PROCEDURE [dbo].[DB_Property_UpdatePrice] 
	@idProperty int,
	@price money
AS
BEGIN
    SET NOCOUNT ON;
    --=====================================================================================================================
    -- Declare
    --=====================================================================================================================
	Declare @error varchar(max)
	Begin Try

		If NOT EXISTS(Select * from Property Where IdProperty=@idProperty)
		BEGIN
			RaisError('The update property was not found.',16,1);
			return
		END
		BEGIN  TRANSACTION
			--  Update on the temporary table (#Property) IdOwner
			UPDATE Property
			SET Price = @price
			Where IdProperty = @idProperty

		COMMIT  TRANSACTION
	------------------------------------------------------------------------------
	-- send back answer
	------------------------------------------------------------------------------
	SELECT @idProperty AS IdProperty
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