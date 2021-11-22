CREATE  PROCEDURE [dbo].[DB_Property_List]
	@pageIndex [int] = 1,
	@pageSize [int] = 10,
	@year int =0,
	@price money=0,
	@descripcion varchar(255)=''
AS
BEGIN
		SET NOCOUNT ON;
		--=====================================================================================================================
		-- Declare
		--=====================================================================================================================
		Create table #temp (IdProperty int,[Name] varchar(50),[Address] varchar(255) ,[Price] money ,[CodeInternational] varchar(50) ,[Year] int,IdOwner int ,NameOwner varchar(50),AddressOwner varchar(50),Birthday date, Photo varchar(255))
		Declare @TotalRecords int
		------------------------------------------------------------------------------
		-- getting list
		------------------------------------------------------------------------------		
		Insert into #temp
		SELECT Property.[IdProperty]
				,Property.[Name]
				,Property.[Address]
				,Property.[Price]
				,Property.[CodeInternational]
				,Property.[Year]
				,Property.[IdOwner]
				,[Owner].Name as NameOwner
				,[Owner].Address as AddressOwner
				,[Owner].Birthday
				,[Owner].Photo
		FROM [dbo].[Property]
				INNER JOIN [Owner] ON [Owner].IdOwner = [Property].IdOwner
		Where (Property.Year = @year or @year=0)
			  And (@price >= Property.Price or @price=0)
			  And (Property.Name like '%'+@descripcion+'%' or Property.Address  like '%'+@descripcion+'%' or @descripcion='')

		Select @TotalRecords =count(*) From #temp
		Select IdProperty ,[Name],[Address],[Price]  ,[CodeInternational] ,[Year],IdOwner  ,NameOwner,AddressOwner ,Birthday , Photo, @TotalRecords as TotalRecords
		From #temp
		ORDER BY CURRENT_TIMESTAMP OFFSET (@pageIndex-1)*@pageSize ROWS FETCH FIRST @pageSize ROWS ONLY
END