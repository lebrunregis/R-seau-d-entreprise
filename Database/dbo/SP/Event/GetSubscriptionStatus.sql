CREATE PROCEDURE [dbo].[GetSubscriptionStatus]
	@EventId int
AS
	SELECT Employee_Id  ,@EventId as Event_Id,Subscribed, Attended,Cancelled 
	FROM EmployeeEvent 
	
	WHERE Event_Id = @EventId OR Event_Id IS NULL
RETURN 0
