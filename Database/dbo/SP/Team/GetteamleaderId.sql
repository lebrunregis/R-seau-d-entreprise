CREATE PROCEDURE [dbo].[GetTeamLeaderId]
	@Team_Id int
AS
	SELECT dbo.FN_GetTeamLeader(@Team_Id);

