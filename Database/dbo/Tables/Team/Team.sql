CREATE TABLE [Team] (
  [Team_Id] int identity,
  [Team_Name] nvarchar(50) NOT NULL,
  Project_Id int NOT NULL,
  [Team_Created] DATETIME2(0) NOT NULL DEFAULT GETDATE(),
  [Team_Disbanded] DATETIME2(0) NULL,
  Creator_Id int NOT NULL,
    PRIMARY KEY ([Team_Id]),
	CONSTRAINT FK_TeamCreatorId FOREIGN KEY(Creator_Id) REFERENCES Employee(Employee_Id),
	CONSTRAINT FK_TeamProjectId FOREIGN KEY(Project_Id) REFERENCES Project(Project_Id)
);