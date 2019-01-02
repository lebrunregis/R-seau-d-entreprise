CREATE PROCEDURE [dbo].[AddDocToMessage]
	@Document_Id int,
	@Message_Id int
AS
BEGIN
	IF @Document_Id IN (SELECT Document_Id from Document)
	    INSERT INTO DocMessage(Document_Id, Message_Id) VALUES (@Document_Id, @Message_Id)
END	    
