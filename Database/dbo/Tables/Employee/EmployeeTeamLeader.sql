CREATE TABLE [dbo].[EmployeeTeamLeader]
(
	[Team_Id] int NOT NULL FOREIGN KEY REFERENCES Team(Team_id),
  [Employee_Id] int NOT NULL FOREIGN KEY REFERENCES Employee(Employee_id),
  [date] datetime2(7),
  PRIMARY KEY ([Team_id], [date])

);
