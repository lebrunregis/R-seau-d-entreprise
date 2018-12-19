CREATE TABLE [DocTeam] (
  [Document_Id] int,
  [Team_Id] int  FOREIGN KEY REFERENCES [Team](Team_Id)
  PRIMARY KEY ([Document_Id], [Team_Id])
);
GO
CREATE INDEX [PFK] ON  [DocTeam] ([Document_Id]);
GO
CREATE INDEX [FK] ON  [DocTeam] ([Team_Id]);