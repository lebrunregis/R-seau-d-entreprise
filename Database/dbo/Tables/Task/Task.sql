CREATE TABLE [Task] (
  [Task_Id] int,
  [Name] nvarchar(50),
  [Description] nvarchar(max),
  [StartDate] date,
  [EndDate] date,
  [Deadline] date,
  [SubtaskOf] int,
  PRIMARY KEY ([Task_Id])
);
GO
CREATE INDEX [FK] ON  [Task] ([SubtaskOf]);