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
            Employee e = new Employee() {
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
    }
}
