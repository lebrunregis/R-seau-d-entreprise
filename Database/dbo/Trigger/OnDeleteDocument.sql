CREATE TRIGGER [OnDeleteDocument]
ON Document
INSTEAD OF DELETE
AS
BEGIN
	SET NOCOUNT ON
	UPDATE Document Set Deleted = GetDate();
END
