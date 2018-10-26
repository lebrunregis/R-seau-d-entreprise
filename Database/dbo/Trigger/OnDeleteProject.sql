CREATE TRIGGER [dbo].[OnDeleteProject]
ON Project
INSTEAD OF DELETE
AS
BEGIN
	SET NOCOUNT ON
	UPDATE Project Set EndDate = GetDate();
END
