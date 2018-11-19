CREATE PROCEDURE [dbo].[GetAllEventsForUser]
	@EmpId int
AS
	SELECT Event.Event_Id,CreatorId,[Event].[Name],[Event].[Description],[Event].[Address],[Event].StartDate,
	[Event].EndDate,CreationDate,[Event].Cancelled,[Open] ,Subscribed
	FROM Event 
	JOIN EmployeeEvent ON Event.Event_Id = EmployeeEvent.Event_Id 
	JOIN Employee ON EmployeeEvent.Employee_Id = Employee.Employee_Id
	JOIN EmployeeDepartment ON Employee.Employee_Id = EmployeeDepartment.Employee_Id
	JOIN Department ON EmployeeDepartment.Department_Id = DepartmentId
	WHERE Department.Active= 1 AND EmployeeDepartment.EndDate IS NULL AND Event.Cancelled = 0 ;
RETURN 0
