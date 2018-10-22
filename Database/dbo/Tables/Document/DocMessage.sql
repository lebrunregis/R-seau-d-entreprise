CREATE TABLE [DocMessage] (
  [Document_Id] int FOREIGN KEY REFERENCES [Document](Document_id),
  [Message_Id] int  FOREIGN KEY REFERENCES [Message](Message_id)
  PRIMARY KEY ([Document_id], [Message_Id])
);
GO
CREATE INDEX [PFK] ON  [DocMessage] ([Document_Id], [Message_Id]);