CREATE PROCEDURE [dbo].[GetTeamForMessage]
	@MessageId int
AS
	SELECT TOP 1 t.Team_Id, t.Team_Name, t.Team_Created, t.Team_Disbanded, t.Creator_Id, t.Project_Id
	FROM Team t JOIN MessageTeam mt ON t.Team_Id=mt.Team_Id
	WHERE mt.Message_Id = @MessageId