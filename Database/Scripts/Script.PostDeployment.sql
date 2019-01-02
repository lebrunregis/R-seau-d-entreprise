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
DISABLE TRIGGER [OnDeleteAdmin] ON [Admin];   
GO
DISABLE TRIGGER [OnDeleteDepartment] ON Department;  
GO
DISABLE TRIGGER [OnDeleteEmployee] ON Employee;  
GO
DISABLE TRIGGER [OnDeleteEmployeeDepartment] ON EmployeeDepartment;
GO
DISABLE TRIGGER [OnDeleteEmployeeStatusHistory] ON EmployeeStatusHistory;  
GO
DISABLE TRIGGER [OnDeleteEmployeeTeam] ON [EmployeeTeam];  
GO
DISABLE TRIGGER [OnDeleteEvent] ON [Event];  
GO
DISABLE TRIGGER [OnDeleteProject] ON Project;  
GO
DISABLE TRIGGER [OnDeleteTask] ON Task;  
GO
DISABLE TRIGGER [OnDeleteTeam] ON Team;  
GO
DISABLE TRIGGER [OnDeleteDocument] ON Document;  
GO

DELETE FROM [DocDepartment];
GO
DELETE FROM [DocEvent];
GO
DELETE FROM [DocMessage];
GO
DELETE FROM [DocProject];
GO
DELETE FROM [DocTask];
GO
DELETE FROM [DocTeam];
GO
DELETE FROM [MessageEmployee];
GO
DELETE FROM [MessageProject];
GO
DELETE FROM [MessageTeam];
GO
DELETE FROM [MessageTask];
GO
DELETE FROM [Message];
GO
DELETE FROM [EmployeeEvent]
GO
DELETE FROM [EmployeeHeadOfDepartment]
GO
DELETE FROM [EmployeeDepartment]
GO
DELETE FROM [Department]
GO
DELETE FROM [EmployeeTeamLeader];
GO
DELETE FROM [EmployeeTeam];
GO
DELETE FROM [Event];
GO
DELETE FROM [ProjectManager];
GO
DELETE FROM [TaskStatusHistory];
GO
DELETE FROM [TaskStatus];
GO
DELETE FROM [Task];
GO
DELETE FROM [Team];
GO
DELETE FROM [Project];
GO
DELETE FROM [Admin];
GO
DELETE FROM [EmployeeStatusHistory];
GO
DELETE FROM [Document];
GO
DELETE FROM [Employee];
GO
DELETE FROM [EmployeeStatus];
GO


DBCC CHECKIDENT ('[EmployeeDepartment]', RESEED, 0);
GO
DBCC CHECKIDENT ('[EmployeeStatus]', RESEED, 0);
GO
DBCC CHECKIDENT ('[Employee]', RESEED, 0);
GO
DBCC CHECKIDENT ('[Project]', RESEED, 0);
GO
DBCC CHECKIDENT ('[EmployeeStatusHistory]', RESEED, 0);
GO
DBCC CHECKIDENT ('[Task]', RESEED, 0);
GO
DBCC CHECKIDENT ('[TaskStatus]', RESEED, 0);
GO
DBCC CHECKIDENT ('[Message]', RESEED, 0);
GO
DBCC CHECKIDENT ('[Team]', RESEED, 0);
GO
DBCC CHECKIDENT ('[Department]', RESEED, 0);
GO
DBCC CHECKIDENT ('[Event]', RESEED, 0);
GO

SET IDENTITY_INSERT [TaskStatus] ON 
INSERT INTO [TaskStatus] (TaskStatus_Id,Name) VALUES (0,'Not started');
INSERT INTO [TaskStatus] (TaskStatus_Id,Name) VALUES (1,'Being worked on');
INSERT INTO [TaskStatus] (TaskStatus_Id,Name) VALUES (2,'On hold');
INSERT INTO [TaskStatus] (TaskStatus_Id,Name) VALUES (3,'Done');
INSERT INTO [TaskStatus] (TaskStatus_Id,Name) VALUES (4,'Cancelled');
INSERT INTO [TaskStatus] (TaskStatus_Id,Name) VALUES (5,'Transferred to other team');
GO
SET IDENTITY_INSERT [TaskStatus] OFF

SET IDENTITY_INSERT [EmployeeStatus] ON
INSERT INTO [EmployeeStatus] (EmployeeStatus_Id,Name) VALUES (0,'Joined');
INSERT INTO [EmployeeStatus] (EmployeeStatus_Id,Name) VALUES (1,'Left');
INSERT INTO [EmployeeStatus] (EmployeeStatus_Id,Name) VALUES (2,'Sick');
INSERT INTO [EmployeeStatus] (EmployeeStatus_Id,Name) VALUES (3,'Dead');
INSERT INTO [EmployeeStatus] (EmployeeStatus_Id,Name) VALUES (4,'Admin');
GO
SET IDENTITY_INSERT [EmployeeStatus] OFF

EXEC [dbo].Register_Demo @LastName = 'Aliyah',@FirstName ='Ellis';
EXEC [dbo].Register_Demo @LastName = 'Izabelle',@FirstName ='Hanna';
EXEC [dbo].Register_Demo @LastName = 'Tanisha',@FirstName ='Salas';
EXEC [dbo].Register_Demo @LastName = 'Kerrie',@FirstName ='Dodson';
EXEC [dbo].Register_Demo @LastName = 'Arabella',@FirstName ='Reyna';
EXEC [dbo].Register_Demo @LastName = 'Kennedy',@FirstName ='Hutton';
EXEC [dbo].Register_Demo @LastName = 'Kayley',@FirstName ='Humphries';
EXEC [dbo].Register_Demo @LastName = 'Katrina',@FirstName ='Boyer';
EXEC [dbo].Register_Demo @LastName = 'Holly',@FirstName ='Tanner';
EXEC [dbo].Register_Demo @LastName = 'Kelly',@FirstName ='England';
GO

DECLARE @employee_id int = ident_current('[dbo].Employee');
Update [dbo].Employee SET Email='admin@test.be' where Employee_Id = @employee_id;
INSERT INTO[dbo].Admin (Employee_Id) VALUES (@employee_id);
GO
DECLARE @now DATETIME2(0) = SYSDATETIME();
DECLARE @Admin int = ident_current('[dbo].Employee');
EXEC [dbo].CreateProject @name = 'Test Project',@description = 'Test project description',@creator = @Admin,@project_manager = 5,@startDate = @now,@endDate = null;
GO
DECLARE @Project_Id int = ident_current('[dbo].Project');
EXEC [dbo].CreateTeam @name = 'Test team',@team_leader = 3,@Project_Id = @Project_Id,@Creator_Id = 5;
GO
DECLARE @TeamId int = ident_current('[dbo].Team');
EXEC [dbo].AddEmployeeToTeam @Employee_Id = 7 ,@Team_Id = @TeamId ,@User = 5;
EXEC [dbo].AddEmployeeToTeam @Employee_Id = 6 ,@Team_Id = @TeamId ,@User = 5;
EXEC [dbo].AddEmployeeToTeam @Employee_Id = 2 ,@Team_Id = @TeamId ,@User = 5;
GO
DECLARE @Project_Id int = ident_current('[dbo].Project');
DECLARE @now DATETIME2(0) = SYSDATETIME();
DECLARE @Team_Id int = ident_current('[dbo].Team');
EXEC [dbo].CreateTask @Name = 'Test task',@Description = 'Test task description',@ProjectId = @Project_Id,@UserId = 3,@StartDate = @now,@EndDate = null,@DeadLine = null,@SubtaskOf = null,@TeamId = @Team_Id;
GO
ENABLE TRIGGER [OnDeleteAdmin] ON [Admin];   
GO
ENABLE TRIGGER [OnDeleteDepartment] ON Department;  
GO
ENABLE TRIGGER [OnDeleteEmployee] ON Employee;  
GO
ENABLE TRIGGER [OnDeleteEmployeeDepartment] ON EmployeeDepartment;
GO
ENABLE TRIGGER [OnDeleteEmployeeStatusHistory] ON EmployeeStatusHistory;  
GO
ENABLE TRIGGER [OnDeleteEmployeeTeam] ON [EmployeeTeam];  
GO
ENABLE TRIGGER [OnDeleteEvent] ON [Event];  
GO
ENABLE TRIGGER [OnDeleteProject] ON Project;  
GO
ENABLE TRIGGER [OnDeleteTask] ON Task;  
GO
ENABLE TRIGGER [OnDeleteTeam] ON Team;  
GO
ENABLE TRIGGER [OnDeleteDocument] ON Document;  
GO
/*DISABLE TRIGGER [OnDeleteMessage] ON Message; --Doesn't exist yet 
GO*/
