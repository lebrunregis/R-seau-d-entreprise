CREATE TABLE [dbo].[Event]
(
	[Event_Id] int identity,
  [Employee_Id] int NOT NULL FOREIGN KEY REFERENCES Employee(Employee_Id),
  [Name] nvarchar(50) NOT NULL,
  [Description] nvarchar(MAX) NOT NULL,
  [Address] nvarchar(MAX),
  [StartDate] datetime2(7) NOT NULL,
  [EndDate] datetime2(7),
  [CreationDate] datetime2(7) NOT NULL,
  [FullDay] bit NOT NULL,
  PRIMARY KEY ([Event_Id])

)
