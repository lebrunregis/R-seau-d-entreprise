CREATE PROCEDURE [dbo].[CreateEvent]
	@Name nvarchar(50) ,
	@Description nvarchar(max) ,
	@Address nvarchar(max),
	@StartDate datetime2(0),
	@EndDate datetime2(0),
	@DepartmentId int,
	@AdminId int
AS
	INSERT INTO Event (Name,Description ,Address,StartDate,EndDate,CreatorId,DepartmentId) 
	VALUES (@Name,@Description,@Address,@StartDate,@EndDate,@AdminId,@DepartmentId);
RETURN convert(int,SCOPE_IDENTITY() );
