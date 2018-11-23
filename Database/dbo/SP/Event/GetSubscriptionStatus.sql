CREATE PROCEDURE [dbo].[GetSubscriptionStatus]
	@EventId int
AS
	SELECT Employee.Employee_Id as Employee_Id ,FirstName,LastName,Email, @EventId as Event_Id,Subscribed, Attended,Cancelled 
	FROM EmployeeEvent 
	RIGHT JOIN Employee ON EmployeeEvent.Employee_Id = Employee.Employee_Id
	WHERE Event_Id = @EventId OR Event_Id IS NULL
RETURN 0
