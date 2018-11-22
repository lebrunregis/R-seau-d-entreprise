CREATE TRIGGER [OnDeleteEmployeeTeam]
ON EmployeeTeam
INSTEAD OF DELETE
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @DeletedEmployeeTeam table(Team_Id int, Employee_Id int);
	INSERT INTO @DeletedEmployeeTeam(Team_Id, Employee_Id)
	    SELECT d.Team_Id, d.Employee_Id FROM deleted d JOIN Team t ON d.Team_Id=t.Team_Id JOIN Project p ON p.Project_Id=t.Project_Id  
		WHERE d.EndDate IS NULL
		AND t.Team_Disbanded IS NULL
		AND (p.EndDate IS NULL OR p.EndDate > SYSDATETIME());
	UPDATE EmployeeTeam
	SET EndDate = SYSDATETIME() WHERE EndDate IS NULL AND EXISTS
	    (SELECT * FROM @DeletedEmployeeTeam d WHERE EmployeeTeam.Team_Id = d.Team_Id AND d.Employee_Id = EmployeeTeam.Employee_Id);
END