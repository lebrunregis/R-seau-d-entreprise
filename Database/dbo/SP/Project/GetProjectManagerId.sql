CREATE PROCEDURE [dbo].[GetProjectManagerId]
	@ProjectId int
AS
	SELECT dbo.FN_GetProjectManagerId(@ProjectId);

