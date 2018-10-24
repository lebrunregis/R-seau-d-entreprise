CREATE TABLE [dbo].[EmployeeHeadOfDepartment]
(
	[Employee_Id] int NOT NULL FOREIGN KEY REFERENCES Employee(Employee_Id),
  [Department_Id] int NOT NULL FOREIGN KEY REFERENCES Department(Department_Id),
  [Date] datetime2(7),
  PRIMARY KEY ([Date], [Department_Id])
)
