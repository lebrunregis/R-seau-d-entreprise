CREATE TABLE [dbo].[MessageTeam]
(
	[Message_Id] INT NOT NULL PRIMARY KEY FOREIGN KEY REFERENCES [Message](Message_Id), 
    [Team_Id] INT NOT NULL FOREIGN KEY REFERENCES Team(Team_Id)
)
