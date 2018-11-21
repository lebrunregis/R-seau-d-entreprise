CREATE TABLE [dbo].[EmployeeTeam]
(
  [Team_Id] int NOT NULL ,
  [Employee_Id] int NOT NULL ,
  [StartDate] datetime2(7) DEFAULT SYSDATETIME(),
  [EndDate] datetime2(7),
  PRIMARY KEY ([StartDate], [Team_Id], [Employee_Id]),
  CONSTRAINT FK_EmployeeTeamId FOREIGN KEY (Team_Id) REFERENCES Team(Team_Id),
  CONSTRAINT FK_TeamEmployeeId FOREIGN KEY(Employee_Id) REFERENCES Employee(Employee_Id)
)
