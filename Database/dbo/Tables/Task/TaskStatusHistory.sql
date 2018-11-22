CREATE TABLE [TaskStatusHistory] (
  [Task_Id] int FOREIGN KEY REFERENCES [Task](Task_Id),
  [TaskStatus_Id] int FOREIGN KEY REFERENCES [TaskStatus](TaskStatus_Id) NOT NULL,
  [date] datetime2(0) DEFAULT SYSDATETIME(),
  PRIMARY KEY ([Task_Id],[date])
);
GO
CREATE INDEX [FK] ON  [TaskStatusHistory] ([TaskStatus_Id]);