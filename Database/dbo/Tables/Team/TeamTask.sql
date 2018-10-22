CREATE TABLE [TeamTask] (
  [Team_Id] int FOREIGN KEY REFERENCES [Team](Team_Id),
  [Task_Id] int FOREIGN KEY REFERENCES [Task](Task_Id)
);
GO
CREATE INDEX [FK] ON  [TeamTask] ([Team_Id]);
GO
CREATE INDEX [PFK] ON  [TeamTask] ([Task_Id]);