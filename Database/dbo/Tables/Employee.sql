CREATE TABLE [dbo].[Employee]
(
	[Employee_Id] INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    [Employee_LastName] NVARCHAR(50) NOT NULL, 
    [Employee_FirstName] NVARCHAR(50) NOT NULL, 
    [Employee_email] VARCHAR(360) NOT NULL, 
    [Employee_password] VARBINARY(8000) NOT NULL, 
    [Employee_actif] BIT NOT NULL, 
    [Employee_regNat] NVARCHAR(50) NOT NULL, 
    [Employee_hireDate] DATETIME2 NOT NULL, 
    [Employee_avatar] VARBINARY(MAX) NULL, 
    [Employee_coordGPS] VARCHAR(20) NULL, 
    [Employee_address] NVARCHAR(50) NOT NULL, 
    [Employee_phone] VARCHAR(50) NULL,
)
