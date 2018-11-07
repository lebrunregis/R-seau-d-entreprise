CREATE TABLE [ProjectTask] (
  [Project_Id] int,
  [Task_Id] int
  PRIMARY KEY ([Project_Id], [Task_Id]),
  CONSTRAINT FK_ProjectTaskId FOREIGN KEY (Project_Id) REFERENCES Project(Project_Id),
  CONSTRAINT FK_TaskProjectId FOREIGN KEY (Task_Id) REFERENCES Task(Task_Id)
  )