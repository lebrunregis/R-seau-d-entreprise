CREATE PROCEDURE [dbo].[RegisterEmployeeToEvent]
	@EventId int ,
	@EmployeeId int
AS
	INSERT INTO EmployeeEvent (Employee_Id,Event_Id) VALUES (@EmployeeId , @EventId);
RETURN 0
