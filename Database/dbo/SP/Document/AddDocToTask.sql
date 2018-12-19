CREATE PROCEDURE [dbo].[AddDocToTask]
	@Document_Id int,
	@Task_Id int
AS
BEGIN
	IF @Document_Id IN (SELECT Document_Id from Document)
	    INSERT INTO DocTask(Document_Id, Task_Id) VALUES (@Document_Id, @Task_Id)
END	    
