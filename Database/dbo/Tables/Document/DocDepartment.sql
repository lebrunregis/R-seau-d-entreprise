CREATE TABLE [DocDepartement] (
  [Document_id] int FOREIGN KEY REFERENCES [Document](Document_id),
  [Departement_id] int FOREIGN KEY REFERENCES [Department](Department_id)
  PRIMARY KEY ([Document_id], [Departement_id])
);
GO
CREATE INDEX [FK_Doc] ON  [DocDepartement] ([Document_id]);
GO
CREATE INDEX [FK_Dep] ON  [DocDepartement] ([Departement_id]);