CREATE TABLE [TeamProject] (
  [Team_Id] int FOREIGN KEY REFERENCES [Team](Team_Id),
  [Project_Id] int FOREIGN KEY REFERENCES [Project](Project_Id),
  [StartDate] datetime2(0),
  [EndDate] datetime2(0),
  PRIMARY KEY ([Team_Id],[Project_Id])
);
GO
CREATE INDEX [PFK] ON  [TeamProject] ([Team_Id], [Project_Id]);