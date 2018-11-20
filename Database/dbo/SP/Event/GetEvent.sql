CREATE PROCEDURE [dbo].[GetEvent]
	@EventId int
AS
	SELECT Event_Id,CreatorId,[Name],[Description],[Address],StartDate,EndDate,CreationDate,[Open],Cancelled FROM Event WHERE Event_Id = @EventId
RETURN 0
