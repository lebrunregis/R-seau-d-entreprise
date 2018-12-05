using Model.Client.Service;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Profile
{
    public class IsAdminForm
    {
        public bool isAdmin { get; set; }
        public IsAdminForm()
        {
        }

        public IsAdminForm(int EmployeeId)
        {
            isAdmin = AuthService.IsAdmin(EmployeeId);
        }
    }
}