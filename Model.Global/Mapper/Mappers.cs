using Model.Global.Data;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Global.Mapper
{
    internal static class Mappers
    {
        internal static Employee ToEmployee(this IDataRecord dr)
        {
            Employee e = new Employee()
            {
                Employee_Id = (int)dr["Employee_Id"],
                LastName = (string)dr["LastName"],
                FirstName = (string)dr["FirstName"],
                Email = (string)dr["Email"],
                RegNat = (string)dr["RegNat"],
                Address = (string)dr["Address"],
                Phone = (dr["Phone"] == DBNull.Value) ? null : (string)dr["Phone"]
            };
            if (Enumerable.Range(0, dr.FieldCount).Select(x => dr.GetName(x)).Contains("Actif"))
            {
                e.IsAdmin = (dr["Actif"] == DBNull.Value) ? false : (bool)dr["Actif"];
            }
            if (Enumerable.Range(0, dr.FieldCount).Select(x => dr.GetName(x)).Contains("EmployeeActive"))
            {
                e.Actif = (dr["EmployeeActive"] == DBNull.Value) ? false : (bool)dr["EmployeeActive"];
            }
            return e;
        }
        internal static Project ToProject(this IDataRecord dr)
        {
            return new Project()
            {
                Id = (int)dr["Project_Id"],
                Name = (string)dr["Project_Name"],
                Description = (string)dr["Project_Description"],
                Start = (DateTime)dr["StartDate"],
                End = (DateTime?)((dr["EndDate"] == DBNull.Value) ? null : dr["EndDate"]),
                CreatorId = (int)dr["CreatorId"]
            };
        }
        internal static EmployeeStatusHistory ToEmployeeStatusHistory(this IDataRecord dr)
        {
            return new EmployeeStatusHistory()
            {
                Name = (string)dr["Name"],
                StartDate = (DateTime)dr["StartDate"],
                EndDate = (DateTime?)((dr["EndDate"] == DBNull.Value) ? null : dr["EndDate"])
            };
        }
        internal static EmployeeProjectManagerHistory ToEmployeeProjectManagerHistory(this IDataRecord dr)
        {
            return new EmployeeProjectManagerHistory()
            {
                Project_Id = (int)dr["Project_Id"],
                Project_Name = (string)dr["Project_Name"],
                StartDate = (DateTime)dr["StartDate"],
                EndDate = (DateTime?)((dr["EndDate"] == DBNull.Value) ? null : dr["EndDate"])
            };
        }
        internal static Department ToDepartment(this IDataRecord dr)
        {
            return new Department()
            {
                Id = (int)dr["Department_Id"],
                Title = (string)dr["Name"],
                Description = (string)dr["Description"],
                Admin_Id = (int)dr["Creator_Id"],
                Created = (DateTime)dr["Created"],
                Active = (bool)dr["Active"]
            };
        }
        internal static EmployeeDepartmentHistory ToEmployeeDepartment(this IDataRecord dr)
        {
            return new EmployeeDepartmentHistory()
            {
                Id = (int)dr["Id"],
                DepId = (int)dr["Department_Id"],
                Name = (string)dr["Name"],
                StartDate = (DateTime)dr["StartDate"],
                EndDate = (DateTime?)((dr["EndDate"] == DBNull.Value) ? null : dr["EndDate"])
            };
        }
        internal static Team ToTeam(this IDataRecord dr)
        {
            return new Team()
            {
                Id = (int)dr["Team_Id"],
                Name = (string)dr["Team_Name"],
                Created = (DateTime)dr["Team_Created"],
                Disbanded = (DateTime?)((dr["Team_Disbanded"] == DBNull.Value) ? null : dr["EndDate"]),
                Creator_Id = (int)dr["Creator_Id"],
                Project_Id = (int)dr["Project_Id"]
            };
        }
        internal static Event ToEvent(this IDataRecord dr)
        {
            return new Event()
            {
                Id = (int)dr["Event_Id"],
                CreatorId = (int)dr["CreatorId"],
                DepartmentId = (int?)((dr["DepartmentId"] == DBNull.Value) ? null : dr["DepartmentId"]),
                Name = (string)dr["Name"],
                Description = (string)dr["Description"],
                Address = (string)((dr["Address"] == DBNull.Value) ? null : dr["Address"]),
                StartDate = (DateTime)dr["StartDate"],
                EndDate = (DateTime)dr["EndDate"],
                CreationDate = (DateTime)dr["CreationDate"],
                Open = (bool)dr["Open"],
                Cancelled = (bool)dr["Cancelled"]
            };
        }
        internal static EmployeeEvent ToEmployeeEvent(this IDataRecord dr)
        {
            return new EmployeeEvent()
            {
                EmployeeId = (int)dr["Employee_Id"],
                EventId = (int)dr["Event_Id"],
                Attended = (bool?)((dr["Attended"] == DBNull.Value) ? null : dr["Attended"]),
                Cancelled = (bool?)((dr["Cancelled"] == DBNull.Value) ? null : dr["Cancelled"]),
                Subscribed = (DateTime?)((dr["Subscribed"] == DBNull.Value) ? null : dr["Subscribed"])
            };
        }
        internal static Message ToMessage(this IDataRecord dr)
        {
            return new Message()
            {
                Id = (int)dr["Message_Id"],
                Title = (string)((dr["Message_Title"] == DBNull.Value) ? null : dr["Message_Title"]),
                Created = (DateTime)dr["Message_Date"],
                Body = (string)dr["Message_Message"],
                Author = (int)dr["Message_Author"],
                Parent = (int?)((dr["Message_Parent"] == DBNull.Value) ? null : dr["Message_Parent"])
            };
        }
    }
}
