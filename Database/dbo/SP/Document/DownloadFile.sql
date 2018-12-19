CREATE PROCEDURE [dbo].[DownloadFile]
	@DocumentId int
AS
	SELECT TOP 1 * from Document WHERE Document_Id = @DocumentId ORDER BY Created DESC
