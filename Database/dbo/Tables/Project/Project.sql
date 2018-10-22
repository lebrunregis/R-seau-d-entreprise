CREATE TABLE [Project] (
  [Project_Id] int,
  [Project_Name] nvarchar(50),
  [Project_Description] nvarchar(max),
  [StartDate] datetime2,
  [EndDate] datetime2,
  PRIMARY KEY ([Project_Id])
);