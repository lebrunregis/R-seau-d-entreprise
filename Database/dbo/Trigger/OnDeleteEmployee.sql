CREATE TRIGGER [OnDeleteEmployee]
ON Employee
INSTEAD OF DELETE
AS
BEGIN
	SET NOCOUNT ON
	INSERT INTO EmployeeStatusHistory(Employee_Id,EmployeeStatus_Id) VALUES ( LAST_INSERT_ID(),2)
END
