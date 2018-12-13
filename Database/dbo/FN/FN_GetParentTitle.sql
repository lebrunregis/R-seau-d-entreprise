CREATE FUNCTION [dbo].[FN_GetParentTitle]
(
	@id int
)
RETURNS nvarchar(50)
AS
BEGIN
    DECLARE @title nvarchar(50);
	SELECT TOP 1 @title=Message_Title FROM [Message] WHERE Message_Id=@id;
	RETURN @title;
END
