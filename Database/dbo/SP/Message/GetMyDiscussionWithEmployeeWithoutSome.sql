CREATE PROCEDURE [dbo].[GetMyDiscussionWithEmployeeWithoutSome]
	@MyId int,
	@EmployeeId int,
	@max_id int
AS
BEGIN
	SELECT m.Message_Id, m.Message_Title, m.Message_Date, m.Message_Message, m.Message_Parent, m.Message_Author
	FROM [Message] m JOIN MessageEmployee me ON m.Message_Id=me.Message_Id
	WHERE ((me.Employee_Id=@EmployeeId AND m.Message_Author=@MyId)
	   OR (me.Employee_Id=@MyId AND m.Message_Author=@EmployeeId))
	   AND m.Message_Id > @max_id
END
