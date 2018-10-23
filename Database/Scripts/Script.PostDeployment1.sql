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
DECLARE @AdminId INT;
exec SP_Register @LastName = 'Régis',@FirstName ='Lebrun',@Email ='mon.email1@fa.com',@Password  = 'admin',@RegNat  ='',@Address ='',@Phone = '';
exec SP_Register @LastName = 'Samuel',@FirstName ='Legrain',@Email ='mon.email2@fa.com',@Password  = 'admin',@RegNat  ='',@Address ='',@Phone = '';
exec SP_Register @LastName = 'Admin',@FirstName ='Admin',@Email ='mon.email3@fa.com',@Password  = 'admin',@RegNat  ='',@Address ='',@Phone = '';
SET @AdminId = SCOPE_IDENTITY() 
exec SP_Register @LastName = 'Patrick',@FirstName ='Bruel',@Email ='mon.email4@fa.com',@Password  = 'admin',@RegNat  ='',@Address ='',@Phone = '';
exec SP_Register @LastName = 'Johnny',@FirstName ='Depp',@Email ='mon.email5@fa.com',@Password  = 'admin',@RegNat  ='',@Address ='',@Phone = '';
exec SP_Register @LastName = 'Johnny',@FirstName ='Bravo',@Email ='mon.email6@fa.com',@Password  = 'admin',@RegNat  ='',@Address ='',@Phone = '';
GO
INSERT INTO Admin (Employee_Id) VALUES ( @AdminId )