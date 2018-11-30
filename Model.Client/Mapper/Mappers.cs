using C = Model.Client.Data;
using G = Model.Global.Data;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Client.Mapper
{
    internal static class Mappers
    {


        internal static C.Department ToClient(this G.Department entity)
        {

            return new C.Department(entity.Id, entity.Title, entity.Created, entity.Description, entity.Admin_Id, entity.Active);
        }

        internal static G.Department ToGlobal(this C.Department entity)
        {
            return new G.Department()
            {
                Id = entity.Id,
                Title = entity.Title,
                Created = entity.Created,
                Description = entity.Description,
                Admin_Id = entity.Admin_Id,
                Active = entity.Active
            };
        }

        internal static C.Document ToClient(this G.Document entity)
        {

            return new C.Document(entity.Id, entity.Name, entity.Created, entity.Link, entity.Size, entity.SHA2, entity.Active, entity.AuthorEmployee, entity.NextVersion);
        }

        internal static G.Document ToGlobal(this C.Document entity)
        {
            return new G.Document
            {
                Id = entity.Id,
                Name = entity.Name,
                Created = entity.Created,
                Link = entity.Link,
                Size = entity.Size,
                SHA2 = entity.SHA2,
                Active = entity.Active,
                AuthorEmployee = entity.AuthorEmployee,
                NextVersion = entity.NextVersion
            };
        }

        internal static C.Employee ToClient(this G.Employee entity)
        {

            return new C.Employee(entity.Employee_Id, entity.LastName, entity.FirstName, entity.Email, entity.Passwd, entity.Actif, entity.RegNat, entity.CoordGps, entity.Address, entity.Phone, entity.IsAdmin);
        }

        internal static G.Employee ToGlobal(this C.Employee entity)
        {
            return new G.Employee()
            {
                Employee_Id = entity.Employee_Id,
                LastName = entity.LastName,
                FirstName = entity.FirstName,
                Email = entity.Email,
                Passwd = entity.Passwd,
                RegNat = entity.RegNat,
                Address = entity.Address,
                Phone = entity.Phone,
                IsAdmin = entity.IsAdmin
            };
        }

        internal static C.EmployeeDepartmentHistory ToClient(this G.EmployeeDepartmentHistory entity)
        {

            return new C.EmployeeDepartmentHistory(entity.Id, entity.Name, entity.DepId, entity.StartDate, entity.EndDate);
        }

        internal static G.EmployeeDepartmentHistory ToGlobal(this C.EmployeeDepartmentHistory entity)
        {
            return new G.EmployeeDepartmentHistory
            {
                Id = entity.Id,
                Name = entity.Name,
                DepId = entity.DepId,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate
            };
        }

        internal static C.EmployeeStatusHistory ToClient(G.EmployeeStatusHistory entity)
        {
            return new C.EmployeeStatusHistory(entity.Id, entity.Employee, entity.Status, entity.Name, entity.StartDate, entity.EndDate);
        }

        internal static G.EmployeeStatusHistory ToGlobal(this C.EmployeeStatusHistory entity)
        {
            return new G.EmployeeStatusHistory
            {
                Id = entity.Id,
                Employee = entity.Employee,
                Status = entity.Status,
                Name = entity.Name,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate
            };
        }

        internal static C.EmployeeEvent ToClient(this G.EmployeeEvent entity)
        {

            return new C.EmployeeEvent(entity.EmployeeId, entity.EventId, entity.Attended, entity.Cancelled, entity.Subscribed);
        }

        internal static G.EmployeeEvent ToGlobal(this C.EmployeeEvent entity)
        {
            return new G.EmployeeEvent
            {
                EmployeeId = entity.EmployeeId,
                EventId = entity.EventId,
                Attended = entity.Attended,
                Cancelled = entity.Cancelled,
                Subscribed = entity.Subscribed

            };
        }

        internal static C.ProjectManagerHistory ToClient(this G.ProjectManagerHistory entity)
        {

            return new C.ProjectManagerHistory(entity.Project_Id, entity.Project_Name, entity.StartDate, entity.EndDate);
        }

        internal static G.ProjectManagerHistory ToGlobal(this C.ProjectManagerHistory entity)
        {
            return new G.ProjectManagerHistory
            {
                Project_Id = entity.Project_Id,
                Project_Name = entity.Project_Name,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate
            };
        }

        internal static C.Event ToClient(this G.Event entity)
        {

            return new C.Event(entity.Id, entity.CreatorId, entity.DepartmentId, entity.Name, entity.Description, entity.Address, entity.StartDate, entity.EndDate, entity.CreationDate, entity.Subscribed, entity.Open, entity.Cancelled);
        }

        internal static G.Event ToGlobal(this C.Event entity)
        {
            return new G.Event
            {
                Id = entity.Id,
                CreatorId = entity.CreatorId,
                DepartmentId = entity.DepartmentId,
                Name = entity.Name,
                Description = entity.Description,
                Address = entity.Address,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                CreationDate = entity.CreationDate,
                Subscribed = entity.Subscribed,
                Open = entity.Open,
                Cancelled = entity.Cancelled
            };
        }

        internal static C.Message ToClient(this G.Message entity)
        {

            return new C.Message(entity.Id, entity.Title, entity.Created, entity.Body, entity.Author, entity.Parent);
        }

        internal static G.Message ToGlobal(this C.Message entity)
        {
            return new G.Message
            {
                Id = entity.Id,
                Title = entity.Title,
                Created = entity.Created,
                Body = entity.Body,
                Author = entity.Author,
                Parent = entity.Parent
            };
        }

        internal static C.Project ToClient(this G.Project entity)
        {

            return new C.Project(entity.Id, entity.Name, entity.Description, entity.Start, entity.End, entity.CreatorId, entity.ProjectManagerId);
        }

        internal static G.Project ToGlobal(this C.Project entity)
        {
            return new G.Project
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                Start = entity.Start,
                End = entity.End,
                CreatorId = entity.CreatorId,
                ProjectManagerId = entity.ProjectManagerId
            };
        }

        internal static C.Task ToClient(this G.Task entity)
        {

            return new C.Task(entity.Id, entity.Name, entity.Description, entity.StartDate, entity.EndDate, entity.Deadline, entity.SubtaskOf);
        }

        internal static G.Task ToGlobal(this C.Task entity)
        {
            return new G.Task
            {
                Id = entity.Id,
                Name = entity.Name,
                Description = entity.Description,
                StartDate = entity.StartDate,
                EndDate = entity.EndDate,
                Deadline = entity.Deadline,
                SubtaskOf = entity.SubtaskOf
            };
        }

        internal static C.Team ToClient(this G.Team entity)
        {
            List<C.Employee> Employees = new List<C.Employee>();
            if (!(entity.Employees is null))
            {
                foreach (G.Employee Employee in entity.Employees)
                {
                    Employees.Add(ToClient(Employee));
                }
            }
            return new C.Team(entity.Id, entity.Name, entity.Created, entity.Disbanded, entity.Creator_Id, entity.Project_Id, Employees);
        }

        internal static G.Team ToGlobal(this C.Team entity)
        {

            List<G.Employee> Employees = new List<G.Employee>();
            if (!(entity.Employees  is null))
            {
                foreach (C.Employee Employee in entity.Employees)
                {
                    Employees.Add(ToGlobal(Employee));
                }
            }
            
            return new G.Team
            {
                Id = entity.Id,
                Name = entity.Name,
                Created = entity.Created,
                Disbanded = entity.Disbanded,
                Creator_Id = entity.Creator_Id,
                Project_Id = entity.Project_Id,
                Employees = Employees
            };
        }

            /*TEMPLATE
             *
             * 
             internal static C ToClient(this G entity)
             {

                 return new C;
             }

             internal static G ToGlobal(this C entity)
             {
                 return new G
                 {

                 };
             }*/
        }
}
