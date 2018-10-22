CREATE TABLE [dbo].[Event]
(
	[Event_id] int identity,
  [Employee_id] int NOT NULL FOREIGN KEY REFERENCES Employee(Employee_id),
  [Name] nvarchar(50) NOT NULL,
  [Description] nvarchar(MAX) NOT NULL,
  [Address] nvarchar(MAX),
  [StartDate] datetime2(7) NOT NULL,
  [EndDate] datetime2(7),
  [CreationDate] datetime2(7) NOT NULL,
  [FullDay] bit NOT NULL,
  PRIMARY KEY ([Event_id])

)
