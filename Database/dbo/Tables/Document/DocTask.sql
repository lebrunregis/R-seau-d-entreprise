CREATE TABLE [DocTask] (
  [Document_id] int FOREIGN KEY REFERENCES [Document](Document_Id),
  [Task_id] int  FOREIGN KEY REFERENCES [Task](Task_Id)
  PRIMARY KEY ([Document_id], [Task_Id])
);
GO
CREATE INDEX [PFK] ON  [DocTask] ([Document_Id]);
GO
CREATE INDEX [FK] ON  [DocTask] ([Task_id]);
GO