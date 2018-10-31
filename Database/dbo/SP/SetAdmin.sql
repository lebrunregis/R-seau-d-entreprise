CREATE PROCEDURE [dbo].[SetAdmin]
	@Employee_Id int
AS
BEGIN
IF @Employee_Id in (SELECT Employee_Id FROM [Admin] WHERE Actif=0)
    UPDATE [Admin] SET Actif=1 WHERE Employee_Id=@Employee_Id;
IF @Employee_Id not in (SELECT Employee_Id FROM [Admin])
    INSERT INTO [Admin] (Employee_Id) VALUES (@Employee_Id);
END
