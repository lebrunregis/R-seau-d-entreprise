CREATE TABLE [DocEvent] (
  [Document_Id] int  FOREIGN KEY REFERENCES [Document](Document_Id),
  [Event_Id] int  FOREIGN KEY REFERENCES [Event](Event_Id)
  PRIMARY KEY ([Document_Id], [Event_Id])
);
GO
CREATE INDEX [PFK] ON  [DocEvent] ([Document_Id]);
GO
CREATE INDEX [FK] ON  [DocEvent] ([Event_Id]);