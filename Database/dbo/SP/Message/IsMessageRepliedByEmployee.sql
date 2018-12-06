CREATE PROCEDURE [dbo].[IsMessageRepliedByEmployee]
	@EmployeeId int,
	@MessageId int
AS
	SELECT CAST (COUNT (*) AS bit)
	FROM [Message] m JOIN [Message] child ON child.Message_Parent=m.Message_Id
	WHERE m.Message_Id=@MessageId AND child.Message_Author=@EmployeeId
