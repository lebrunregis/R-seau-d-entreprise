CREATE TABLE [DocDepartment] (
  [Document_Id] int,
  [Department_Id] int FOREIGN KEY REFERENCES [Department](Department_Id)
  PRIMARY KEY ([Document_Id], [Department_Id])
);
GO
CREATE INDEX [FK_Doc] ON  [DocDepartment] ([Document_Id]);
GO
CREATE INDEX [FK_Dep] ON  [DocDepartment] ([Department_Id]);