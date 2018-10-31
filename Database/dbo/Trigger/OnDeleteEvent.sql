CREATE TRIGGER [OnDeleteEvent]
ON Event
INSTEAD OF DELETE
AS
BEGIN
	SET NOCOUNT ON
	UPDATE Event Set EndDate = GetDate() WHERE Event_Id in (SELECT Event_Id FROM deleted);;
END