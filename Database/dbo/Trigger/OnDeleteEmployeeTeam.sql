CREATE TRIGGER [OnDeleteEmployeeTeam]
ON EmployeeTeam
INSTEAD OF DELETE
AS
BEGIN
	SET NOCOUNT ON
	UPDATE EmployeeTeam
	SET EndDate = GetDate() WHERE EndDate IS NULL AND EXISTS
	    (SELECT * FROM deleted d WHERE d.Team_Id = Team_Id AND d.Employee_Id = Employee_Id AND d.StartDate = StartDate);
END