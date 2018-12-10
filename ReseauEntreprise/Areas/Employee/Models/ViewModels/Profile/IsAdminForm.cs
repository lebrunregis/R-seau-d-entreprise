using Model.Client.Service;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.Profile
{
    public class IsAdminForm
    {
        public bool IsAdmin { get; set; }
        public IsAdminForm()
        {
        }

        public IsAdminForm(int EmployeeId)
        {
            IsAdmin = AuthService.IsAdmin(EmployeeId);
        }
    }
}