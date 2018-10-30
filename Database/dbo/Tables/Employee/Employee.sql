CREATE TABLE [dbo].[Employee]
(
  [Employee_Id] int IDENTITY,
  [LastName] nvarchar(50) NOT NULL,
  [FirstName] nvarchar(50) NOT NULL,
  [Email] NVARCHAR(360) NOT NULL,
  [Passwd] varbinary(32) NOT NULL,
  [Active] bit NOT NULL default 1,
  [RegNat] nvarchar(50) NOT NULL,
  [Avatar] varbinary(MAX) NULL,
  [CoordGPS] varchar(50) NULL,
  [Address] nvarchar(MAX) NOT NULL,
  [Phone] VARCHAR(50) NULL,
  PRIMARY KEY ([Employee_Id]),
  CONSTRAINT UC_Email UNIQUE ([Email]),
  CONSTRAINT UC_RegNat UNIQUE ([RegNat])

);
GO;
CREATE INDEX [email_i] ON  [Employee] ([Email]);
GO;
CREATE INDEX [RegNat_i] ON  [Employee] ([RegNat]);


