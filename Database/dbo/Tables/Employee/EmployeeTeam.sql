CREATE TABLE [dbo].[EmployeeTeam]
(
	[Team_Id] int NOT NULL FOREIGN KEY REFERENCES Team(Team_Id),
  [Employee_Id] int NOT NULL FOREIGN KEY REFERENCES Employee(Employee_Id),
  [StartDate] datetime2(7),
  [EndDate] datetime2(7),
  PRIMARY KEY ([StartDate], [Team_Id], [Employee_Id])

)
