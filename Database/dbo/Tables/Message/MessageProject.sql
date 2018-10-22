CREATE TABLE [dbo].[MessageProject]
(
	[Message_Id] INT NOT NULL PRIMARY KEY FOREIGN KEY REFERENCES [Message](Message_Id), 
    [Project_Id] INT NOT NULL FOREIGN KEY REFERENCES Project(Project_Id)
)
