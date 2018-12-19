CREATE PROCEDURE [dbo].[AddDocToTeam]
	@Document_Id int,
	@Team_Id int
AS
BEGIN
	IF @Document_Id IN (SELECT Document_Id from Document)
	    INSERT INTO DocTeam(Document_Id, Team_Id) VALUES (@Document_Id, @Team_Id)
END	    
