CREATE TABLE [Admin] (
  [Employee_Id] int NOT NULL FOREIGN KEY REFERENCES Employee(Employee_id),
  [Actif] bit NOT NULL DEFAULT 1,
  PRIMARY KEY (Employee_Id)
);
GO
CREATE INDEX [P FK] ON  [Admin] ([Employee_Id]);