CREATE TRIGGER [OnDeleteEmployee]
ON Employee
INSTEAD OF DELETE
AS
BEGIN
	SET NOCOUNT ON
		DECLARE @EmpId int
	SELECT @EmpId = Employee_Id FROM deleted
	INSERT INTO EmployeeStatusHistory(Employee_Id,EmployeeStatus_Id) VALUES (  @EmpId,2)
	UPDATE Employee SET Active = 0 WHERE Employee_Id = @EmpId;
END