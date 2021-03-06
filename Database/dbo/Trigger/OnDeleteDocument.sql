﻿CREATE TRIGGER [OnDeleteDocument]
ON [Document]
INSTEAD OF DELETE
AS
BEGIN
	SET NOCOUNT ON
	UPDATE Document Set Deleted = SYSDATETIME() WHERE Document_Id in (SELECT Document_Id FROM deleted);
END
