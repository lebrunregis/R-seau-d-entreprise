﻿CREATE PROCEDURE [dbo].[SetTaskStatus]
	@TaskId int ,
	@StatusId int
AS
	INSERT INTO TaskStatusHistory(Task_Id , TaskStatus_Id) VALUES (@TaskId,@StatusId)
RETURN 0