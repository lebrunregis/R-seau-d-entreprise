CREATE PROCEDURE [dbo].[AddDocToEvent]
	@Document_Id int,
	@Event_Id int
AS
BEGIN
	IF @Document_Id IN (SELECT Document_Id from Document)
	    INSERT INTO DocEvent(Document_Id, Event_Id) VALUES (@Document_Id, @Event_Id)
END	    
