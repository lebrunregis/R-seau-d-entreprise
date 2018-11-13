CREATE PROCEDURE [dbo].[DeleteProject]
    @User int,
	@Id int,
	@Name nvarchar(50),
	@Description nvarchar(max),
	@Creator int,
	@StartDate datetime2,
	@EndDate datetime2
AS

	DELETE FROM Project 
	WHERE Project_Id = @Id AND Project_Name=@Name AND Project_Description=@Description AND
	CreatorId=@Creator  AND StartDate = CAST(@StartDate AS datetime2(0)) AND (EndDate = CAST(@EndDate AS datetime2(0))) OR (EndDate IS NULL AND @EndDate IS NULL);