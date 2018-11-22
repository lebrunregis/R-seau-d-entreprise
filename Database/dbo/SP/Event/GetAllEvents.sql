CREATE PROCEDURE [dbo].[GetAllEvents]
AS
	SELECT Event_Id,CreatorId,DepartmentId,Name,Description,Address,StartDate,
	EndDate,CreationDate,Cancelled,[Open] FROM Event
RETURN 0
