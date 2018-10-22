CREATE TABLE [DocEvent] (
  [Document_id] int  FOREIGN KEY REFERENCES [Document](Document_id),
  [Event_id] int  FOREIGN KEY REFERENCES [Event](Event_id)
  PRIMARY KEY ([Document_id], [Event_id])
);
GO
CREATE INDEX [PFK] ON  [DocEvent] ([Document_id]);
GO
CREATE INDEX [FK] ON  [DocEvent] ([Event_id]);