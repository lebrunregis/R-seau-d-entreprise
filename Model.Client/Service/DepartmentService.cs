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

            return GS.DepartmentService.Create(Mappers.ToGlobal(d), AdminId);
        }

        public static int? Edit(int User, Department d)
        {

            return GS.DepartmentService.Edit(User, Mappers.ToGlobal(d));
        }

        public static int? Delete(int User, int depId)
        {

            return GS.DepartmentService.Delete(User, depId);
        }

        public static Department GetDepartmentById(int Id)
        {

            return Mappers.ToClient(GS.DepartmentService.GetDepartmentById(Id));
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

            List<Department> ClientDepartments = new List<Department>();
            IEnumerable<GD.Department> GlobalDepartments = GS.DepartmentService.GetAll();
            foreach (GD.Department department in GlobalDepartments)
            {
                ClientDepartments.Add(Mappers.ToClient(department));
            }
            return ClientDepartments;
        }

        public static IEnumerable<Department> GetEmployeeDepartments(int Employee_Id)
        {

            List<Department> ClientDepartments = new List<Department>();
            IEnumerable<GD.Department> GlobalDepartments = GS.DepartmentService.GetEmployeeDepartments(Employee_Id);
            foreach (GD.Department department in GlobalDepartments)
            {
                ClientDepartments.Add(Mappers.ToClient(department));
            }
            return ClientDepartments;
        }

        public static int AddEmployeeDepartment(int Employee_Id, int Department_Id)
        {

            return GS.DepartmentService.AddEmployeeDepartment(Employee_Id, Department_Id);
        }

        public static int RemoveEmployeeDepartment(int Employee_Id, int Department_Id)
        {
            return GS.DepartmentService.RemoveEmployeeDepartment(Employee_Id, Department_Id);
        }
        public static IEnumerable<EmployeeDepartmentHistory> GetEmployeeDepartmentHistory(int Employee_Id)
        {
            List<EmployeeDepartmentHistory> ClientDepartments = new List<EmployeeDepartmentHistory>();
            IEnumerable<GD.EmployeeDepartmentHistory> GlobalDepartments = GS.DepartmentService.GetEmployeeDepartmentHistory(Employee_Id);
            foreach (GD.EmployeeDepartmentHistory department in GlobalDepartments)
            {
                ClientDepartments.Add(Mappers.ToClient(department));
            }
            return ClientDepartments;
        }
    }
}
