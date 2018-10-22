CREATE TABLE [dbo].[EmployeeTask]
(
	[Employee_Id] int FOREIGN KEY REFERENCES Employee(Employee_id),
  [Task_Id] int FOREIGN KEY REFERENCES Task(Task_Id),
  PRIMARY KEY ([Employee_Id], [Task_Id])


)
