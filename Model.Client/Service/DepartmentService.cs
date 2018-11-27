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
    public class DepartmentService
    {

        public static int? Create(Department d, int AdminId)
        {

            return G.DepartmentService.Create(Mappers.ToGlobal(d), AdminId);
        }

        public static int? Edit(int User, Department d)
        {

            return G.DepartmentService.Edit(User, Mappers.ToGlobal(d));
        }

        public static int? Delete(int User, int depId)
        {

            return G.DepartmentService.Delete(User, depId);
        }

        public static Department GetDepartmentById(int Id)
        {

            return Mappers.ToClient(G.DepartmentService.GetDepartmentById(Id));
        }

        public static IEnumerable<Department> GetAllActive()
        {
            List<Department> ClientDepartments = new List<Department>();
            IEnumerable<GD.Department> GlobalDepartments = GS.DepartmentService.GetAllActive();
            foreach(GD.Department department in GlobalDepartments)
            {
                ClientDepartments.Add(Mappers.ToClient(department));
            }
            return ClientDepartments;
        }

        public static IEnumerable<Department> GetAll()
        {

            return G.DepartmentService
        }

        public static IEnumerable<Department> GetEmployeeDepartments(int Employee_Id)
        {

            return G.DepartmentService
        }

        public static int AddEmployeeDepartment(int Employee_Id, int Department_Id)
        {

            return G.DepartmentService
        }

        public static int RemoveEmployeeDepartment(int Employee_Id, int Department_Id)
        {

            return G.DepartmentService
        }
        public static IEnumerable<EmployeeDepartmentHistory> GetEmployeeDepartmentHistory(int Employee_Id)
        {

            return G.DepartmentService
        }
    }
}
