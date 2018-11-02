CREATE PROCEDURE [dbo].[UpdateEmployee]
	@Employee_Id int,
	@FirstName nvarchar(50),
    @LastName nvarchar(50),
    @Email varchar(360),
    @Passwd nvarchar(50),
    @Address nvarchar(MAX),
    @Phone varchar(50)
AS
	UPDATE Employee SET FirstName=@FirstName, LastName=@LastName, Email=@Email, Passwd=FN_Hash(@Passwd), [Address]=@Address, Phone=@Phone WHERE Employee_Id=@Employee_Id

