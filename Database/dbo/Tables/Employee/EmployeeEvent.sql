CREATE TABLE [dbo].[EmployeeEvent]
(
	[Employee_Id] int NOT NULL FOREIGN KEY REFERENCES Employee(Employee_Id),
  [Event_Id] int NOT NULL FOREIGN KEY REFERENCES Event(Event_Id),
  [present] bit NOT NULL
  PRIMARY KEY ([Employee_Id], [Event_Id])
)
