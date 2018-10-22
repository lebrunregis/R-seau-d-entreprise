CREATE TABLE [Admin] (
  [Employee_Id] int,
  [Actif] bit
);
GO
CREATE INDEX [P FK] ON  [Admin] ([Employee_Id]);