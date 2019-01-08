CREATE PROCEDURE [dbo].[GetAllEventsForUser]
	@EmpId int
AS
	SELECT DISTINCT Event.Event_Id,CreatorId,[Event].[Name],[Event].[Description],[Event].[Address],[Event].StartDate,
	[Event].EndDate,CreationDate,[Event].Cancelled,[Open] ,Subscribed , Event.DepartmentId AS DepartmentId
	FROM Event 
	LEFT JOIN EmployeeEvent ON Event.Event_Id = EmployeeEvent.Event_Id 
	LEFT JOIN Employee ON EmployeeEvent.Employee_Id = Employee.Employee_Id
	LEFT JOIN EmployeeDepartment ON Employee.Employee_Id = EmployeeDepartment.Employee_Id
	WHERE ((Event.DepartmentId=EmployeeDepartment.Department_Id ) OR Event.DepartmentId IS NULL)
	AND (EmployeeEvent.Employee_Id = @EmpId OR EmployeeEvent.Employee_Id IS NULL AND Subscribed IS NULL AND EmployeeEvent.Cancelled = 0)
	AND Event.Cancelled = 0 ;
RETURN 0
