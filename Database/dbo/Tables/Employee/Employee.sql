CREATE TABLE [dbo].[Employee]
(
	[Employee_id] int identity,
  [LastName] nvarchar(50) NOT NULL,
  [FirstName] nvarchar(50) NOT NULL,
  [email] varchar(360) NOT NULL unique,
  [passwd] varbinary NOT NULL,
  [actif] bit NOT NULL,
  [RegNat] varchar(50) NOT NULL unique,
  [avatar] varbinary(MAX) NULL,
  [CoordGPS] varchar(50) NULL,
  [address] nvarchar(MAX) NOT NULL,
  [phone] varchar(50) NULL,
  PRIMARY KEY ([Employee_id])

);
GO;
CREATE INDEX [email_i] ON  [Employee] ([email]);
GO;
CREATE INDEX [RegNat_i] ON  [Employee] ([RegNat]);


