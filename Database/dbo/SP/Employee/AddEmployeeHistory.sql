CREATE PROCEDURE [dbo].[AddEmployeeHistory]
	@employeeId int,
	@statusId int
AS
	INSERT INTO EmployeeStatusHistory(Employee_Id,EmployeeStatus_Id) VALUES (@employeeId, @statusId)

