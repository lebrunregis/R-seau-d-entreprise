CREATE TRIGGER [dbo].[OnDeleteProject]
ON Project
INSTEAD OF DELETE
AS
BEGIN
	SET NOCOUNT ON
	DECLARE @DeletedProjects table(Project_Id int);
	INSERT INTO @DeletedProjects(Project_Id) SELECT Project_Id FROM deleted d  WHERE d.EndDate IS NULL OR d.EndDate > SYSDATETIME();
	UPDATE Project Set EndDate = SYSDATETIME() WHERE Project_Id in (SELECT Project_Id FROM @DeletedProjects);
END