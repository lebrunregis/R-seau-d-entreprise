CREATE PROCEDURE [dbo].[AddDocToProject]
	@Document_Id int,
	@Project_Id int
AS
BEGIN
	IF @Document_Id IN (SELECT Document_Id from Document)
	    INSERT INTO DocProject(Document_Id, Project_Id) VALUES (@Document_Id, @Project_Id)
END	    
