CREATE TABLE [DocDepartement] (
  [Document_id] int ,
  [Departement_id] int
  PRIMARY KEY ([Document_id], [Departement_id])
);
GO
CREATE INDEX [PFK] ON  [DocDepartement] ([Document_id]);
GO
CREATE INDEX [FK] ON  [DocDepartement] ([Departement_id]);