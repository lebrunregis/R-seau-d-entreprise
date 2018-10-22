CREATE TABLE [DocMessage] (
  [Document_Id] int FOREIGN KEY REFERENCES [Document](Document_Id),
  [Message_Id] int  FOREIGN KEY REFERENCES [Message](Message_Id)
  PRIMARY KEY ([Document_Id], [Message_Id])
);
GO
CREATE INDEX [PFK] ON  [DocMessage] ([Document_Id], [Message_Id]);