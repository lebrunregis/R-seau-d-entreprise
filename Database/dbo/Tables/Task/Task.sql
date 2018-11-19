CREATE TABLE [Task] (
  [Task_Id] int identity,
  [Name] nvarchar(50) NOT NULL,
  [Description] nvarchar(max) NOT NULL,
  [StartDate] DATETIME2(0) NOT NULL,
  [EndDate] DATETIME2(0),
  [Deadline] DATETIME2(0),
  [SubtaskOf] int FOREIGN KEY REFERENCES [Task](Task_Id),
  PRIMARY KEY ([Task_Id])
);
GO
CREATE INDEX [FK] ON  [Task] ([SubtaskOf]);