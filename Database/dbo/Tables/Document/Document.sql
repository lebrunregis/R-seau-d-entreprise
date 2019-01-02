CREATE TABLE [Document] (
  [Document_Id] INT NOT NULL,
  [Name] nvarchar(max) NOT NULL,
  [Created] DATETIME2(0) NOT NULL DEFAULT SYSDATETIME(),
  [Body] VARBINARY(MAX) NOT NULL,
  [Size] BIGINT NOT NULL,
  [Checksum] int NOT NULL,
  [Employee_Id] int NOT NULL,
  [Deleted] DATETIME2(0) NULL,
  CONSTRAINT PK_Document PRIMARY KEY (Document_Id, Created),
  CONSTRAINT FK_Document_Employee_Id FOREIGN KEY (Employee_Id)
    REFERENCES Employee(Employee_Id)
);