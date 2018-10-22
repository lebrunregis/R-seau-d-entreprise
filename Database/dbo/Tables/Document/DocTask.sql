CREATE TABLE [DocTask] (
  [Document_id] int PRIMARY KEY IDENTITY,
  [Task_id] int
  PRIMARY KEY ([Document_id], [Task_id])
);
GO
CREATE INDEX [PFK] ON  [DocTask] ([Document_id]);
GO
CREATE INDEX [FK] ON  [DocTask] ([Task_id]);
GO