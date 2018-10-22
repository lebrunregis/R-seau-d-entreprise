CREATE TABLE [TaskStatus] (
  [TakStatus_Id] int,
  [Status_Name] varchar(50),
  PRIMARY KEY ([TakStatus_Id])
);
GO
CREATE INDEX [FK] ON  [TaskStatus] ([Status_Name]);