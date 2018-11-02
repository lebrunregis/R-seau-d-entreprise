CREATE PROCEDURE [dbo].[GetAllEmployeesForAdmin]
AS
	SELECT e.Employee_Id, e.FirstName, e.LastName, e.Email, e.RegNat, e.[Address], e.Phone, a.Actif
	from [dbo].Employee e LEFT JOIN Admin a ON e.Employee_Id=a.Employee_Id WHERE e.Active=1