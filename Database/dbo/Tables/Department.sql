CREATE TABLE [Department] (
  [Department_Id] int identity,
  [Title] nvarchar(50) NOT NULL unique,
  [Description] nvarchar(MAX) NOT NULL,
  [Admin_Id] int NOT NULL FOREIGN KEY REFERENCES [Admin](Employee_Id),
  PRIMARY KEY ([Department_Id])
);
GO
CREATE INDEX [SK] ON  [Department] ([Title]);
GO
CREATE INDEX [FK] ON  [Department] ([Admin_Id]);