CREATE TABLE [dbo].[EmployeeStatus]
(
	[EmployeeStatus_id] int identity,
  [Name] nvarchar(50) NOT NULL unique,
  PRIMARY KEY ([EmployeeStatus_id])

);
GO;
CREATE INDEX [Employeestatusname_index] ON  [EmployeeStatus] ([Name]);


