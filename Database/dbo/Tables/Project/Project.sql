CREATE TABLE [Project] (
  [Project_Id] int,
  [Project_Name] nvarchar(50) NOT NULL,
  [Project_Description] nvarchar(max) NOT NULL,
  [StartDate] datetime2 NOT NULL,
  [EndDate] datetime2 NULL,
  [Creator] int FOREIGN KEY REFERENCES [Admin](Employee_Id) NOT NULL,
  PRIMARY KEY ([Project_Id])
);