CREATE TRIGGER [dbo].[OnDeleteProject]
ON Project
INSTEAD OF DELETE
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @DeletedProjects table(Project_Id int);
	INSERT INTO @DeletedProjects(Project_Id) SELECT Project_Id FROM deleted d  WHERE d.EndDate IS NULL OR d.EndDate > GetDate();
	UPDATE Project Set EndDate = GetDate() WHERE Project_Id in (SELECT Project_Id FROM @DeletedProjects);
	DELETE FROM Team WHERE Project_Id IN (SELECT Project_Id FROM @DeletedProjects);
END