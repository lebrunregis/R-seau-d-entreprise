CREATE PROCEDURE [dbo].[GetTeamMessagesWithoutSome]
	@TeamId int,
	@max_id int
AS
BEGIN
	SELECT m.Message_Id, m.Message_Title, m.Message_Date, m.Message_Message, m.Message_Parent, m.Message_Author
	FROM [Message] m JOIN MessageTeam mt ON m.Message_Id=mt.Message_Id
	WHERE mt.Team_Id=@TeamId
	AND m.Message_Id > @max_id
END
