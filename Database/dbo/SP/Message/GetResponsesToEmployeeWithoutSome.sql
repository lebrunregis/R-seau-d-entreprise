CREATE PROCEDURE [dbo].[GetResponsesToEmployeeWithoutSome]
	@EmployeeId int,
	@max_id int
AS
	SELECT m.Message_Id, m.Message_Title, m.Message_Date, m.Message_Message, m.Message_Parent, m.Message_Author
	FROM [Message] m
	LEFT JOIN [Message] mp ON m.Message_Parent=mp.Message_Id
	LEFT JOIN MessageEmployee me ON m.Message_Id=me.Message_Id

	WHERE ((me.Employee_Id=@EmployeeId)
	   OR (me.Employee_Id IS NULL AND mp.Message_Author=@EmployeeId))
	   AND m.Message_Id > @max_id
	ORDER BY m.Message_Id DESC
