CREATE TABLE [DocProject] (
  [Document_Id] int,
  [Project_Id] int  FOREIGN KEY REFERENCES [Project](Project_Id)
  PRIMARY KEY ([Document_Id], [Project_Id])
);
GO
CREATE INDEX [PFK] ON  [DocProject] ([Document_Id]);
GO
CREATE INDEX [FK] ON  [DocProject] ([Project_Id]);
GO