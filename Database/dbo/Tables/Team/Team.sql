CREATE TABLE [Team] (
  [Team_Id] int identity(1,1),
  [Team_Name] nvarchar(50) NOT NULL,
  [Team_Created] datetime2 NOT NULL,
  PRIMARY KEY ([Team_Id])
);