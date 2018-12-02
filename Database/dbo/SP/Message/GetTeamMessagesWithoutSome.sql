CREATE PROCEDURE [dbo].[GetTeamMessagesWithoutSome]
	@TeamId int,
	@NotNeededIds varchar(max)
AS
BEGIN
    DECLARE @temptable table(id int)
	DECLARE @index int
	WHILE(LEN(@NotNeededIds) > 0)
	BEGIN
	    SET @index = CHARINDEX(',', @NotNeededIds)
	    INSERT INTO @temptable(id) VALUES(SUBSTRING(@NotNeededIds, 1, @index-1))
		SET @NotNeededIds = SUBSTRING(@NotNeededIds, @index+1, LEN(@NotNeededIds))
	END
	SELECT m.Message_Id, m.Message_Title, m.Message_Date, m.Message_Message, m.Message_Parent, m.Message_Author
	FROM [Message] m JOIN MessageTeam mt ON m.Message_Id=mt.Message_Id
	LEFT JOIN @temptable t ON m.Message_Id=t.id
	WHERE mt.Team_Id=@TeamId
	AND t.id IS NULL
END
