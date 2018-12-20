using Model.Client.Data;
using Model.Client.Service;
using Réseau_d_entreprise.Models.ViewModels;
using Réseau_d_entreprise.Session;
using Réseau_d_entreprise.Session.Attributes;
using System.Web.Mvc;

namespace Réseau_d_entreprise.Controllers
{
    public class RegistrationController : Controller
    {
        // GET: Auth
        [AnonymousRequired]
        public ActionResult Index()
        {
            return RedirectToAction("Login");
        }

        [AnonymousRequired]
        public ActionResult Login()
        {
            return View();
        }

        [AnonymousRequired]
        [HttpPost]
        public ActionResult Login(LoginForm form)
        {
            if (ModelState.IsValid)
            {
                int? id = AuthService.Confirm(form.Email, form.Passwd);

                if (id != null)
                {
                    User user = new User((int)id);

                    SessionUser.SetUser(user);

                    if (SessionUser.GetUser().IsAdmin)
                    {
                        return RedirectToAction("Index", "Home", new { area = "Admin" });
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home", new { area = "Employee" });
                    }

                }
                ModelState.AddModelError("Email", "Email pas enregistré ou mot de passe incorrect");
            }
            return View(form);
        }

        [EmployeeRequired]
        public ActionResult Logout()
        {
            SessionUser.Reset();
            return RedirectToAction("Index", "Home");
        }

        [AnonymousRequired]
        public ActionResult Register()
        {
            return View();
        }

        [AnonymousRequired]
        [HttpPost]
        public ActionResult Register(RegistrationForm form)
        {
            if (ModelState.IsValid)
            {
                Employee e = new Employee
                {
                    FirstName = form.FirstName,
                    LastName = form.LastName,
                    Email = form.Email,
                    Passwd = form.Password,
                    RegNat = form.RegNat,
                    Address = form.Address,
                    Phone = form.Phone
                };
                try
                {
                    int Employee_Id = AuthService.Register(e);
                    SessionUser.SetUser(new User (Employee_Id) );
                    return RedirectToAction("Index", "Home", new { area = "Employee" });
                }
                catch (System.Data.SqlClient.SqlException exeption)
                {
                    if (exeption.Number == 2627)
                    {
                        if (exeption.Message.Contains("UC_Email"))
                        {
                            ModelState.AddModelError("Email", "Cet email est déjà utilisé");
                        }
                        if (exeption.Message.Contains("UC_RegNat"))
                        {
                            ModelState.AddModelError("RegNat", "Ce numero de régistre national est déjà utilisé. Probablement, vous êtes déjà enregistrés");
                        }
                    }
                }
            }
            return View(form);
        }
    }
}