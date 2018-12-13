CREATE TABLE [Document] (
  [Document_Id] int PRIMARY KEY IDENTITY(1,1),
  [Name] nvarchar(max) NOT NULL,
  [Created] DATETIME2(0) NOT NULL DEFAULT SYSDATETIME(),
  [Body] VARBINARY(MAX) NOT NULL,
  [Size] float NOT NULL,
  [SHA2] varbinary(32) NOT NULL,
  [Actif] bit NOT NULL DEFAULT 1,
  [Employee_Id] int NOT NULL,
  [NextVersion] int, 
  [Deleted] DATETIME2(0) NULL,
  CONSTRAINT FK_Employee_Id FOREIGN KEY (Employee_Id)
    REFERENCES Employee(Employee_Id),
);