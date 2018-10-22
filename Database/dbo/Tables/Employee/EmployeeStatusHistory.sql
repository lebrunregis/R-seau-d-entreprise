CREATE TABLE [dbo].[EmployeeStatusHistory]
(
	[EmployeeStatusHistory_Id] int identity,
  [Employee_Id] int NOT NULL FOREIGN KEY REFERENCES Employee(Employee_Id),
  [EmployeeStatus_Id] int NOT NULL FOREIGN KEY REFERENCES EmployeeStatus(EmployeeStatus_Id),
  [StartDate] datetime2(7) NOT NULL,
  [EndDate] datetime2(7),
  PRIMARY KEY ([EmployeeStatusHistory_Id])

)
