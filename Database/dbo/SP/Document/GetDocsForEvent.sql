CREATE PROCEDURE [dbo].[GetDocsForEvent]
	@Event_Id int
AS
BEGIN
	SELECT Document_Id FROM DocEvent WHERE Event_Id = @Event_Id
END	    
