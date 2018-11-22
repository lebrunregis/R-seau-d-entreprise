CREATE PROCEDURE [dbo].[GetAllTeamsForProject]
	@Project_Id int
AS
BEGIN
	SELECT t.Team_Id, t.Team_Name, t.Team_Created, t.Team_Disbanded, t.[Creator_Id], t.Project_Id
	FROM [dbo].Team t
	WHERE t.Project_Id = @Project_Id AND t.Team_Disbanded IS NULL
END
