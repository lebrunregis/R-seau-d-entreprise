CREATE TABLE [Document] (
  [Document_id] int PRIMARY KEY IDENTITY,
  [Name] nvarchar(max) NOT NULL,
  [Created] datetime NOT NULL,
  [Link] nvarchar(max) NOT NULL,
  [Size] float NOT NULL,
  [SHA2] varbinary(32) NOT NULL,
  [Actif] bit NOT NULL,
  [Employee_Id] int NOT NULL,
  [NextVersion] int,
);
GO
CREATE INDEX [SK] ON  [Document] ([Link]);
GO
CREATE INDEX [FK] ON  [Document] ([Employee_Id], [NextVersion]);