CREATE TABLE [dbo].[EmployeeStatus]
(
	[EmployeeStatus_Id] int IDENTITY,
  [Name] nvarchar(50) NOT NULL UNIQUE,
  PRIMARY KEY ([EmployeeStatus_Id])
);
GO;
CREATE INDEX [Employeestatusname_index] ON  [EmployeeStatus] ([Name]);
GO;