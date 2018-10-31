CREATE TRIGGER [OnDeleteEmployeeStatusHistory]
ON EmployeeStatusHistory
INSTEAD OF DELETE
AS
BEGIN
	SET NOCOUNT ON
	UPDATE EmployeeStatusHistory
	SET EndDate = GetDate() WHERE EmployeeStatusHistory_Id in (SELECT EmployeeStatusHistory_Id FROM deleted);
END
