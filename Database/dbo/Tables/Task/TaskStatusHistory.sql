CREATE TABLE [TaskStatusHistory] (
  [Task_Id] int,
  [TaskStatus_Id] int,
  [date] datetime2(0),
  PRIMARY KEY ([Task_Id],[date])
);
GO
CREATE INDEX [FK] ON  [TaskStatusHistory] ([TaskStatus_Id]);