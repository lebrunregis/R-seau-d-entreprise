CREATE TABLE [dbo].[Task]
(
	[Task_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Task_Name] NVARCHAR(50) NOT NULL, 
    [Tache_Description] NVARCHAR(MAX) NOT NULL, 
    [Tache_StartDate] DATE NOT NULL, 
    [Tache_EndDate] DATE NULL, 
    [Tache_DateFinale] DATE NULL, 
    [Tache_SubtaskOf] INT NULL  
	FOREIGN KEY ([Tache_SubtaskOf]) REFERENCES [Tache]([Tache_Précède])
)
