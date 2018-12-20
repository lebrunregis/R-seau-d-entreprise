﻿CREATE TRIGGER [OnInsertEmployee]
ON Employee
AFTER INSERT
AS
BEGIN
	SET NOCOUNT ON
	INSERT INTO EmployeeStatusHistory(Employee_Id,EmployeeStatus_Id) SELECT Employee_Id, 0 FROM inserted
END