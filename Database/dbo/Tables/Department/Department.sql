CREATE TABLE [Department] (
  [Department_Id] INT IDENTITY,
  [Name] NVARCHAR(50) NOT NULL UNIQUE,
  [Description] NVARCHAR(MAX) NOT NULL,
  [Created] DATETIME2(0) NOT NULL DEFAULT SYSDATETIME(),
  [Creator_Id] INT NOT NULL FOREIGN KEY REFERENCES [Admin](Employee_Id),
  [Active] BIT NOT NULL DEFAULT 1, 
    PRIMARY KEY ([Department_Id])
);
GO
CREATE INDEX [SK] ON  [Department] ([Name]);
GO
CREATE INDEX [FK] ON  [Department] ([Creator_Id]);