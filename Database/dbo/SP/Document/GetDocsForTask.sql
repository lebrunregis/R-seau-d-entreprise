CREATE PROCEDURE [dbo].[GetDocsForTask]
	@Task_Id int
AS
BEGIN
	SELECT select_rank.Document_Id, select_rank.[Name], select_rank.Created, select_rank.Size, select_rank.Employee_Id, select_rank.Deleted, select_rank.[Checksum] FROM
	(
		SELECT d.Document_Id, d.[Name], d.Created, d.Size, d.Employee_Id, d.Deleted, d.[Checksum],
		RANK() OVER (PARTITION BY d.Document_Id ORDER BY d.Created DESC) r
		FROM Document d INNER JOIN DocTask other ON d.Document_Id = other.Document_Id
		WHERE other.Task_Id = @Task_Id AND d.Deleted IS NULL
	) select_rank
	WHERE select_rank.r = 1
END	    
