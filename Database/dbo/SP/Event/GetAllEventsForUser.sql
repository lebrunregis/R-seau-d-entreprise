CREATE PROCEDURE [dbo].[GetAllEventsForUser]
	@EmpId int
AS
	SELECT Event.Event_Id,CreatorId,[Event].[Name],[Event].[Description],[Event].[Address],[Event].StartDate,
	[Event].EndDate,CreationDate,[Event].Cancelled,[Open] ,Subscribed , Event.DepartmentId AS DepartmentId
	FROM Event 
	LEFT JOIN (SELECT Event_Id, Subscribed FROM EmployeeEvent
		       WHERE Employee_Id = @EmpId
		       AND Cancelled != 1) EmpEvent
        ON EmpEvent.Event_Id = Event.Event_Id
	LEFT JOIN EmployeeDepartment ON Event.DepartmentId=EmployeeDepartment.Department_Id
	WHERE ((EmployeeDepartment.Employee_Id = @EmpId) OR Event.DepartmentId IS NULL)
	AND (Subscribed IS NOT NULL OR Event.[Open] = 1)
	AND Event.Cancelled = 0;
RETURN 0
