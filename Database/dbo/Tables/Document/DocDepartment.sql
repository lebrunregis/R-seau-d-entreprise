CREATE TABLE [DocDepartement] (
  [Document_Id] int FOREIGN KEY REFERENCES [Document](Document_Id),
  [Departement_Id] int FOREIGN KEY REFERENCES [Department](Department_Id)
  PRIMARY KEY ([Document_Id], [Departement_Id])
);
GO
CREATE INDEX [FK_Doc] ON  [DocDepartement] ([Document_Id]);
GO
CREATE INDEX [FK_Dep] ON  [DocDepartement] ([Departement_Id]);