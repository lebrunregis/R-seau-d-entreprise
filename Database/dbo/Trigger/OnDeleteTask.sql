CREATE TRIGGER [dbo].[OnDeleteTask]
ON Task
INSTEAD OF DELETE
AS
BEGIN
	SET NOCOUNT ON
	UPDATE Task Set EndDate = GetDate() WHERE Task_Id in (SELECT Task_Id FROM deleted);
END