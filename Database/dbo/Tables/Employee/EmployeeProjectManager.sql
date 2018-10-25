CREATE TABLE [dbo].[EmployeeProjectManager]
(
	[Employee_Id] int NOT NULL FOREIGN KEY REFERENCES Employee(Employee_Id),
  [Project_Id] int NOT NULL FOREIGN KEY REFERENCES Project(Project_Id),
  [Date] datetime2(7) DEFAULT GetDate(),
  PRIMARY KEY ([Date], [Project_Id])
)
