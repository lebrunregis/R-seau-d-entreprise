CREATE TABLE [dbo].[Project]
(
	[Project_Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Project_Name] NVARCHAR(50) NOT NULL, 
    [Project_Description] NVARCHAR(MAX) NOT NULL, 
    [Project_StartDate] DATE NOT NULL, 
    [Project_EndDate] DATE NULL
)
