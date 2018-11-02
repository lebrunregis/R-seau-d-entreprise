CREATE PROCEDURE [dbo].[Delete_Employee]
	@Employee_Id int,
    @LastName nvarchar(50),
    @FirstName nvarchar(50),
    @Address nvarchar(MAX),
    @Phone varchar(50),
	@RegNat nvarchar(50)
AS
DELETE FROM Employee WHERE Employee_Id=@Employee_Id AND LastName=@LastName AND FirstName=@FirstName AND [Address]=@Address AND RegNat=@RegNat AND
    (Phone=@Phone OR (Phone IS NULL AND @Phone IS NULL));
