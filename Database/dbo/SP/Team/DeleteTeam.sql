CREATE PROCEDURE [dbo].[DeleteTeam]
    @User int,
	@Team_Id int,
	@Team_Name nvarchar(50),
	@Project_Id int,
	@Creator_Id int,
	@Team_Created datetime2(0)
AS
BEGIN
    IF (dbo.FN_IsAdmin(@User) = 1 OR dbo.FN_GetProjectManagerId(@Project_Id) = @User)
	AND EXISTS (SELECT * FROM Project WHERE Project_Id=@Project_Id AND (EndDate IS NULL OR EndDate > SYSDATETIME()))
	    DELETE FROM Team 
	    WHERE Team_Id=@Team_Id AND Team_Name=@Team_Name AND Project_Id=@Project_Id AND Creator_Id=@Creator_Id AND Team_Created=@Team_Created AND Team_Disbanded IS NULL
END