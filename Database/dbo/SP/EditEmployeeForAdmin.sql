CREATE PROCEDURE [dbo].[EditEmployeeForAdmin]
    @Employee_Id int,
	@LastName nvarchar(50),
	@FirstName nvarchar(50),
	@Email nvarchar(360),
	@Password nvarchar(50),
	@RegNat nvarchar(50),
	@Address nvarchar(MAX),
	@Phone varchar(50),
	@IsAdmin bit
AS
BEGIN
	UPDATE Employee SET LastName=[dbo].FN_StrClean(@LastName),
	                    FirstName=[dbo].FN_StrClean(@FirstName),
						[Address]=[dbo].FN_StrClean(@Address),
						Phone=NULLIF([dbo].FN_StrClean(@Phone),''),
						Email=[dbo].FN_StrClean(@Email),
						RegNat=[dbo].FN_StrClean(@RegNat)
        WHERE Employee_Id=@Employee_Id
	IF (@Password IS NOT NULL)
	BEGIN
	    DECLARE @Hash varbinary(32)
	    SET @Hash =  [dbo].FN_Hash( @Password)
		UPDATE Employee SET Passwd=@Hash WHERE Employee_Id=@Employee_Id
	END
	IF (@IsAdmin=1)
	    EXEC [dbo].SetAdmin @Employee_Id
	ELSE
	    DELETE FROM [Admin] WHERE Employee_Id=@Employee_Id
END
