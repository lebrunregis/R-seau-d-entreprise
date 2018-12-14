CREATE PROCEDURE [dbo].[ContinueUploadingFile]
	@Id int,
	@Body varbinary(MAX)
AS
	UPDATE Document SET Body = Body + @Body WHERE Document_Id = @Id