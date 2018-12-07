CREATE PROCEDURE [dbo].[SetEmployeeToTask]
	@TaskId int,
	@EmployeeId int
AS
	INSERT INTO EmployeeTask(Employee_Id,Task_Id) VALUES (@EmployeeId,@TaskId)
RETURN 0
