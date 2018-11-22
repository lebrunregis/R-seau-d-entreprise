CREATE PROCEDURE [dbo].[CreateEvent]
	@Name nvarchar(50) ,
	@Description nvarchar(max) ,
	@Address nvarchar(max),
	@StartDate datetime2(0),
	@EndDate datetime2(0),
	@DepartmentId int,
	@AdminId int,
	@Open bit
AS
	INSERT INTO Event (Name,Description ,Address,StartDate,EndDate,CreatorId,DepartmentId) 
	VALUES (@Name,@Description,@Address,@StartDate,@EndDate,@AdminId,@DepartmentId);
RETURN CONVERT(int,SCOPE_IDENTITY() );
