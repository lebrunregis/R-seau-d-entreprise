CREATE TRIGGER [OnDeleteEmployeeDepartment]
ON EmployeeDepartment
INSTEAD OF DELETE
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @EmpDepId table(Id int);
	INSERT INTO @EmpDepId(Id)
	    SELECT Id FROM deleted d JOIN Department dep ON d.Department_Id=dep.Department_Id
		WHERE d.EndDate IS NULL
		AND dep.Active=1;
	UPDATE EmployeeDepartment Set EndDate = GetDate() WHERE  Id in (SELECT Id FROM @EmpDepId);
END