CREATE TABLE [dbo].[EmployeeStatus]
(
	[EmployeeStatus_Id] int identity,
  [Name] nvarchar(50) NOT NULL unique,
  PRIMARY KEY ([EmployeeStatus_Id])

);
GO;
CREATE INDEX [Employeestatusname_index] ON  [EmployeeStatus] ([Name]);


