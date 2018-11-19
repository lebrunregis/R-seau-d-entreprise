CREATE TRIGGER [OnDeleteEmployeeTeam]
ON EmployeeTeam
INSTEAD OF DELETE
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @DeletedEmployeeTeam table(Team_Id int, Employee_Id int, StartDate datetime2(7));
	INSERT INTO @DeletedEmployeeTeam(Team_Id, Employee_Id, StartDate)
	    SELECT d.Team_Id, d.Employee_Id, d.StartDate FROM deleted d JOIN Team t ON d.Team_Id=t.Team_Id JOIN Project p ON p.Project_Id=t.Team_Id  
		WHERE d.EndDate IS NULL OR d.EndDate > SYSDATETIME()
		AND t.Team_Disbanded IS NULL
		AND (p.EndDate IS NULL OR p.EndDate > SYSDATETIME());
	UPDATE EmployeeTeam
	SET EndDate = SYSDATETIME() WHERE EndDate IS NULL AND EXISTS
	    (SELECT * FROM @DeletedEmployeeTeam d WHERE d.Team_Id = Team_Id AND d.Employee_Id = Employee_Id AND d.StartDate = StartDate);
END