using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace INT422TestOne.ViewModels {
  public class RepoGenre : RepositoryBase {
    public List<GenreBase> toListOfGenreBase(List<Models.Genre> genres) {
      List<GenreBase> gls = new List<GenreBase>();
      foreach (var item in genres) {
        GenreBase gf = new GenreBase();
        gf.GenreId = item.Id;
        gf.Name = item.Name;
        gls.Add(gf);
      }
      return gls;
    }

    public IEnumerable<GenreBase> getListOfGenreBase() {

      var genres = dc.Genres.OrderBy(g => g.Name);
      if (genres == null) return null;

      List<GenreBase> gfls = new List<GenreBase>();
      foreach (var item in genres) {
        GenreBase g = new GenreBase();
        g.GenreId = item.Id;
        g.Name = item.Name;
        gfls.Add(g);
      }

      return gfls;
    }

    public SelectList getGenreSelectList() {
      SelectList sl = new SelectList(getListOfGenreBase(), "GenreId", "Name");
      return sl;
    }
  }
}