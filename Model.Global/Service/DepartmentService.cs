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
    public class DepartmentService
    {
        static readonly Connection Connection = new Connection("System.Data.SqlClient", ConfigurationManager.ConnectionStrings["connString"].ConnectionString);

        public static int? Create(Department d, int AdminId)
        {
            Command cmd = new Command("CreateDepartment", true);
            cmd.AddParameter("Name", d.Title);
            cmd.AddParameter("Description", d.Description);
            cmd.AddParameter("AdminId", AdminId);
            return (int?)Connection.ExecuteScalar(cmd);
        }

        public static int? Edit(int User, Department d)
        {
            Command cmd = new Command("EditDepartment", true);
            cmd.AddParameter("DepId", d.Id);
            cmd.AddParameter("Name", d.Title);
            cmd.AddParameter("Desc", d.Description);
            cmd.AddParameter("Active", d.Active);
            cmd.AddParameter("UserId", User);
            return (int?)Connection.ExecuteScalar(cmd);
        }

        public static int? Delete(int User, Department d)
        {
            Command cmd = new Command("DeleteDepartment", true);
            cmd.AddParameter("DepartmentId", d.Title);
            return Connection.ExecuteNonQuery(cmd);
        }

        public static Department GetDepartmentById(int Id)
        {
            Command cmd = new Command("GetDepartmentById", true);
            cmd.AddParameter("DepId", Id);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToDepartment()).FirstOrDefault();
        }

        public static IEnumerable<Department> GetAllActive()
        {
            Command cmd = new Command("GetAllActiveDepartments", true);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToDepartment());
        }

        public static IEnumerable<Department> GetAll()
        {
            Command cmd = new Command("GetAllDepartments", true);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToDepartment());
        }

        public static IEnumerable<Department> GetEmployeeDepartments(int Employee_Id)
        {
            Command cmd = new Command("GetEmployeeDepartments", true);
            cmd.AddParameter("EmployeeId", Employee_Id);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToDepartment());
        }

        public static int AddEmployeeDepartment(int Employee_Id, int Department_Id)
        {
            Command cmd = new Command("AddEmployeeDepartment", true);
            cmd.AddParameter("EmployeeId", Employee_Id);
            cmd.AddParameter("DepartmentId", Department_Id);
            return Connection.ExecuteNonQuery(cmd);
        }

        public static int RemoveEmployeeDepartment(int Employee_Id, int Department_Id)
        {
            Command cmd = new Command("RemoveEmployeeDepartment", true);
            cmd.AddParameter("EmployeeId", Employee_Id);
            cmd.AddParameter("DepartmentId", Department_Id);
            return Connection.ExecuteNonQuery(cmd);
        }
        public static IEnumerable<EmployeeDepartmentHistory> GetEmployeeDepartmentHistory(int Employee_Id)
        {
            Command cmd = new Command("GetEmployeeDepartmentsHistory", true);
            cmd.AddParameter("EmployeeId", Employee_Id);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToEmployeeDepartment());
        }
    }
}
