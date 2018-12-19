using Model.Client.Data;
using Model.Client.Mapper;
using GS = Model.Global.Service;
using GD = Model.Global.Data;
using System.Collections.Generic;

namespace Model.Client.Service
{
    public static class DocumentService
    {
        public static int? Create(Document doc)
        {
            return GS.DocumentService.Create(Mappers.ToGlobal(doc));
        }

        public static Document Get(int Id)
        {
            return Mappers.ToClient(GS.DocumentService.Get(Id));
        }

        public static bool AddToDepartment(int DocumentId, int DepartmentId)
        {
            return GS.DocumentService.AddToDepartment(DocumentId, DepartmentId);
        }
        public static bool AddToEvent(int DocumentId, int EventId)
        {
            return GS.DocumentService.AddToDepartment(DocumentId, EventId);
        }
        public static bool AddToMessage(int DocumentId, int MessageId)
        {
            return GS.DocumentService.AddToDepartment(DocumentId, MessageId);
        }
        public static bool AddToProject(int DocumentId, int ProjectId)
        {
            return GS.DocumentService.AddToDepartment(DocumentId, ProjectId);
        }
        public static bool AddToTask(int DocumentId, int TaskId)
        {
            return GS.DocumentService.AddToDepartment(DocumentId, TaskId);
        }
        public static bool AddToTeam(int DocumentId, int TeamId)
        {
            return GS.DocumentService.AddToDepartment(DocumentId, TeamId);
        }
    }
}
