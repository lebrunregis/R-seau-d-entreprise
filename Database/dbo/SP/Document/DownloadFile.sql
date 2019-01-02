CREATE PROCEDURE [dbo].[DownloadFile]
	@DocumentId int
AS
	SELECT TOP 1 * from Document WHERE Document_Id = @DocumentId AND Deleted IS NULL ORDER BY Created DESC
