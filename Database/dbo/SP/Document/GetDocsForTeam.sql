CREATE PROCEDURE [dbo].[GetDocsForTeam]
    @Team_Id int
AS
BEGIN
	SELECT Document_Id FROM DocTeam WHERE Team_Id = @Team_Id
END	    
