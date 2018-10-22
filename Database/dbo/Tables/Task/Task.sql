CREATE TABLE [Task] (
  [Task_Id] int,
  [Name] nvarchar(50) NOT NULL,
  [Description] nvarchar(max) NOT NULL,
  [StartDate] date NOT NULL,
  [EndDate] date,
  [Deadline] date,
  [SubtaskOf] int FOREIGN KEY REFERENCES [Task](Task_Id),
  PRIMARY KEY ([Task_Id])
);
GO
CREATE INDEX [FK] ON  [Task] ([SubtaskOf]);