CREATE TABLE [dbo].[EmployeeTeamLeader]
(
  [Team_Id] int NOT NULL,
  [Employee_Id] int NOT NULL,
  [date] datetime2(0) DEFAULT SYSDATETIME(),
  PRIMARY KEY ([Team_Id], [date]),
  CONSTRAINT FK_TeamLeaderEmployeeId FOREIGN KEY (Team_Id) REFERENCES Team(Team_Id),
  CONSTRAINT FK_TeamLeaderTeamId FOREIGN KEY(Employee_Id) REFERENCES Employee(Employee_Id)
);
