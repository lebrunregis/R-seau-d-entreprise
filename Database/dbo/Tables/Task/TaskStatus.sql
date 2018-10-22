CREATE TABLE [TaskStatus] (
  [TaskStatus_Id] int NOT NULL identity(1,1),
  [Status_Name] varchar(50) NOT NULL,
  PRIMARY KEY ([TaskStatus_Id])
);
GO
CREATE INDEX [FK] ON  [TaskStatus] ([Status_Name]);