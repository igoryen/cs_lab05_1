using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INT422TestOne.Controllers {
  public class DirectorController : Controller {
    private INT422TestOne.ViewModels.RepoDirector repo = new ViewModels.RepoDirector();
    //
    // GET: /Director/
    public ActionResult Index() {
      return View(repo.getListOfDirectorBase());
    }
  }
}