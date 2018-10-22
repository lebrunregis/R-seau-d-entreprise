CREATE TABLE [dbo].[EmployeeStatusHistory]
(
	[EmployeeStatusHistory_id] int identity,
  [Employee_Id] int NOT NULL FOREIGN KEY REFERENCES Employee(Employee_id),
  [EmployeeStatus_Id] int NOT NULL FOREIGN KEY REFERENCES EmployeeStatus(EmployeeStatus_Id),
  [StartDate] datetime2(7) NOT NULL,
  [EndDate] datetime2(7),
  PRIMARY KEY ([EmployeeStatusHistory_id])

)
