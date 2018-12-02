CREATE PROCEDURE [dbo].[GetMyDiscussionWithEmployeeWithoutSome]
	@MyId int,
	@EmployeeId int,
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
	FROM [Message] m JOIN MessageEmployee me ON m.Message_Id=me.Message_Id
	LEFT JOIN @temptable t ON m.Message_Id=t.id
	WHERE ((me.Employee_Id=@EmployeeId AND m.Message_Author=@MyId)
	   OR (me.Employee_Id=@MyId AND m.Message_Author=@EmployeeId))
	   AND t.id IS NULL
END
