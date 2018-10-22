CREATE TABLE [DocMessage] (
  [Document_Id] int PRIMARY KEY IDENTITY,
  [Message_Id] int
  PRIMARY KEY ([Document_id], [Message_Id])
);
GO
CREATE INDEX [PFK] ON  [DocMessage] ([Document_Id], [Message_Id]);