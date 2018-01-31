using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DDR.Models;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DDR.Controllers
{
    public class GithubController : Controller
    {
        public ActionResult Index()
        {
            var projectDeets = Project.GetProjects();
            return View(projectDeets);
        }
    }
}
