CREATE TRIGGER [OnInsertEmployee]
ON Employee
AFTER INSERT
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @EmpId int
	SELECT @EmpId = Employee_Id FROM inserted
	INSERT INTO EmployeeStatusHistory(Employee_Id,EmployeeStatus_Id) VALUES ( @EmpId,1)
END