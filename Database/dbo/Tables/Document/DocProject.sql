CREATE TABLE [DocProject] (
  [Document_id] int PRIMARY KEY IDENTITY,
  [Project_id] int
  PRIMARY KEY ([Document_id], [Project_id])
);
GO
CREATE INDEX [PFK] ON  [DocProject] ([Document_id]);
GO
CREATE INDEX [FK] ON  [DocProject] ([Project_id]);
GO