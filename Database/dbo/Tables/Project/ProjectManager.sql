CREATE TABLE [dbo].[ProjectManager]
(
  [Employee_Id] int NOT NULL FOREIGN KEY REFERENCES Employee(Employee_Id),
  [Project_Id] int NOT NULL FOREIGN KEY REFERENCES Project(Project_Id),
  [Date] datetime2(7) DEFAULT GetDate(),
  PRIMARY KEY ([Date], [Project_Id]),
  CONSTRAINT FK_ProjectManagerId FOREIGN KEY (Employee_Id) REFERENCES Employee(Employee_Id),
  CONSTRAINT FK_ProjectManagerProjectId FOREIGN KEY(Project_Id) REFERENCES Project(Project_Id)
)
