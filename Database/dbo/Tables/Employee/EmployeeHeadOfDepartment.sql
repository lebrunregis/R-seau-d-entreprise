CREATE TABLE [dbo].[EmployeeHeadOfDepartment]
(
	[Employee_id] int NOT NULL FOREIGN KEY REFERENCES Employee(Employee_id),
  [Department_id] int NOT NULL FOREIGN KEY REFERENCES Department(Department_id),
  [date] datetime2(7),
  PRIMARY KEY ([date], [Department_id])
)
