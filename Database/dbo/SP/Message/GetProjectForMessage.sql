CREATE PROCEDURE [dbo].[GetProjectForMessage]
	@MessageId int
AS
	SELECT TOP 1 p.Project_Id, p.Project_Name, p.Project_Description, p.StartDate, p.EndDate, p.CreatorId, -1 AS ProjectManagerId
	FROM Project p JOIN MessageProject mp ON p.Project_Id=mp.Project_Id
	WHERE mp.Message_Id=@MessageId