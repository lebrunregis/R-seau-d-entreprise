CREATE TABLE [DocEvent] (
  [Document_id] int PRIMARY KEY IDENTITY,
  [Event_id] int
  PRIMARY KEY ([Document_id], [Event_id])
);
GO
CREATE INDEX [PFK] ON  [DocEvent] ([Document_id]);
GO
CREATE INDEX [FK] ON  [DocEvent] ([Event_id]);