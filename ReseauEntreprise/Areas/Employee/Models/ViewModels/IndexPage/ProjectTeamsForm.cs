using System.Collections.Generic;
using System.ComponentModel;
using D = Model.Client.Data;

namespace ReseauEntreprise.Areas.Employee.Models.ViewModels.IndexPage
{
    public class ProjectTeamsForm
    {
        [DisplayName("My teams")]
        public List<D.Team> Teams { get; set; }
        [DisplayName("My projects")]
        public D.Project Project { get; set; }
    }
}