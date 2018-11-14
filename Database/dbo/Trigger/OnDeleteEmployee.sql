CREATE TRIGGER [OnDeleteEmployee]
ON Employee
INSTEAD OF DELETE
AS
BEGIN
	SET NOCOUNT ON
	
	DECLARE @EmpId Table(Id int);
	INSERT INTO @EmpId(Id) (SELECT d.Employee_Id FROM deleted d INNER JOIN Employee e ON d.Employee_Id=e.Employee_Id WHERE e.Active=1);
	INSERT INTO EmployeeStatusHistory(Employee_Id,EmployeeStatus_Id) SELECT Id, 2 FROM @EmpId;
	UPDATE Employee SET Employee.Active = 0 WHERE Employee_Id IN (SELECT Id FROM @EmpId);
	DELETE FROM EmployeeStatusHistory WHERE Employee_Id IN (SELECT Id FROM @EmpId) AND EmployeeStatus_Id=1 AND EndDate is NULL;
	DELETE FROM [Admin] WHERE Employee_Id IN (SELECT Id FROM @EmpId);
	DELETE FROM EmployeeTeam WHERE Employee_Id IN (SELECT Id FROM @EmpId);
END