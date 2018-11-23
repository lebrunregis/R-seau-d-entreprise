CREATE PROCEDURE [dbo].[GetEmployeeSubscriptionStatus]
	@EventId int,
	@EmployeeId int
AS
	SELECT Employee.Employee_Id as Employee_Id,FirstName,LastName,Email,@EventId as Event_Id,Subscribed,Attended,Cancelled 
	FROM EmployeeEvent RIGHT JOIN Employee ON EmployeeEvent.Employee_Id = Employee.Employee_Id
	WHERE (Event_Id = @EventId OR Event_Id IS NULL) AND Employee.Employee_Id = @EmployeeId
RETURN 0
