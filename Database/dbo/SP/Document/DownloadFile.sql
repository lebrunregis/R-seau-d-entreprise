CREATE PROCEDURE [dbo].[DownloadFile]
	@DocumentId int
AS
	SELECT * from Document WHERE Document_Id = @DocumentId
