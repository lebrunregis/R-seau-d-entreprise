using Model.Client.Data;
using Model.Client.Mapper;
using GS = Model.Global.Service;
using GD = Model.Global.Data;
using System.Collections.Generic;
using System;

namespace Model.Client.Service
{
    public class TaskService
    {
        public static int? Create(Task t, int UserId)
        {
            return GS.TaskService.Create(Mappers.ToGlobal(t), UserId);
        }

        public static Task Get(int id, int UserId)
        {
            return Mappers.ToClient(GS.TaskService.Get(id,UserId));
        }

        public static IEnumerable<Task> GetSubtasks(Task t, int UserId)
        {
            List<Task> Tasks = new List<Task>();
            IEnumerable<GD.Task> GlobalTasks = GS.TaskService.GetSubtasks(Mappers.ToGlobal(t),UserId);
            foreach (GD.Task Task in GlobalTasks)
            {
                Tasks.Add(Mappers.ToClient(Task));
            }
            return Tasks;
        }

        public static IEnumerable<Task> GetForUser(int UserId)
        {
            List<Task> Tasks = new List<Task>();
            IEnumerable<GD.Task> GlobalTasks = GS.TaskService.GetForUser(UserId);
            foreach (GD.Task Task in GlobalTasks)
            {
                Tasks.Add(Mappers.ToClient(Task));
            }
            return Tasks;
        }

        public static IEnumerable<Task> GetForTeam(int teamId, int UserId)
        {
            List<Task> Tasks = new List<Task>();
            IEnumerable<GD.Task> GlobalTasks = GS.TaskService.GetForTeam(teamId, UserId);
            foreach (GD.Task Task in GlobalTasks)
            {
                Tasks.Add(Mappers.ToClient(Task));
            }
            return Tasks;
        }

        public static IEnumerable<Task> GetForProject(int projectId, int UserId)
        {
            List<Task> Tasks = new List<Task>();
            IEnumerable<GD.Task> GlobalTasks = GS.TaskService.GetForProject(projectId, UserId);
            foreach (GD.Task Task in GlobalTasks)
            {
                Tasks.Add(Mappers.ToClient(Task));
            }
            return Tasks;
        }

        public static bool SetStatus(Task t, int Status, int UserId)
        {
            return GS.TaskService.SetStatus(Mappers.ToGlobal(t), Status, UserId);
        }

        public static bool Edit(Task t, int UserId)
        {
            return GS.TaskService.Update(Mappers.ToGlobal(t), UserId);
        }

        public static bool AssignEmployee(Task t, int UserId)
        {
            return GS.TaskService.AssignEmployee(Mappers.ToGlobal(t), UserId);
        }

        public static bool Delete(Task t, int UserId)
        {
            return GS.TaskService.Delete(Mappers.ToGlobal(t), UserId);
        }

        public static IEnumerable<TaskStatusHistory> GetTaskStatusesHistory(Task t, int UserId)

        {
            List<TaskStatusHistory> TSH = new List<TaskStatusHistory>();
            IEnumerable<GD.TaskStatusHistory> Tasks = GS.TaskService.GetTaskStatusesHistory(Mappers.ToGlobal(t), UserId);
            foreach (GD.TaskStatusHistory Task in Tasks)
            {
                TSH.Add(Mappers.ToClient(Task));
            }
            return TSH;
        }

        public static IEnumerable<TaskStatus> GetStatusList()
        {
            List<TaskStatus> TS = new List<TaskStatus>();
            IEnumerable<GD.TaskStatus> Statuses = GS.TaskService.GetStatusList();
            foreach (GD.TaskStatus Task in Statuses)
            {
                TS.Add(Mappers.ToClient(Task));
            }
            return TS;
        }
    }
}
