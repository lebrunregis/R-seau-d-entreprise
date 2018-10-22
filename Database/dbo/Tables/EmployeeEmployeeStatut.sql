CREATE TABLE [dbo].[EmployeeEmployeeStatut]
(
	[Employee_Id] INT NOT NULL, 
    [EmployeeStatut_Id] INT NOT NULL,
	[EmployeeEmployeeStatut_startdate] DATETIME2 NOT NULL, 
    [EmployeeEmployeeStatut_enddate] DATETIME2 NULL, 
    constraint FK_Employee_Id foreign key (Employee_Id) references Employee(Employee_id),
	constraint FK_EmployeeStatut_Id foreign key (EmployeeStatut_Id) references EmployeeStatut(EmployeeStatut_id),
	constraint PK_EmployeeEmployeeStatut primary key (Employee_Id, EmployeeStatut_Id, EmployeeEmployeeStatut_startdate)
)
