CREATE PROCEDURE [dbo].[GetDocsForProject]
	@Project_Id int
AS
BEGIN
	SELECT Document_Id FROM DocProject WHERE Project_Id = @Project_Id
END	    
