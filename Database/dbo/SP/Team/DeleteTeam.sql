CREATE PROCEDURE [dbo].[DeleteTeam]
    @User int,
	@Team_Id int
AS
BEGIN
    DECLARE @Project_Id int;
    SELECT @Project_Id = Project_Id FROM Team WHERE Team_Id = @Team_Id;

    IF (dbo.FN_IsAdmin(@User) = 1 OR dbo.FN_IsProjectManager(@User, @Project_Id) = 1)
	    DELETE FROM Team 
	    WHERE Team_Id = @Team_Id
END