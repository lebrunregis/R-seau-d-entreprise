CREATE PROCEDURE [dbo].[GetAllTeams]
AS
	SELECT Team_Id, Team_Name, Team_Created, Team_Disbanded, Creator_Id, Project_Id
	FROM [dbo].Team t