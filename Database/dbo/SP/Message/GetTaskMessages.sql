CREATE PROCEDURE [dbo].[GetTaskMessages]
	@TaskId int
AS
	SELECT m.Message_Id, m.Message_Title, m.Message_Date, m.Message_Message, m.Message_Parent, m.Message_Author
	FROM [Message] m JOIN MessageTask mt ON m.Message_Id=mt.Message_Id WHERE mt.Task_Id=@TaskId
