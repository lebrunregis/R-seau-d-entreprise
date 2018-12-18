CREATE TABLE [Document] (
  [GUID] [uniqueidentifier] ROWGUIDCOL NOT NULL UNIQUE DEFAULT NEWID() ,
  [Document_Id] int PRIMARY KEY IDENTITY,
  [Name] nvarchar(max) NOT NULL,
  [Created] DATETIME2(0) NOT NULL DEFAULT SYSDATETIME(),
  [Body] VARBINARY(MAX) FILESTREAM NOT NULL DEFAULT CONVERT(varbinary, ''),
  [Size] INT NULL,
  [SHA2] varbinary(32) NULL,
  [Actif] bit NOT NULL DEFAULT 1,
  [Employee_Id] int NOT NULL,
  [NextVersion] int, 
  [Deleted] DATETIME2(0) NULL,
  CONSTRAINT FK_Document_Employee_Id FOREIGN KEY (Employee_Id)
    REFERENCES Employee(Employee_Id),
  CONSTRAINT FK_Document_NextVersion FOREIGN KEY (Document_Id)
    REFERENCES Document(Document_Id),
);