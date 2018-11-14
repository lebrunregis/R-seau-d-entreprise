CREATE TABLE [dbo].[EmployeeStatusHistory]
(
  [EmployeeStatusHistory_Id] int IDENTITY(1,1),
  [Employee_Id] int NOT NULL ,
  [EmployeeStatus_Id] int NOT NULL ,
  [StartDate] datetime2(0) NOT NULL DEFAULT GetDate(),
  [EndDate] datetime2(0),
  PRIMARY KEY ([EmployeeStatusHistory_Id]),
  CONSTRAINT FK_HistoryEmployeeId FOREIGN KEY (Employee_Id) REFERENCES Employee(Employee_Id),
  CONSTRAINT FK_HistoryEmployeeStatusId FOREIGN KEY(EmployeeStatus_Id) REFERENCES EmployeeStatus(EmployeeStatus_Id)
)
GO
