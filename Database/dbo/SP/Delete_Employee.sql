CREATE PROCEDURE [dbo].[Delete_Employee]
	@Employee_Id int
AS
DELETE FROM Employee WHERE Employee_Id=@Employee_Id;
