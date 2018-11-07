using Model.Global.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolBox.DBTools;

namespace Model.Global.Service
{
    class DepartmentService
    {
        static readonly Connection Connection = new Connection("System.Data.SqlClient", ConfigurationManager.ConnectionStrings["connString"].ConnectionString);

        public static int? Create(Department d, int AdminId)
        {
            Command cmd = new Command("CreateDepartment", true);
            cmd.AddParameter("Name", d.Title);
            cmd.AddParameter("Description", d.Description);
            cmd.AddParameter("Admin_Id", AdminId);
            return (int?)Connection.ExecuteScalar(cmd);
        }

   /*     public static int? Edit(int User, Department d)
        {
            Command cmd = new Command("EditDepartment", true);
            cmd.AddParameter("Name", d.Title);
            cmd.AddParameter("Description", d.Description);
            cmd.AddParameter("Creator", d.Admin_Id);
            cmd.AddParameter("Project_Manager", ProjectManager);
            return (int?)Connection.ExecuteScalar(cmd);
        }

        public static int? Delete(Department d, int User)
        {
            Command cmd = new Command("DeleteDepartment", true);
            cmd.AddParameter("Name", d.Title);
            cmd.AddParameter("Description", d.Description);
            cmd.AddParameter("Creator", d.Admin_Id);
            cmd.AddParameter("Project_Manager", ProjectManager);
            return (int?)Connection.ExecuteScalar(cmd);
        }

        public static Data.Department GetDepartmentById(int Id)
        {
            Command cmd = new Command("GetDepartmentById", true);
            cmd.AddParameter("Id", Id);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToDepartment()).FirstOrDefault();
        }

        public static IEnumerable<Data.Project> GetAllActive()
        {
            Command cmd = new Command("GetAllActiveDepartments", true);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToDepartment());
        }

        public static IEnumerable<Data.Project> GetAll()
        {
            Command cmd = new Command("GetAllDepartments", true);
            return Connection.ExecuteReader(cmd, (dr) => dr.ToDepartment());
        }*/
    }
}
