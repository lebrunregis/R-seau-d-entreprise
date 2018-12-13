CREATE TABLE [dbo].[Message]
(
	[Message_Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Message_Title] NVARCHAR(50) NULL , 
    [Message_Date] DATETIME2 NOT NULL DEFAULT SYSDATETIME(), 
    [Message_Message] NVARCHAR(MAX) NOT NULL, 
    [Message_Parent] int NULL FOREIGN KEY REFERENCES [Message](Message_Id),
	[Message_Author] int not null FOREIGN KEY REFERENCES Employee(Employee_Id)
)
