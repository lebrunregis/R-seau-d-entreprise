CREATE TABLE [dbo].[EmployeeTask]
(
  [Employee_Id] int FOREIGN KEY REFERENCES Employee(Employee_Id),
  [Task_Id] int FOREIGN KEY REFERENCES Task(Task_Id),
  PRIMARY KEY ([Employee_Id], [Task_Id]),
  CONSTRAINT FK_TaskEmployeeId FOREIGN KEY (Employee_Id) REFERENCES Employee(Employee_Id),
  CONSTRAINT FK_TaskId FOREIGN KEY(Task_Id) REFERENCES Task(Task_Id)

)
