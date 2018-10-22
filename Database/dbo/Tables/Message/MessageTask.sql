CREATE TABLE [dbo].[MessageTask]
(
	[Message_Id] INT NOT NULL PRIMARY KEY FOREIGN KEY REFERENCES [Message](Message_Id), 
    [Task_Id] INT NOT NULL FOREIGN KEY REFERENCES Task(Task_Id)
)
