CREATE PROCEDURE [dbo].[UploadFile]
	@Name nvarchar(MAX),
	@Body varbinary(MAX),
	@Employee_Id int,
	@Document_Id int
AS
BEGIN
    IF @Document_Id IS NULL
	    SELECT @Document_Id = ISNULL((MAX(Document_Id) + 1), 1) FROM Document
	INSERT INTO Document(Document_Id, [Name], Body, Size, [Checksum], Employee_Id)
	VALUES (@Document_Id, @Name, @Body, DATALENGTH(@Body), Checksum(@Body), @Employee_Id)

	SELECT @Document_Id;
END