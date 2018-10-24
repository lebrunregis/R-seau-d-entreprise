CREATE TABLE [DocTask] (
  [Document_Id] int FOREIGN KEY REFERENCES [Document](Document_Id),
  [Task_Id] int  FOREIGN KEY REFERENCES [Task](Task_Id)
  PRIMARY KEY ([Document_Id], [Task_Id])
);
GO
CREATE INDEX [PFK] ON  [DocTask] ([Document_Id]);
GO
CREATE INDEX [FK] ON  [DocTask] ([Task_Id]);
GO