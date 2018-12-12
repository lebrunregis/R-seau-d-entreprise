CREATE PROCEDURE [dbo].[CreateMessage]
	@title nvarchar(50),
	@message nvarchar(max),
	@author int,
	@parent int,
	@receiver_employee int,
	@receiver_project int,
	@receiver_task int,
	@receiver_team int
AS
BEGIN
DECLARE @message_id int

DECLARE @arguments_verifier table(receiver int)
INSERT INTO @arguments_verifier(receiver) VALUES (@receiver_employee), (@receiver_project), (@receiver_task), (@receiver_team);
DECLARE @CountReceivers int;
SELECT @CountReceivers=count(receiver) FROM @arguments_verifier;

IF EXISTS(SELECT * FROM [dbo].[Employee] WHERE Employee_Id = @author AND Active = 1)
AND @CountReceivers = 1
AND (@parent IS NULL
    OR EXISTS (SELECT * FROM MessageProject WHERE Message_Id=@parent AND Project_Id=@receiver_project)
    OR EXISTS (SELECT * FROM MessageTask WHERE Message_Id=@parent AND Task_Id=@receiver_task)
    OR EXISTS (SELECT * FROM MessageTeam WHERE Message_Id=@parent AND Team_Id=@receiver_team)
	OR EXISTS (SELECT * FROM MessageEmployee me JOIN [Message] m ON me.Message_Id=m.Message_Id
	           WHERE me.Message_Id=@parent
			   AND (  (me.Employee_Id=@receiver_employee AND m.Message_Author=@author)
			        OR(me.Employee_Id=@author AND m.Message_Author=@receiver_employee))
			  )
	)
   BEGIN TRAN T1
       INSERT INTO [Message] (Message_Title, Message_Message, Message_Author, Message_Parent) VALUES (@title, @message, @author, @parent);
	   SET @message_id = convert(int, IDENT_CURRENT('Message'));

	   IF @receiver_employee IS NOT NULL
	       INSERT INTO MessageEmployee(Message_Id, Employee_Id) VALUES(@message_id, @receiver_employee);
	   IF @receiver_project IS NOT NULL
	       INSERT INTO MessageProject(Message_Id, Project_Id) VALUES(@message_id, @receiver_project);
	   IF @receiver_team IS NOT NULL
	       INSERT INTO MessageTeam(Message_Id, Team_Id) VALUES(@message_id, @receiver_team);
	   IF @receiver_task IS NOT NULL
	       INSERT INTO MessageTask(Message_Id, Task_Id) VALUES(@message_id, @receiver_task);

	   SELECT @message_id
   COMMIT TRAN T1
END