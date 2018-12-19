CREATE PROCEDURE [dbo].[GetDocsForTask]
	@Task_Id int
AS
BEGIN
	SELECT Document_Id FROM DocTask WHERE Task_Id = @Task_Id
END	    
