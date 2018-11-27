using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using G = Model.Global.Data;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Employee
{
    public class DepartmentComparator : IEqualityComparer<G.Department>
    {
        public bool Equals(G.Department x, G.Department y)
        {
            
            return x.Id == y.Id;
        }

        public int GetHashCode(G.Department obj)
        { 
            return obj.Id;
        }

    }
}