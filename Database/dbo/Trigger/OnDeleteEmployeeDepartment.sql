CREATE TRIGGER [OnDeleteEmployeeDepartment]
ON EmployeeDepartment
INSTEAD OF DELETE
AS
BEGIN
	SET NOCOUNT ON
	UPDATE EmployeeDepartment Set EndDate = SYSDATETIME() WHERE  Id in (SELECT Id FROM deleted);
END