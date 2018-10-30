CREATE TABLE [Task] (
  [Task_Id] int identity(1,1),
  [Name] nvarchar(50) NOT NULL,
  [Description] nvarchar(max) NOT NULL,
  [StartDate] DATETIME NOT NULL,
  [EndDate] DATETIME,
  [Deadline] DATETIME,
  [SubtaskOf] int FOREIGN KEY REFERENCES [Task](Task_Id),
  PRIMARY KEY ([Task_Id])
);
GO
CREATE INDEX [FK] ON  [Task] ([SubtaskOf]);