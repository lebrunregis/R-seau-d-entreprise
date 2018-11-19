CREATE TABLE [dbo].[EmployeeEvent]
(
  [Employee_Id] int NOT NULL FOREIGN KEY REFERENCES Employee(Employee_Id),
  [Event_Id] int NOT NULL FOREIGN KEY REFERENCES Event(Event_Id),
  [Attended] bit NOT NULL DEFAULT 1,
  [Cancelled] bit NOT NULL DEFAULT 0,
  [Date] datetime2(0) NOT NULL DEFAULT GetDate(),
  PRIMARY KEY ([Employee_Id], [Event_Id]) ,
  CONSTRAINT FK_EmployeeEventEmployeeId FOREIGN KEY (Employee_Id) REFERENCES Employee(Employee_Id),
  CONSTRAINT FK_EmployeeEventEventId FOREIGN KEY(Event_Id) REFERENCES Event(Event_Id)
)
