CREATE PROCEDURE [dbo].[GetAllEvents]
AS
	SELECT Event_Id,CreatorId,DepartmentId,Name,Description,Address,StartDate,
	EndDate,CreationDate,Cancelled,[Open], NULL AS Subscribed FROM Event
RETURN 0
