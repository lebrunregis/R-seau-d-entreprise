CREATE TABLE [dbo].[MessageEmployee]
(
	[Message_Id] INT NOT NULL PRIMARY KEY FOREIGN KEY REFERENCES [Message](Message_Id), 
    [Employee_Id] INT NOT NULL FOREIGN KEY REFERENCES Employee(Employee_Id)
)
