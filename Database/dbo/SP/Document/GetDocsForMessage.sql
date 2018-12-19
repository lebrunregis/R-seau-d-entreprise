CREATE PROCEDURE [dbo].[GetDocsForMessage]
	@Message_Id int
AS
BEGIN
	SELECT Document_Id FROM DocMessage WHERE Message_Id = @Message_Id
END	    
