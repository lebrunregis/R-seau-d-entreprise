CREATE PROCEDURE [dbo].[DownloadFile]
	@DocumentId int
AS
	SELECT [Name], Body from Document WHERE Document_Id = @DocumentId
