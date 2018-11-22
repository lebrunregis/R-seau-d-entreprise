CREATE TABLE [Project] (
  [Project_Id] int identity(1,1),
  [Project_Name] nvarchar(50) NOT NULL,
  [Project_Description] nvarchar(max) NOT NULL,
  [StartDate] DATETIME2(0) NOT NULL DEFAULT SYSDATETIME(),
  [EndDate] DATETIME2(0) NULL,
  [CreatorId] int FOREIGN KEY REFERENCES [Admin](Employee_Id) NOT NULL,
  PRIMARY KEY ([Project_Id])
);