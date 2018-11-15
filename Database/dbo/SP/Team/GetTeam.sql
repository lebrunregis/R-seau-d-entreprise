CREATE PROCEDURE [dbo].[GetTeam]
	@Id int
AS
	SELECT Team_Id, Team_Name, Team_Created, Team_Disbanded, Creator_Id, Project_Id FROM Team
	WHERE Team_Id = @Id