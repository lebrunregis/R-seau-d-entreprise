using System;

namespace Model.Global.Data
{
    public class Employee
    {
        public int? Employee_Id { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Email { get; set; }
        public string Passwd { get; set; }
        public Boolean Actif { get; set; }
        public string RegNat { get; set; }
        public string CoordGps { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public bool? IsAdmin { get; set; }
    }
}
