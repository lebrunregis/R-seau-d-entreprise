CREATE PROCEDURE [dbo].[DeleteProject]
	@Id int,
	@Name nvarchar(50),
	@Description nvarchar(max),
	@Creator int,
	@StartDate datetime2,
	@EndDate datetime2
AS
	DELETE FROM Project 
	WHERE Project_Id = @Id AND Project_Name=@Name AND Project_Description=@Description AND
	CreatorId=@Creator  AND StartDate = @StartDate  AND (EndDate = @EndDate) OR (EndDate IS NULL AND @EndDate IS NULL);