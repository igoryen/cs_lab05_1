using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using INT422TestOne.ViewModels;

namespace INT422TestOne.ViewModels {
  public class RepoMovie : RepositoryBase {
    public MovieFull getMovieFull(int? id) {
      var movie = dc.Movies.Include("Genres").Include("Director").SingleOrDefault(n => n.Id == id);

      if (movie == null) return null;

      MovieFull mf = new MovieFull();
      mf.MovieId = movie.Id;
      mf.Title = movie.Title;
      mf.TicketPrice = movie.TicketPrice;
      mf.Director = rd.toDirectorFull(movie.Director);
      mf.Genres = rg.toListOfGenreBase(movie.Genres);

      return mf;
    }

    public IEnumerable<MovieBase> getListOfMovieBase() {

      var movies = dc.Movies.OrderBy(m => m.Title);

      List<MovieBase> mbls = new List<MovieBase>();

      foreach (var item in movies) {
        MovieBase mf = new MovieBase();
        mf.MovieId = item.Id;
        mf.Title = item.Title;
        mbls.Add(mf);
      }

      return mbls;
    }
    public IEnumerable<MovieFull> getListOfMovieFull() {

      var movies = dc.Movies.Include("Genres").OrderBy(m => m.Title);

      List<MovieFull> mfls = new List<MovieFull>();

      foreach (var item in movies) {
        MovieFull mf = new MovieFull();
        mf.MovieId = item.Id;
        mf.Title = item.Title;
        mf.TicketPrice = item.TicketPrice;
        mf.Director = rd.getDirectorFull(item.Id);
        mf.Genres = rg.toListOfGenreBase(item.Genres);
        mfls.Add(mf);
      }

      return mfls;
    }

    public MovieFull createMovie(string title, string price, string gids, string d) {
      Models.Movie m = new Models.Movie();

      m.Title = title;
      m.TicketPrice = Convert.ToDecimal(price);

      foreach (var item in gids.Split(',')) {
        var intItem = Convert.ToInt32(item);
        var g = dc.Genres.FirstOrDefault(gg => gg.Id == intItem);
        m.Genres.Add(g);
      }

      int did = Convert.ToInt32(d);
      m.Director = dc.Directors.FirstOrDefault(n => n.Id == did);

      dc.Movies.Add(m);
      dc.SaveChanges();

      return getMovieFull(m.Id);
    }
    public List<MovieBase> toListOfMovieBase(List<Models.Movie> movies) {

      List<MovieBase> mbls = new List<MovieBase>();

      foreach (var item in movies) {
        MovieBase mm = new MovieBase();
        mm.MovieId = item.Id;
        mm.Title = item.Title;
        mbls.Add(mm);
      }

      return mbls;
    }

    public RepoMovie() {
      rd = new RepoDirector();
      rg = new RepoGenre();
    }

    // Implementation details
    RepoDirector rd;
    RepoGenre rg;
  }
}