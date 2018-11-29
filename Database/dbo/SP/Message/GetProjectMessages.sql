CREATE PROCEDURE [dbo].[GetProjectMessages]
	@ProjectId int
AS
	SELECT m.Message_Id, m.Message_Title, m.Message_Date, m.Message_Message, m.Message_Parent, m.Message_Author
	FROM [Message] m JOIN MessageProject mp ON m.Message_Id=mp.Message_Id WHERE mp.Project_Id=@ProjectId
