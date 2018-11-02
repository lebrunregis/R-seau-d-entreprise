CREATE TRIGGER [OnDeleteAdmin]
	ON [Admin]
INSTEAD OF DELETE
AS
BEGIN
	SET NOCOUNT ON
	UPDATE [Admin] SET Actif = 0 WHERE Employee_Id IN (SELECT d.Employee_Id FROM deleted d);
END