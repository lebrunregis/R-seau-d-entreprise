CREATE PROCEDURE [dbo].[SetEmployeeStatus]
	@EmployeeId int ,
	@StatusId int,
	@StartDate Datetime2(0),
	@EndDate Datetime2(0)
AS
	INSERT INTO EmployeeStatusHistory (Employee_Id,EmployeeStatus_Id,StartDate,EndDate) 
	VALUES (@EmployeeId ,@StatusId,@StartDate ,@EndDate )
RETURN 0
