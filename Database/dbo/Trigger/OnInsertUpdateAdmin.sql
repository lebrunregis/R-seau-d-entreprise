CREATE TRIGGER [OnInsertUpdateAdmin]
ON [Admin]
AFTER INSERT, UPDATE
AS
BEGIN
	SET NOCOUNT ON;
	INSERT INTO EmployeeStatusHistory (Employee_Id, EmployeeStatus_Id) (SELECT Employee_Id, 5 FROM inserted WHERE Actif=1);
	DELETE FROM EmployeeStatusHistory WHERE EmployeeStatus_Id=5 AND Employee_Id in (SELECT Employee_Id FROM inserted WHERE Actif=0) AND EndDate is Null;
END
