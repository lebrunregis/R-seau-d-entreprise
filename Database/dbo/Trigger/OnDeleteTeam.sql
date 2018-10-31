CREATE TRIGGER [OnDeleteTeam]
ON Team
INSTEAD OF DELETE
AS
BEGIN
	SET NOCOUNT ON
	UPDATE Team Set Team_Disbanded = GetDate() WHERE Team_Id in (SELECT Team_Id FROM deleted);
END
