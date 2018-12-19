CREATE PROCEDURE [dbo].[GetDocsForDepartment]
	@Department_Id int
AS
BEGIN
	SELECT Document_Id FROM DocDepartment WHERE Department_Id = @Department_Id
END	    
