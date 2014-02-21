using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using INT422TestOne.ViewModels;

namespace INT422TestOne.Controllers {
  public class MovieController : Controller {
    private RepoMovie repo = new RepoMovie();
    private RepoGenre gen = new RepoGenre();
    private RepoDirector dir = new RepoDirector();

    //
    // GET: /Movie/
    public ActionResult Index() {
      return View(repo.getListOfMovieBase());
    }

    //
    // GET: /Movie/Details/5
    public ActionResult Details(int id) {
      return View(repo.getMovieFull(id));
    }

    //
    // GET: /Movie/Create
    public ActionResult Create() {
      ViewBag.genres = gen.getGenreSelectList();
      ViewBag.directors = dir.getDirectorSelectList();

      return View();
    }

    //
    // POST: /Movie/Create
    [HttpPost]
    public ActionResult Create(FormCollection form) {
      try {
        if (form.Count == 5) {
          repo.createMovie(form[1], form[2], form[3], form[4]);
        }

        return RedirectToAction("Index");
      }
      catch (Exception e) {
        ViewBag.ExceptionMessage = e.Message;

        return View("Error");
      }
    }
  }
}
