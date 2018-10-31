﻿CREATE TRIGGER [OnDeleteEvent]
ON Event
INSTEAD OF DELETE
AS
BEGIN
	SET NOCOUNT ON
	UPDATE Event Set EndDate = GetDate();
END