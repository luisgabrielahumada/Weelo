CREATE   PROCEDURE [dbo].[DB_Property_Save] 
	@IdProperty int = 0,
	@Address varchar(255),
	@CodeInternational varchar(50),
	@Name varchar(50),
	@Price money,
	@Year int,
	@IdOwner int,
	@PropertyTrace  [PropertyTraceTemp] READONLY
AS
BEGIN
    SET NOCOUNT ON;
    --=====================================================================================================================
    -- Declare
    --=====================================================================================================================
    Declare @error varchar(max)
	Create table #tempPropertyTrace(IdProperty int, [DateSale] date NULL,[Name] varchar(50) NULL,[Value] money NULL,[Tax] money NULL)
	Begin Try
		BEGIN  TRANSACTION
		
			if(@IdProperty=0)
			Begin
				INSERT Property ([Name],[Address],[Price],[CodeInternational],[Year],[IdOwner]) 
				VALUES (@Name,@Address,@Price,@CodeInternational,@Year,@IdOwner)
				Set @IdProperty =  SCOPE_IDENTITY()
			End
			Else
			Begin
				UPDATE Property SET 
						[Name]					= @Name
						,[Address]				= @Address
						,[Price]				= @Price
						,[CodeInternational]	= @CodeInternational
						,[Year]					= @Year
						,[IdOwner]				= @IdOwner
				Where [IdProperty] = @IdProperty
			End


			Insert into #tempPropertyTrace(IdProperty,[DateSale],[Name],[Value],[Tax])
			Select @IdProperty,[DateSale],[Name],[Value],[Tax]
			From @PropertyTrace

			MERGE PropertyTrace AS TARGET
			USING #tempPropertyTrace AS SOURCE
			ON (TARGET.IdProperty = SOURCE.IdProperty)
			WHEN MATCHED THEN
			UPDATE 
			SET TARGET.[DateSale] = SOURCE.[DateSale],
				TARGET.[Name] = SOURCE.[Name],
				TARGET.[Value] = SOURCE.[Value],
				TARGET.[Tax] = SOURCE.[Tax]
			WHEN NOT MATCHED BY TARGET THEN
			INSERT (IdProperty,[DateSale],[Name],[Value],[Tax]) 
			VALUES (SOURCE.IdProperty,SOURCE.[DateSale],SOURCE.[Name],SOURCE.[Value],SOURCE.[Tax]);

		COMMIT  TRANSACTION
	------------------------------------------------------------------------------
	-- send back answer
	------------------------------------------------------------------------------
	SELECT @IdProperty AS IdProperty
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