CREATE TABLE [Department] (
  [Department_Id] INT IDENTITY,
  [Title] NVARCHAR(50) NOT NULL UNIQUE,
  [Description] NVARCHAR(MAX) NOT NULL,
  [Admin_Id] INT NOT NULL FOREIGN KEY REFERENCES [Admin](Employee_Id),
  [Active] BIT NOT NULL DEFAULT 1, 
    PRIMARY KEY ([Department_Id])
);
GO
CREATE INDEX [SK] ON  [Department] ([Title]);
GO
CREATE INDEX [FK] ON  [Department] ([Admin_Id]);