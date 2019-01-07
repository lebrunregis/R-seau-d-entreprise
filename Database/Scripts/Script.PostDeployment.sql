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
DELETE FROM [Event];
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
INSERT INTO [dbo].Department(Name, Creator_Id, Description) VALUES
    ('Accounting', @Admin, 'Part of a company''s administration that is responsible for preparing the financial statements, maintaining the general ledger, paying bills, billing customers, payroll, cost accounting, financial analysis, and more. The head of the accounting department often has the title of controller.'),
    ('Research and Development', @Admin, 'The functions of a research and development department are to engage in new product research and development, existing product updates, quality checks and innovation.'),
    ('Sales', @Admin, 'The function of a sales department is to engage in a variety of activities with the objective to promote the customer purchase of a product or the client engagement of a service.');

EXEC [dbo].CreateProject @name = 'ESN',@description = 'Enterprise Social Network application',@creator = @Admin,@project_manager = 5,@startDate = @now,@endDate = null;
GO

DECLARE @Dep3_Id int = ident_current('[dbo].Department');
DECLARE @Dep2_Id int = @Dep3_Id - 1;
DECLARE @Dep1_Id int = @Dep3_Id - 2;
DECLARE @Admin int = ident_current('[dbo].Employee');
EXEC [dbo].ChangeHeadOfDepartment @DepId = @Dep1_Id, @EmpId = 5, @User = @Admin;
EXEC [dbo].ChangeHeadOfDepartment @DepId = @Dep2_Id, @EmpId = 6, @User = @Admin;
EXEC [dbo].ChangeHeadOfDepartment @DepId = @Dep3_Id, @EmpId = 7, @User = @Admin;
EXEC [dbo].AddEmployeeDepartment @EmployeeId = 1, @DepartmentId = @Dep1_Id, @User = @Admin;
EXEC [dbo].AddEmployeeDepartment @EmployeeId = 2, @DepartmentId = @Dep1_Id, @User = @Admin;
EXEC [dbo].AddEmployeeDepartment @EmployeeId = 3, @DepartmentId = @Dep1_Id, @User = @Admin;
EXEC [dbo].AddEmployeeDepartment @EmployeeId = 4, @DepartmentId = @Dep2_Id, @User = @Admin;
EXEC [dbo].AddEmployeeDepartment @EmployeeId = 5, @DepartmentId = @Dep2_Id, @User = @Admin;
EXEC [dbo].AddEmployeeDepartment @EmployeeId = 6, @DepartmentId = @Dep2_Id, @User = @Admin;
EXEC [dbo].AddEmployeeDepartment @EmployeeId = 7, @DepartmentId = @Dep3_Id, @User = @Admin;
EXEC [dbo].AddEmployeeDepartment @EmployeeId = 8, @DepartmentId = @Dep3_Id, @User = @Admin;
EXEC [dbo].AddEmployeeDepartment @EmployeeId = 9, @DepartmentId = @Dep3_Id, @User = @Admin;

GO

DECLARE @Project_Id int = ident_current('[dbo].Project');
EXEC [dbo].CreateTeam @name = 'Developers',@team_leader = 4,@Project_Id = @Project_Id,@Creator_Id = 5;
EXEC [dbo].CreateTeam @name = 'Testing',@team_leader = 6,@Project_Id = @Project_Id,@Creator_Id = 5;
EXEC [dbo].CreateTeam @name = 'Marketing',@team_leader = 2,@Project_Id = @Project_Id,@Creator_Id = 5;
GO
DECLARE @TeamId_3 int = ident_current('[dbo].Team');
DECLARE @TeamId_2 int = @TeamId_3 - 1;
DECLARE @TeamId_1 int = @TeamId_3 - 2;
EXEC [dbo].AddEmployeeToTeam @Employee_Id = 4 ,@Team_Id = @TeamId_1 ,@User = 5;
EXEC [dbo].AddEmployeeToTeam @Employee_Id = 6 ,@Team_Id = @TeamId_1 ,@User = 5;
EXEC [dbo].AddEmployeeToTeam @Employee_Id = 2 ,@Team_Id = @TeamId_1 ,@User = 5;
EXEC [dbo].AddEmployeeToTeam @Employee_Id = 4 ,@Team_Id = @TeamId_2 ,@User = 5;
EXEC [dbo].AddEmployeeToTeam @Employee_Id = 5 ,@Team_Id = @TeamId_2 ,@User = 5;
EXEC [dbo].AddEmployeeToTeam @Employee_Id = 1 ,@Team_Id = @TeamId_3 ,@User = 5;
EXEC [dbo].AddEmployeeToTeam @Employee_Id = 7 ,@Team_Id = @TeamId_3 ,@User = 5;
EXEC [dbo].AddEmployeeToTeam @Employee_Id = 8 ,@Team_Id = @TeamId_3 ,@User = 5;
EXEC [dbo].AddEmployeeToTeam @Employee_Id = 9 ,@Team_Id = @TeamId_3 ,@User = 5;
GO
DECLARE @Project_Id int = ident_current('[dbo].Project');
DECLARE @now DATETIME2(0) = SYSDATETIME();
DECLARE @TeamId_3 int = ident_current('[dbo].Team');
DECLARE @TeamId_2 int = @TeamId_3 - 1;
DECLARE @TeamId_1 int = @TeamId_3 - 2;
DECLARE @Leader_1 int = [dbo].FN_GetTeamLeaderId(@TeamId_1);
DECLARE @Leader_2 int = [dbo].FN_GetTeamLeaderId(@TeamId_2);
DECLARE @Leader_3 int = [dbo].FN_GetTeamLeaderId(@TeamId_3);

EXEC [dbo].CreateTask @Name = 'Test Messaging',@Description = 'Test all cases for messaging',
                      @ProjectId = @Project_Id,@UserId = @Leader_2,@StartDate = @now,@EndDate = null,@DeadLine = null,@SubtaskOf = null,@TeamId = @TeamId_2;
EXEC [dbo].CreateTask @Name = 'Features',@Description = 'Determine key features for ESN application',
                      @ProjectId = @Project_Id,@UserId = @Leader_3,@StartDate = @now,@EndDate = null,@DeadLine = null,@SubtaskOf = null,@TeamId = @TeamId_3;
EXEC [dbo].CreateTask @Name = 'Notifications',@Description = 'Add notifications for all events',
                      @ProjectId = @Project_Id,@UserId = @Leader_1,@StartDate = @now,@EndDate = null,@DeadLine = null,@SubtaskOf = null,@TeamId = @TeamId_1;
EXEC [dbo].CreateTask @Name = 'Avatars',@Description = 'Add possibility to users to create their own avatar picture',
                      @ProjectId = @Project_Id,@UserId = @Leader_1,@StartDate = @now,@EndDate = null,@DeadLine = null,@SubtaskOf = null,@TeamId = @TeamId_1;
GO

DECLARE @Project_Id int = ident_current('[dbo].Project');
DECLARE @now DATETIME2(0) = SYSDATETIME();
DECLARE @TeamId_1 int = ident_current('[dbo].Team') - 2;
DECLARE @Leader_1 int = [dbo].FN_GetTeamLeaderId(@TeamId_1);
Declare @Master_Task int = ident_current('[dbo].Task')
EXEC [dbo].CreateTask @Name = 'Database',@Description = 'Create a structure for storing images',
                      @ProjectId = @Project_Id,@UserId = @Leader_1,@StartDate = @now,@EndDate = null,@DeadLine = null,@SubtaskOf = @Master_Task,@TeamId = @TeamId_1;
EXEC [dbo].CreateTask @Name = 'Front-End',@Description = 'Create or choose a vidget for avatar image',
                      @ProjectId = @Project_Id,@UserId = @Leader_1,@StartDate = @now,@EndDate = null,@DeadLine = null,@SubtaskOf = @Master_Task,@TeamId = @TeamId_1;
GO

DECLARE @now DATETIME2(0) = SYSDATETIME();
DECLARE @Admin int = ident_current('[dbo].Employee');
EXEC [dbo].CreateProject @name = 'Mobile Messenger',@description = 'Our own messaging app and platform.',@creator = @Admin,@project_manager = 2,@startDate = @now,@endDate = null;
DECLARE @Project_Id int = ident_current('[dbo].Project');
EXEC [dbo].CreateTeam @name = 'Apple Development Team',@team_leader = 5,@Project_Id = @Project_Id,@Creator_Id = 2;
EXEC [dbo].CreateTeam @name = 'Android Development Team',@team_leader = 6,@Project_Id = @Project_Id,@Creator_Id = 2;
GO
DECLARE @TeamId_2 int = ident_current('[dbo].Team');
DECLARE @TeamId_1 int = @TeamId_2 - 1;
EXEC [dbo].AddEmployeeToTeam @Employee_Id = 3 ,@Team_Id = @TeamId_1 ,@User = 2;
EXEC [dbo].AddEmployeeToTeam @Employee_Id = 4 ,@Team_Id = @TeamId_1 ,@User = 2;
EXEC [dbo].AddEmployeeToTeam @Employee_Id = 5 ,@Team_Id = @TeamId_1 ,@User = 2;
EXEC [dbo].AddEmployeeToTeam @Employee_Id = 1 ,@Team_Id = @TeamId_1 ,@User = 2;
EXEC [dbo].AddEmployeeToTeam @Employee_Id = 6 ,@Team_Id = @TeamId_2 ,@User = 2;
EXEC [dbo].AddEmployeeToTeam @Employee_Id = 7 ,@Team_Id = @TeamId_2 ,@User = 2;
EXEC [dbo].AddEmployeeToTeam @Employee_Id = 8 ,@Team_Id = @TeamId_2 ,@User = 2;
GO

DECLARE @Admin int = ident_current('[dbo].Employee');
DECLARE @Department int = ident_current('[dbo].Department');
EXEC [dbo].CreateEvent @Name = 'Lunch for all', @Description = 'Opportunity for see all our employees', @Address = 'Avenue Jean Mermoz 18, 6041 Charleroi',
                       @StartDate = '2019-02-01T00:00:00', @EndDate = '2019-02-01T23:59:00', @DepartmentId = NULL, @AdminId = @Admin, @Open = 1;

EXEC [dbo].CreateEvent @Name = 'Presentation for Marketing', @Description = 'How to do presentations the right way', @Address = 'Avenue Jean Mermoz 18, 6041 Charleroi',
                       @StartDate = '2019-01-20T00:00:00', @EndDate = '2019-01-20T23:59:00', @DepartmentId = @Department, @AdminId = @Admin, @Open = 0;
GO

DECLARE @Admin int = ident_current('[dbo].Employee');
DECLARE @Event_2 int = ident_current('[dbo].Event');
DECLARE @Event_1 int = @Event_2 - 1;
EXEC [dbo].RegisterEmployeeToEvent @EventId = @Event_1, @EmployeeId = 5;

EXEC [dbo].RegisterEmployeeToEvent @EventId = @Event_2, @EmployeeId = 7;
EXEC [dbo].RegisterEmployeeToEvent @EventId = @Event_2, @EmployeeId = 8;
EXEC [dbo].RegisterEmployeeToEvent @EventId = @Event_2, @EmployeeId = 9;


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
