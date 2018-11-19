CREATE PROCEDURE [dbo].[RegisterEmployeeToEvent]
	@IdEvent int ,
	@IdEmployee int
AS
	INSERT INTO EmployeeEvent (Employee_Id,Event_Id) VALUES (@IdEvent , @IdEmployee);
RETURN 0
