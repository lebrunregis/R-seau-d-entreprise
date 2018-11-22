CREATE TABLE [dbo].[Event]
(
	[Event_Id] int IDENTITY,
	[CreatorId] int NOT NULL FOREIGN KEY REFERENCES Employee(Employee_Id),
	[DepartmentId] int FOREIGN KEY REFERENCES Department(Department_Id),
	[Name] nvarchar(50) NOT NULL,
	[Description] nvarchar(MAX) NOT NULL,
	[Address] nvarchar(MAX) NOT NULL,
	[StartDate] DATETIME2(0) NOT NULL,
	[EndDate] DATETIME2(0) NOT NULL,
	[CreationDate] datetime2(0) NOT NULL DEFAULT SYSDATETIME(),
	[Open] bit NOT NULL DEFAULT 0,
	[Cancelled] bit NOT NULL DEFAULT 0
	PRIMARY KEY ([Event_Id])

)
