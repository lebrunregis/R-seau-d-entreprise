CREATE TABLE [dbo].[EmployeeTeamLeader]
(
	[Team_Id] int NOT NULL FOREIGN KEY REFERENCES Team(Team_Id),
  [Employee_Id] int NOT NULL FOREIGN KEY REFERENCES Employee(Employee_Id),
  [date] datetime2(7),
  PRIMARY KEY ([Team_Id], [date])

);
