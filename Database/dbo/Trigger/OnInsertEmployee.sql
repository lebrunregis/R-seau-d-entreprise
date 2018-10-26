CREATE TRIGGER [OnInsertEmployee]
ON Employee
AFTER INSERT
AS
BEGIN
	SET NOCOUNT ON
	INSERT INTO EmployeeStatusHistory(Employee_Id,EmployeeStatus_Id) VALUES ( LAST_INSERT_ID(),1)
END
