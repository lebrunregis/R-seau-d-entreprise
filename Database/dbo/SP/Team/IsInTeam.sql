CREATE PROCEDURE [dbo].[IsInTeam]
	@Employee_Id int,
	@Team_Id int
AS
BEGIN
    DECLARE @IsInTeam bit
	EXEC @IsInTeam = dbo.FN_IsInTeam @Employee_Id, @Team_Id
	SELECT @IsInTeam
END
