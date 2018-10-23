CREATE TABLE [dbo].[Employee]
(
  [Employee_Id] int IDENTITY,
  [LastName] nvarchar(50) NOT NULL,
  [FirstName] nvarchar(50) NOT NULL,
  [Email] varchar(360) NOT NULL UNIQUE,
  [Passwd] varbinary(32) NOT NULL,
  [Active] bit NOT NULL default 1,
  [RegNat] varchar(50) NOT NULL UNIQUE,
  [Avatar] varbinary(MAX) NULL,
  [CoordGPS] varchar(50) NULL,
  [Address] nvarchar(MAX) NOT NULL,
  [Phone] varchar(50) NULL,
  PRIMARY KEY ([Employee_Id])

);
GO;
CREATE INDEX [email_i] ON  [Employee] ([Email]);
GO;
CREATE INDEX [RegNat_i] ON  [Employee] ([RegNat]);


