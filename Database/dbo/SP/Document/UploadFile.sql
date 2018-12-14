CREATE PROCEDURE [dbo].[UploadFile]
	@Name nvarchar(MAX),
	@Body varbinary(MAX),
	@Employee_Id int
AS
BEGIN
	INSERT INTO Document([Name], Body, Size, SHA2, Employee_Id) OUTPUT Inserted.Document_Id
	VALUES (@Name, @Body, DATALENGTH(@Body), HASHBYTES('SHA2_256',@Body), @Employee_Id)
END