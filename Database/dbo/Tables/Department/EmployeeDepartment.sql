CREATE TABLE [dbo].[EmployeeDepartment]
(
	[Id] INT NOT NULL UNIQUE IDENTITY , 
	[Employee_Id] INT NOT NULL,
	[Department_Id] INT NOT NULL,
	[StartDate] DateTime2(0) NOT NULL DEFAULT SYSDATETIME(),
	[EndDate] DATETIME2(0) DEFAULT NULL, 
    
	PRIMARY KEY (Id),
    CONSTRAINT UNICITY UNIQUE ([Employee_Id],[Department_Id],StartDate),
	CONSTRAINT FK_EmployeeDepartment FOREIGN KEY (Employee_Id) REFERENCES Employee(Employee_Id),
	CONSTRAINT FK_DepartmentEmployee FOREIGN KEY(Department_Id) REFERENCES Department(Department_Id)
)
