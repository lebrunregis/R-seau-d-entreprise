CREATE PROCEDURE [dbo].[SP_AddEmployeeHistory]
	@employee int,
	@status varchar(50)
AS
	DECLARE @id int
	SELECT @id = EmployeeStatus_Id FROM EmployeeStatus WHERE Name = @status;
	IF @id IS NULL BEGIN
		INSERT INTO EmployeeStatus (Name) VALUES (@status);
		@id = SCOPE_IDENTITY();
		END
RETURN @id
