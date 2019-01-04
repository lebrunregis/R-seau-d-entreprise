CREATE TRIGGER [OnInsertUpdateAdmin]
ON [Admin]
AFTER INSERT, UPDATE
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO EmployeeStatusHistory (Employee_Id, EmployeeStatus_Id)
	(
	    SELECT i.Employee_Id, 4 FROM inserted i WHERE i.Actif=1
	    AND NOT EXISTS (SELECT d.Employee_Id FROM deleted d WHERE d.Employee_Id=i.Employee_Id AND d.Actif=1)

	);
	DELETE FROM EmployeeStatusHistory WHERE EmployeeStatus_Id=4 AND Employee_Id in (SELECT Employee_Id FROM inserted WHERE Actif=0) AND EndDate is Null;
END
