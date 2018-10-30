CREATE TABLE [dbo].[EmployeeHeadOfDepartment]
(
  [Employee_Id] int NOT NULL FOREIGN KEY REFERENCES Employee(Employee_Id),
  [Department_Id] int NOT NULL FOREIGN KEY REFERENCES Department(Department_Id),
  [Date] datetime2(7) DEFAULT GetDate(),
  PRIMARY KEY ([Date], [Department_Id]),
  CONSTRAINT FK_HeadOfDepartmentEmployeeId FOREIGN KEY (Employee_Id) REFERENCES Employee(Employee_Id),
  CONSTRAINT FK_HeadOfDepartmentDeptartmentId FOREIGN KEY(Department_Id) REFERENCES Department(Department_Id)
)
