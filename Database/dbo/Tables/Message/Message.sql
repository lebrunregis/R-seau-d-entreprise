CREATE TABLE [dbo].[Message]
(
	[Message_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Message_Title] NVARCHAR(50) NOT NULL, 
    [Message_Date] DATE NOT NULL, 
    [Message_Message] NVARCHAR(MAX) NOT NULL, 
    [Message_Parent] NCHAR(10) NULL
)
