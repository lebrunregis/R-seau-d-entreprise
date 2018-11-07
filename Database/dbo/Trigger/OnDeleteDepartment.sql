CREATE TRIGGER [OnDeleteDepartment]
ON [Department]
INSTEAD OF DELETE
AS
BEGIN
	SET NOCOUNT ON
	UPDATE Department Set Active = 0 WHERE Department_Id in (SELECT Department_Id FROM deleted);
END
