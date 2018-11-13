CREATE TABLE [dbo].[EmployeeDepartment]
(
	[Id] INT NOT NULL UNIQUE IDENTITY , 
	[Employee_Id] INT NOT NULL,
	[Department_Id] INT NOT NULL,
	[StartDate] DateTime2(0) NOT NULL DEFAULT GetDate(),
	[EndDate] DATETIME2(0) NOT NULL DEFAULT NULL, 
    
    PRIMARY KEY ([Employee_Id],[Department_Id]),
	CONSTRAINT FK_EmployeeDepartment FOREIGN KEY (Employee_Id) REFERENCES Employee(Employee_Id),
	CONSTRAINT FK_DepartmentEmployee FOREIGN KEY(Department_Id) REFERENCES Department(Department_Id)
)
