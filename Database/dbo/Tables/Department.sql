CREATE TABLE [Department] (
  [Department_Id] int,
  [Title] nvarchar(50),
  [Description] nvarchar(MAX),
  [Admin_Id] int,
  PRIMARY KEY ([Department_Id])
);
GO
CREATE INDEX [SK] ON  [Department] ([Title]);
GO
CREATE INDEX [FK] ON  [Department] ([Admin_Id]);