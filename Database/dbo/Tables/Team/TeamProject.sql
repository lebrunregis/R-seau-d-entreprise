CREATE TABLE [TeamProject] (
  [Team_Id] int,
  [Project_Id] int,
  [StartDate] datetime2(7),
  [EndDate] datetime2(7),
  PRIMARY KEY ([StartDate])
);
GO
CREATE INDEX [PFK] ON  [TeamProject] ([Team_Id], [Project_Id]);