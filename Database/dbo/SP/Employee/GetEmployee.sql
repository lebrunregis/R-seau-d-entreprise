CREATE PROCEDURE [dbo].[GetEmployee]
	@Id int
AS
	SELECT Employee_Id, LastName, FirstName, Email, RegNat, [Address], Phone FROM [dbo].Employee WHERE Employee_Id=@Id
