CREATE TABLE [dbo].[EmployeeEvent]
(
	[Employee_id] int NOT NULL FOREIGN KEY REFERENCES Employee(Employee_id),
  [Event_id] int NOT NULL FOREIGN KEY REFERENCES Event(Event_id),
  [present] bit NOT NULL
  PRIMARY KEY ([Employee_id], [Event_id])
)
