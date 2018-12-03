using Model.Client.Data;
using Model.Client.Mapper;
using GS = Model.Global.Service;
using GD = Model.Global.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client.Service
{
    public static class MessageService
    {
        public static int? Create(Message message, int? employee, int? project, int? task, int? team)
        {
            return GS.MessageService.Create(Mappers.ToGlobal(message), employee, project, task, team);
        }

        public static Message Get(int id)
        {
            return Mappers.ToClient(GS.MessageService.Get(id));
        }

        public static IEnumerable<Message> GetProjectMessages(int ProjectId)
        {
            return GS.MessageService.GetProjectMessages(ProjectId).Select(message => Mappers.ToClient(message));
        }

        public static IEnumerable<Message> GetTaskMessages(int TaskId)
        {
            return GS.MessageService.GetTaskMessages(TaskId).Select(message => Mappers.ToClient(message));
        }

        public static IEnumerable<Message> GetTeamMessages(int TeamId)
        {
            return GS.MessageService.GetTeamMessages(TeamId).Select(message => Mappers.ToClient(message));
        }

        public static IEnumerable<Message> GetMyDiscussionWithEmployee(int MyId, int EmployeeId)
        {
            return GS.MessageService.GetMyDiscussionWithEmployee(MyId, EmployeeId).Select(message => Mappers.ToClient(message));
        }

        public static IEnumerable<Message> GetProjectMessagesWithoutSome(int ProjectId, int max_id)
        {
            return GS.MessageService.GetProjectMessagesWithoutSome(ProjectId, max_id).Select(message => Mappers.ToClient(message));
        }

        public static IEnumerable<Message> GetTaskMessagesWithoutSome(int TaskId, int max_id)
        {
            return GS.MessageService.GetTaskMessagesWithoutSome(TaskId, max_id).Select(message => Mappers.ToClient(message));
        }

        public static IEnumerable<Message> GetTeamMessagesWithoutSome(int TeamId, int max_id)
        {
            return GS.MessageService.GetTeamMessagesWithoutSome(TeamId, max_id).Select(message => Mappers.ToClient(message));
        }

        public static IEnumerable<Message> GetMyDiscussionWithEmployeeWithoutSome(int MyId, int EmployeeId, int max_id)
        {
            return GS.MessageService.GetMyDiscussionWithEmployeeWithoutSome(MyId, EmployeeId, max_id).Select(message => Mappers.ToClient(message));
        }
        public static IEnumerable<Message> GetResponsesToEmployee(int EmployeeId)
        {
            return GS.MessageService.GetResponsesToEmployee(EmployeeId).Select(message => Mappers.ToClient(message));
        }

        public static Project GetProjectForMessage(int MessageId)
        {
            return Mappers.ToClient(GS.MessageService.GetProjectForMessage(MessageId));
        }
        public static Team GetTeamForMessage(int MessageId)
        {
            return Mappers.ToClient(GS.MessageService.GetTeamForMessage(MessageId));
        }
        /*public static Project GetTaskForMessage(int MessageId)
        {
            return Mappers.ToClient(GS.MessageService.GetTaskForMessage(MessageId));
        }*/
    }
}
