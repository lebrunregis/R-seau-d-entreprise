/*
La base de données doit avoir un groupe de fichiers MEMORY_OPTIMIZED_DATA
avant de créer l'objet mémoire optimisé.
*/

CREATE PROCEDURE [dbo].[Update_Employee]
	@Employee_Id int,
    @LastName nvarchar(50),
    @FirstName nvarchar(50),
    @Email nvarchar(360),
    @Passwd nvarchar(50),
    @Address nvarchar(50),
    @Phone varchar(50)

AS
UPDATE Employee SET LastName=@LastName, FirstName=@FirstName, Email=@Email, Passwd=@Passwd, [Address]=@Address, Phone=@Phone WHERE Employee_Id=@Employee_Id