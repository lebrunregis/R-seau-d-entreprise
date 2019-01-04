CREATE TABLE [dbo].[ProjectManager]
(
  [Employee_Id] int NOT NULL FOREIGN KEY REFERENCES Employee(Employee_Id),
  [Project_Id] int NOT NULL FOREIGN KEY REFERENCES Project(Project_Id),
  [Date] datetime2(0) DEFAULT SYSDATETIME(),
  PRIMARY KEY ([Date], [Project_Id]),
)
