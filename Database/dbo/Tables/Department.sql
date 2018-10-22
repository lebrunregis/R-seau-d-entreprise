CREATE TABLE [Department] (
  [Department_Id] int,
  [Title] nvarchar(50) NOT NULL,
  [Description] nvarchar(MAX) NOT NULL,
  [Admin_Id] int NOT NULL,
  PRIMARY KEY ([Department_Id])
);
GO
CREATE INDEX [SK] ON  [Department] ([Title]);
GO
CREATE INDEX [FK] ON  [Department] ([Admin_Id]);