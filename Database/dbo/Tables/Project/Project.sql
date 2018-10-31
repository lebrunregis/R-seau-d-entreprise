CREATE TABLE [Project] (
  [Project_Id] int identity(1,1),
  [Project_Name] nvarchar(50) NOT NULL,
  [Project_Description] nvarchar(max) NOT NULL,
  [StartDate] DATETIME NOT NULL DEFAULT GetDate(),
  [EndDate] DATETIME NULL,
  [CreatorId] int FOREIGN KEY REFERENCES [Admin](Employee_Id) NOT NULL,
  PRIMARY KEY ([Project_Id])
);