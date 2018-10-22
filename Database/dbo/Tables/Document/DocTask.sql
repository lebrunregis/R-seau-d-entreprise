CREATE TABLE [DocTask] (
  [Document_id] int FOREIGN KEY REFERENCES [Document](Document_id),
  [Task_id] int  FOREIGN KEY REFERENCES [Task](Task_id)
  PRIMARY KEY ([Document_id], [Task_id])
);
GO
CREATE INDEX [PFK] ON  [DocTask] ([Document_id]);
GO
CREATE INDEX [FK] ON  [DocTask] ([Task_id]);
GO