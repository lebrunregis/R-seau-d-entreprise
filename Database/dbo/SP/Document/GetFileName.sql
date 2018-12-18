CREATE PROCEDURE [dbo].[GetFileName]
	@Name nvarchar(MAX),
	@Employee_Id int
	--@filepath varchar(max) output
AS
BEGIN
	SET NOCOUNT ON;
	DECLARE @ID UNIQUEIDENTIFIER
	SET @ID = NEWID()
	INSERT INTO Document([GUID], [Name], Employee_Id)
	VALUES (@ID, @Name,  @Employee_Id)
	SELECT Body.PathName() AS filepath, GET_FILESTREAM_TRANSACTION_CONTEXT() AS context, Document_Id from Document where [GUID] = @ID
END