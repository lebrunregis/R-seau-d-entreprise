CREATE PROCEDURE [dbo].[DeleteDocument]
	@DocumentId int,
	@User int --ne sert a rien pour le moment
AS
	DELETE FROM Document WHERE Document_Id = @DocumentId AND Deleted IS NULL
