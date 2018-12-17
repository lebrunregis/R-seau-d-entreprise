CREATE FUNCTION [dbo].[FN_Hash]
(
	@pwd NVARCHAR(50)
)
RETURNS varbinary(32)
AS 
BEGIN
RETURN (HASHBYTES('SHA2_256' , CONCAT('luf§gèy(g!èouhgfèo(yiè123456hg875gyTR§5TT§§5555§f', @pwd, 'ITFvgt6(è§(HGç678(hGIYF§t976Gç§yoOGo!è§((96TygUHG7§!è§7UYOYGO')))
END
