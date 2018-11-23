CREATE PROCEDURE [dbo].[GetEmployeeSubscriptionStatus]
	@EventId int,
	@EmployeeId int
AS
	SELECT Employee_Id ,@EventId as Event_Id,Subscribed,Attended,Cancelled 
	FROM EmployeeEvent 
	WHERE (Event_Id = @EventId OR Event_Id IS NULL) AND Employee_Id = @EmployeeId
RETURN 0
