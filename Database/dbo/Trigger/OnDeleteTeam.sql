CREATE TRIGGER [OnDeleteTeam]
ON Team
INSTEAD OF DELETE
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @DeletedTeams table(Team_Id int);
	INSERT INTO @DeletedTeams(Team_Id) SELECT Team_Id FROM deleted d  WHERE d.Team_Disbanded IS NULL;
	UPDATE Team Set Team_Disbanded = GetDate() WHERE Team_Id in (SELECT Team_Id FROM @DeletedTeams);
	DELETE FROM EmployeeTeam WHERE Team_Id in (SELECT Team_Id FROM @DeletedTeams);
END
