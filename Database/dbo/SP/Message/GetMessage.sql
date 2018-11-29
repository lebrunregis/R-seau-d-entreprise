CREATE PROCEDURE [dbo].[GetMessage]
	@id int
AS
	SELECT Message_Id, Message_Title, Message_Date, Message_Message, Message_Parent, Message_Author FROM [Message] WHERE Message_Id=@id