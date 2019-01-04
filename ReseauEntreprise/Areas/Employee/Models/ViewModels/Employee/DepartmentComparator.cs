using System.Collections.Generic;
using C = Model.Client.Data;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Employee
{
    public class DepartmentComparator : IEqualityComparer<C.Department>
    {
        public bool Equals(C.Department x, C.Department y)
        {
            
            return x.Id == y.Id;
        }

        public int GetHashCode(C.Department obj)
        { 
            return (int)obj.Id;
        }

    }
}