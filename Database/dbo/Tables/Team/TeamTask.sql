CREATE TABLE [TeamTask] (
  [Team_Id] int,
  [Task_Id] int
);
GO
CREATE INDEX [FK] ON  [TeamTask] ([Team_Id]);
GO
CREATE INDEX [PFK] ON  [TeamTask] ([Task_Id]);