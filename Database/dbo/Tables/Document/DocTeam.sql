CREATE TABLE [DocTeam] (
  [Document_id] int  FOREIGN KEY REFERENCES [Document](Document_id),
  [Team_id] int  FOREIGN KEY REFERENCES [Team](Team_id)
  PRIMARY KEY ([Document_id], [Team_id])
);
GO
CREATE INDEX [PFK] ON  [DocTeam] ([Document_id]);
GO
CREATE INDEX [FK] ON  [DocTeam] ([Team_id]);