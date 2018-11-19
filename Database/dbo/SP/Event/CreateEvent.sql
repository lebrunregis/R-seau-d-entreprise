CREATE PROCEDURE [dbo].[CreateEvent]
	@Name nvarchar(50) ,
	@Description nvarchar(max) ,
	@Address nvarchar(max),
	@StartDate datetime2(0),
	@EndDate datetime2(0),
	@CreatorId int,
	@AdminId int
AS
	INSERT INTO Event (Name,Description ,Address,StartDate,EndDate) 
	VALUES (@Name,@Description,@Address,@StartDate,@EndDate);
RETURN convert(int,SCOPE_IDENTITY() );
