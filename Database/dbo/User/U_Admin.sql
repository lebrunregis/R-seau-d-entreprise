CREATE LOGIN [Admin]
    WITH PASSWORD = '340$Uuxwp7Mcxo7Khy';  
GO  

  CREATE USER [Admin] FOR LOGIN [Admin];  
GO  

GRANT CONNECT TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[AddEmployeeDepartment] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[ChangeHeadOfDepartment] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[CreateDepartment] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[DeleteDepartment] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[EditDepartment] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetAllActiveDepartments] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetAllDepartments] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetDepartmentById] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetEmployeeActiveDepartments] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetEmployeeDepartments] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetEmployeeDepartmentsHistory] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetEmployeesForDepartment] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetHeadOfDepartmentActiveDepartments] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetHeadOfDepartmentId] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[RemoveEmployeeDepartment] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[AddDocToDepartment] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[AddDocToEvent] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[AddDocToMessage] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[AddDocToProject] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[AddDocToTask] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[AddDocToTeam] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[DeleteDocument] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[DownloadFile] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetDocForDescription] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetDocsForDepartment] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetDocsForEvent] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetDocsForMessage] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetDocsForProject] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetDocsForTask] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetDocsForTeam] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[UploadFile] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[AddEmployeeHistory] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[ConfirmAdmin] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[ConfirmLogin] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[Delete_Employee] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[EditEmployeeForAdmin] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetAllActiveEmployees] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetAllEmployeesForAdmin] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetEmployee] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetEmployeeForAdmin] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetEmployeeProjectManagerHistory] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetEmployeeStatusHistory] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetEmployeeStatusList] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[Register] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[SetAdmin] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[SetEmployeeStatus] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[Update_Email] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[Update_Employee] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[Update_Password] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[CreateEvent] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[DeleteEvent] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetAllActiveEvents] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetAllEvents] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetAllEventsForUser] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetEmployeeSubscriptionStatus] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetEvent] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetSubscriptionStatus] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[RegisterEmployeeToEvent] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[UpdateEvent] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[CreateMessage] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetMessage] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetMyDiscussionWithEmployee] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetMyDiscussionWithEmployeeWithoutSome] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetProjectForMessage] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetProjectMessages] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetProjectMessagesWithoutSome] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetResponsesToEmployee] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetResponsesToEmployeeWithoutSome] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetTaskForMessage] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetTaskMessages] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetTaskMessagesWithoutSome] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetTeamForMessage] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetTeamMessages] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetTeamMessagesWithoutSome] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[IsMessageRepliedByEmployee] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[CreateProject] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[DeleteProject] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetActiveProjectsForManager] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetAllActiveProjects] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetAllAssociedProjects] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetAllProjects] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetAllTeamsForProject] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetProject] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetProjectManagerId] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[UpdateProject] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[CreateTask] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[DeleteTask] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetEmployeesForTask] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetSubtasks] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetTask] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetTasksForProject] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetTasksForTeam] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetTasksForUser] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetTaskStatusHistory] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetTaskStatusList] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[SetEmployeeToTask] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[SetTaskStatus] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[UpdateTask] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[AddEmployeeToTeam] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[CreateTeam] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[DeleteTeam] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[EditTeam] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetActiveTeamsForTeamLeader] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetActiveTeamsInCommon] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetAllActiveTeams] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetAllActiveTeamsForEmployee] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetAllEmployeesForTeam] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetAllTeams] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetTeam] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[GetTeamLeaderId] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[IsInTeam] TO [Admin];
GO
GRANT EXECUTE ON OBJECT::[dbo].[RemoveEmployeeFromTeam] TO [Admin];
GO