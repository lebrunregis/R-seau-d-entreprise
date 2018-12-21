CREATE PROCEDURE [dbo].[GetDocForDescription]
	@Document_Id int
AS
	SELECT TOP 1 Document_Id, [Name], Created, Size, [Checksum] Employee_Id, Deleted FROM Document WHERE Document_Id=@Document_Id ORDER BY Created DESC
