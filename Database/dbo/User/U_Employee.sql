CREATE LOGIN [Employee]
    WITH PASSWORD = '@[sJG3}fpY6w3*#}@Q{A^Bp\Ds9t=WV,xy4JgmX}sDwj9e5B_$';  
GO  

  CREATE USER [Employee] FOR LOGIN [Employee];  
GO  

GRANT CONNECT TO [Employee];
GO
GRANT DELETE, INSERT, SELECT, UPDATE ON ALL TO [Employee];
GO
GRANT EXECUTE ON OBJECT::[dbo].[SP_Register] TO [Employee];
GO