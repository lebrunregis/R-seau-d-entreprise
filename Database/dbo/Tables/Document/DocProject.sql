CREATE TABLE [DocProject] (
  [Document_id] int FOREIGN KEY REFERENCES [Document](Document_id),
  [Project_id] int  FOREIGN KEY REFERENCES [Project](Project_id)
  PRIMARY KEY ([Document_id], [Project_id])
);
GO
CREATE INDEX [PFK] ON  [DocProject] ([Document_id]);
GO
CREATE INDEX [FK] ON  [DocProject] ([Project_id]);
GO