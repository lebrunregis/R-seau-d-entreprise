using Model.Global.Data;
using Model.Global.Mapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.DBTools;

namespace Model.Global.Service
{
    public static class EmployeeService
    {
        static readonly Connection Connection = new Connection("System.Data.SqlClient", ConfigurationManager.ConnectionStrings["connString"].ConnectionString);

        public static IEnumerable<Employee> GetAllActive()
        {
            Command cmd = new Command("GetAllActiveEmployees", true);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToEmployee());
        }
        public static Employee Get(int Id)
        {
            Command cmd = new Command("GetEmployee", true);
            cmd.AddParameter("Id", Id);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToEmployee()).SingleOrDefault();
        }
        public static bool Update(Employee e)
        {
            Command cmd = new Command("Update_Employee", true);
            cmd.AddParameter("Employee_Id", e.Employee_Id);
            cmd.AddParameter("LastName", e.LastName);
            cmd.AddParameter("FirstName", e.FirstName);
            cmd.AddParameter("Address", e.Address);
            cmd.AddParameter("Phone", e.Phone);
            return (Connection.ExecuteNonQuery(cmd) > 0);
        }
        public static bool UpdateEmail(Employee e)
        {
            Command cmd = new Command("Update_Email", true);
            cmd.AddParameter("Employee_Id", e.Employee_Id);
            cmd.AddParameter("Email", e.Email);
            cmd.AddParameter("Password", e.Passwd);
            return (Connection.ExecuteNonQuery(cmd) > 0);
        }
        public static bool UpdatePassword(Employee e, string OldPass)
        {
            Command cmd = new Command("Update_Password", true);
            cmd.AddParameter("Employee_Id", e.Employee_Id);
            cmd.AddParameter("Old_Password", OldPass);
            cmd.AddParameter("New_Password", e.Passwd);
            return (Connection.ExecuteNonQuery(cmd) > 0);
        }
        public static bool Delete(Employee e)
        {
            Command cmd = new Command("Delete_Employee", true);
            cmd.AddParameter("Employee_Id", e.Employee_Id);
            cmd.AddParameter("LastName", e.LastName);
            cmd.AddParameter("RegNat", e.RegNat);
            cmd.AddParameter("FirstName", e.FirstName);
            cmd.AddParameter("Address", e.Address);
            cmd.AddParameter("Phone", e.Phone);
            return (Connection.ExecuteNonQuery(cmd) > 0);
        }
        public static Employee GetForAdmin(int Id)
        {
            Command cmd = new Command("GetEmployeeForAdmin", true);
            cmd.AddParameter("Id", Id);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToEmployee()).SingleOrDefault();
        }
        public static IEnumerable<Employee> GetAllActiveForAdmin()
        {
            Command cmd = new Command("GetAllEmployeesForAdmin", true);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToEmployee());
        }
        public static bool UpdateForAdmin (Employee e)
        {
            Command cmd = new Command("EditEmployeeForAdmin", true);
            cmd.AddParameter("Employee_Id", e.Employee_Id);
            cmd.AddParameter("LastName", e.LastName);
            cmd.AddParameter("FirstName", e.FirstName);
            cmd.AddParameter("Email", e.Email);
            cmd.AddParameter("Password", e.Passwd);
            cmd.AddParameter("RegNat", e.RegNat);
            cmd.AddParameter("Address", e.Address);
            cmd.AddParameter("Phone", e.Phone);
            cmd.AddParameter("IsAdmin", e.IsAdmin);
            return (Connection.ExecuteNonQuery(cmd) > 0);
        }
        public static IEnumerable<EmployeeStatusHistory> GetEmployeeStatusHistory(int Employee_Id)
        {
            Command cmd = new Command("GetEmployeeStatusHistory", true);
            cmd.AddParameter("Employee_Id", Employee_Id);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToEmployeeStatusHistory());
        }
        public static IEnumerable<ProjectManagerHistory> GetProjectManagerHistory(int Employee_Id)
        {
            Command cmd = new Command("GetEmployeeProjectManagerHistory", true);
            cmd.AddParameter("Employee_Id", Employee_Id);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToEmployeeProjectManagerHistory());
        }

    }
}
