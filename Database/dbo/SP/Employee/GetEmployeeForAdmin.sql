CREATE PROCEDURE [dbo].[GetEmployeeForAdmin]
	@Id int
AS
	SELECT e.Employee_Id, e.LastName, e.FirstName, e.Email, e.RegNat, e.[Address], e.Phone, a.Actif, e.Active as EmployeeActive
	FROM [dbo].Employee e LEFT JOIN [dbo].[Admin] a ON e.Employee_Id=a.Employee_Id
	WHERE e.Employee_Id=@Id
