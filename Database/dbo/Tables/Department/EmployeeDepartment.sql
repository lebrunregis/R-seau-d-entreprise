CREATE TABLE [dbo].[EmployeeDepartment]
(
	[Employee_Id] INT NOT NULL,
	[Department_Id] INT NOT NULL,
	[Date] DateTime2(0) NOT NULL DEFAULT GetDate(),
	[Active] BIT NOT NULL DEFAULT 1, 
    PRIMARY KEY ([Employee_Id],[Department_Id]),
	CONSTRAINT FK_EmployeeDepartment FOREIGN KEY (Employee_Id) REFERENCES Employee(Employee_Id),
	CONSTRAINT FK_DepartmentEmployee FOREIGN KEY(Department_Id) REFERENCES Department(Department_Id)
)
