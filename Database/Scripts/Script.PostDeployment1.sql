/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
DELETE FROM [Admin];
DELETE FROM Employee;
DBCC CHECKIDENT ('[Admin]', RESEED, 0);
GO
DBCC CHECKIDENT ('[Employee]', RESEED, 0);
GO
EXEC [dbo].SP_Register_Demo @LastName = 'Aliyah',@FirstName ='Ellis';
EXEC [dbo].SP_Register_Demo @LastName = 'Izabelle',@FirstName ='Hanna';
EXEC [dbo].SP_Register_Demo @LastName = 'Tanisha',@FirstName ='Salas';
EXEC [dbo].SP_Register_Demo @LastName = 'Kerrie',@FirstName ='Dodson';
EXEC [dbo].SP_Register_Demo @LastName = 'Arabella',@FirstName ='Reyna';
EXEC [dbo].SP_Register_Demo @LastName = 'Kennedy',@FirstName ='Hutton';
EXEC [dbo].SP_Register_Demo @LastName = 'Kayley',@FirstName ='Humphries';
EXEC [dbo].SP_Register_Demo @LastName = 'Katrina',@FirstName ='Boyer';
EXEC [dbo].SP_Register_Demo @LastName = 'Holly',@FirstName ='Tanner';
EXEC [dbo].SP_Register_Demo @LastName = 'Kelly',@FirstName ='England';

DECLARE @last_id int = ident_current('[dbo].Employee');
UPDATE [dbo].Employee SET Email='admin@test.be' where Employee_Id = @last_id;
INSERT INTO [dbo].[Admin] (Employee_Id) VALUES (@last_id);