CREATE PROCEDURE [dbo].[CreateDepartment]
	@Name nvarchar (50),
	@Description nvarchar (max),
	@AdminId int
AS
BEGIN
    IF dbo.FN_IsAdmin(@AdminId) = 1
	BEGIN
       DECLARE @DepId table(id int);
	   INSERT INTO Department(Name,Description,Creator_Id) OUTPUT INSERTED.Department_Id INTO @DepId(id) VALUES (@Name,@Description,@AdminId);
       SELECT TOP 1 id FROM @DepId;
	END
END