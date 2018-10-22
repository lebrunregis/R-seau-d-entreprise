CREATE TABLE [TeamTask] (
  [Team_Id] int FOREIGN KEY REFERENCES [Team](Team_Id),
  [Task_Id] int FOREIGN KEY REFERENCES [Task](Task_Id),
  PRIMARY KEY ([Team_Id],[Task_Id])
);