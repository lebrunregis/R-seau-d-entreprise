/*
La base de données doit avoir un groupe de fichiers MEMORY_OPTIMIZED_DATA
avant de créer l'objet mémoire optimisé.
*/

CREATE PROCEDURE [dbo].[Update_Employee]
	@Employee_Id int,
    @LastName nvarchar(50),
    @FirstName nvarchar(50),
    @Address nvarchar(MAX),
    @Phone varchar(50)

AS
UPDATE Employee SET LastName=[dbo].FN_StrClean(@LastName), FirstName=[dbo].FN_StrClean(@FirstName), [Address]=[dbo].FN_StrClean(@Address), Phone=NULLIF([dbo].FN_StrClean(@Phone),'')
WHERE Employee_Id=@Employee_Id AND Active=1