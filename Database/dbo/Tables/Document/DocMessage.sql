CREATE TABLE [DocMessage] (
  [Document_Id] int,
  [Message_Id] int  FOREIGN KEY REFERENCES [Message](Message_Id)
  PRIMARY KEY ([Document_Id], [Message_Id])
);
GO
CREATE INDEX [PFK] ON  [DocMessage] ([Document_Id], [Message_Id]);