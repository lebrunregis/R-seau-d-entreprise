CREATE TABLE [Document] (
  [Document_id] int PRIMARY KEY IDENTITY,
  [Name] nvarchar(max),
  [Created] datetime,
  [Link] nvarchar(max),
  [Size] float,
  [SHA2] varbinary,
  [Actif] bit,
  [Employee_Id] int,
  [NextVersion] int,
);
GO
CREATE INDEX [SK] ON  [Document] ([Link]);
GO
CREATE INDEX [FK] ON  [Document] ([Employee_Id], [NextVersion]);