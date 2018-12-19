CREATE PROCEDURE [dbo].[AddDocToDepartment]
	@Document_Id int,
	@Department_Id int
AS
BEGIN
	IF @Document_Id IN (SELECT Document_Id from Document)
	    INSERT INTO DocDepartment(Document_Id, Department_Id) VALUES (@Document_Id, @Department_Id)
END	    
