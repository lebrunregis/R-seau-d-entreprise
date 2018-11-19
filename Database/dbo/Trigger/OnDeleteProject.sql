CREATE TRIGGER [dbo].[OnDeleteProject]
ON Project
INSTEAD OF DELETE
AS
BEGIN
	SET NOCOUNT ON
	UPDATE Project Set EndDate = SYSDATETIME() WHERE Project_Id in (SELECT Project_Id FROM deleted);
END