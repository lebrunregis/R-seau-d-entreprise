﻿CREATE PROCEDURE [dbo].[GetAllEventsForUser]
	@EmpId int
AS
	SELECT Event.Event_Id,CreatorId,[Event].[Name],[Event].[Description],[Event].[Address],[Event].StartDate,
	[Event].EndDate,CreationDate,[Event].Cancelled,[Open] ,Subscribed , Event.DepartmentId AS DepartmentId
	FROM Event 
	LEFT JOIN EmployeeEvent ON Event.Event_Id = EmployeeEvent.Event_Id 
	LEFT JOIN Employee ON EmployeeEvent.Employee_Id = Employee.Employee_Id
	LEFT JOIN EmployeeDepartment ON Employee.Employee_Id = EmployeeDepartment.Employee_Id
	WHERE ((Event.DepartmentId=EmployeeDepartment.Department_Id AND EmployeeDepartment.EndDate IS NULL)  
	OR Event.DepartmentId IS NULL) 
	AND Event.Cancelled = 0 ;
RETURN 0
