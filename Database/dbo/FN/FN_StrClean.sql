CREATE FUNCTION [dbo].[FN_StrClean](@str NVARCHAR(MAX))
RETURNS varbinary(MAX) 
AS
BEGIN
RETURN (rtrim(ltrim(@str)));
END