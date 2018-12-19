CREATE TABLE [dbo].[EmployeeTask]
(
	[Employee_Id] INT NOT NULL, 
    [Task_Id] INT NOT NULL , 
    [Date] DATETIME2(0) NOT NULL
	PRIMARY KEY ([Employee_Id],[Task_Id])
)
