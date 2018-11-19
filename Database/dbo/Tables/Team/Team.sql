CREATE TABLE [Team] (
  [Team_Id] int identity,
  [Team_Name] nvarchar(50) NOT NULL,
  [Team_Created] DATETIME2(0) NOT NULL DEFAULT SYSDATETIME(),
  [Team_Disbanded] DATETIME2(0) NULL, 
    PRIMARY KEY ([Team_Id])
);