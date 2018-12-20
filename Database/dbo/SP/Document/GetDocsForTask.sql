CREATE PROCEDURE [dbo].[GetDocsForTask]
	@Task_Id int
AS
BEGIN
	SELECT select_rank.Document_Id, select_rank.[Name], select_rank.Created, select_rank.Size, select_rank.Actif, select_rank.Employee_Id, select_rank.Deleted FROM
	(
		SELECT d.Document_Id, d.[Name], d.Created, d.Size, d.Actif, d.Employee_Id, d.Deleted,
		RANK() OVER (PARTITION BY d.Document_Id ORDER BY d.Created DESC) r
		FROM Document d INNER JOIN DocTask other ON d.Document_Id = other.Document_Id
		WHERE other.Task_Id = @Task_Id
	) select_rank
	WHERE select_rank.r = 1
END	    
