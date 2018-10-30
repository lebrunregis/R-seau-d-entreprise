CREATE TABLE [Document] (
  [Document_Id] int PRIMARY KEY IDENTITY,
  [Name] nvarchar(max) NOT NULL,
  [Created] DATETIME2(0) NOT NULL,
  [Link] nvarchar(max) NOT NULL,
  [Size] float NOT NULL,
  [SHA2] varbinary(32) NOT NULL,
  [Actif] bit NOT NULL,
  [Employee_Id] int NOT NULL,
  [NextVersion] int, 
    [Deleted] DATETIME NULL,
);