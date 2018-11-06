CREATE PROCEDURE [dbo].[GetEmployeeStatusHistory]
	@Employee_Id int
AS
SELECT s.[Name], h.StartDate, h.EndDate
FROM EmployeeStatusHistory h INNER JOIN EmployeeStatus s ON h.EmployeeStatus_Id=s.EmployeeStatus_Id
WHERE h.Employee_Id=@Employee_Id
ORDER BY (CASE WHEN h.EndDate IS NULL THEN 0 ELSE 1 END), EndDate DESC
