CREATE PROCEDURE [dbo].[GetProjectMessagesWithoutSome]
	@ProjectId int,
	@NotNeededIds varchar(max)
AS
BEGIN
    DECLARE @temptable table(id int)
	WHILE(LEN(@NotNeededIds) > 0)
	BEGIN
	    INSERT INTO @temptable(id)
    SELECT 
    id = cast(regex.match(@NotNeededIds,'d+') as int)
    Set @List = Substring(@List,Charindex(@SplitOn,@List)+len(@SplitOn),len(@List))
	END
	SELECT m.Message_Id, m.Message_Title, m.Message_Date, m.Message_Message, m.Message_Parent, m.Message_Author
	FROM [Message] m JOIN MessageProject mp ON m.Message_Id=mp.Message_Id WHERE mp.Project_Id=@ProjectId
END
