using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab5.Models;

namespace Lab5.ViewModels {

  public class RepoMovie : RepositoryBase {



    public IEnumerable<MoviesForList> getForList() {
      var ls = dc.Movies.OrderBy(n => n.Id);
      //var ls = this.Directors.OrderBy(n => n.Id);


      List<MoviesForList> rls = new List<MoviesForList>();

      foreach (var item in ls) {
        MoviesForList mfl = new MoviesForList();
        mfl.Id = item.Id;
        mfl.Title = item.Title;
        rls.Add(mfl);
      }

      return rls;
    }

    //==============================================================================================
    // getMovieFull() - deliver details for the movie whose id has been passed
    // Fetch title, ticketprice, director. These properties are in ViewModels/VM_Movie.cs/MovieFull
    //==============================================================================================
    public MovieFull getMovieFull(int? id) {
      var m = dc.Movies.FirstOrDefault(n => n.Id == id);
      //var dir = Directors.FirstOrDefault(n => n.Id == id);

      MovieFull mf = new MovieFull();
      mf.Id = m.Id;
      mf.Title = m.Title;
      mf.TicketPrice = m.TicketPrice;
      //mf.Director.Name = m.Director.Name as string; // <====
      //mf.Director.Name = m.Director.Name;
      mf.Genres = RepoGenre.getGenresForList(m.Genres);

      return mf;

    }
    //==============================================================================================
    // getMoviesFull() - deliver a list of all movies.
    // Include(NP) is the Include path. It must be valid. NP = a navigation property.
    // The NP must be declared by the EntityType "proj_name.Models.[AppDomainClasses.cs.]class_name.
    // Here, the EntityType is 'Lab5.Models.Movie'. And the Include path's NP is "Genres",
    // since class Movie includes 'List<Genre> Genres'
    //==============================================================================================
    public IEnumerable<MovieFull> getMoviesFull() {
      
      var mm = dc.Movies.Include("Genres").OrderBy(n => n.Title);
      //var st = this.Students.OrderBy(n => n.LastName);
      List<MovieFull> rls = new List<MovieFull>();

      foreach (var item in mm) {
        MovieFull row = new MovieFull();

        row.Id = item.Id;
        row.Title = item.Title;
        row.TicketPrice = item.TicketPrice;
        //row.Director.Name = item.Director.Name as string; // <==== ERROR!
        row.Genres = RepoGenre.getGenresForList(item.Genres);

        rls.Add(row);  // 85
      }
      return rls; // 90
    }


    public static List<MoviesForList> getMoviesForList(List<Lab5.Models.Movie> ls) {
      List<MoviesForList> nls = new List<MoviesForList>();

      foreach (var item in ls) {
        MoviesForList mfl = new MoviesForList();
        mfl.Id = item.Id;
        mfl.Title = item.Title;
        nls.Add(mfl);
      }

      return nls;
    }

    //===================================================================================================
    // createMovie() - create a row (record) of class "Movie"
    // 5. instantiate new movie
    // 10. create a list of ints
    // 12. the format of ids is ("n,n,n,...") where n is an numeric character 
    //     split the string into an array of individual characters
    // 15. convert each character to an int32 and store in ls
    // 20. iterate through ls and for each id in the list, add a Genre to the movie's Genres collection
    // 22. add the movie to the DataContext
    // 25. savechanges is the equivalent to a database commit statement
    // 30. return a copy of the new Movie as a MovieFull
    //===================================================================================================
    public MovieFull createMovie(MovieFull mf, string ids) {

      Movie m = new Movie(); // 5
      m.Id = mf.Id;
      m.Title = mf.Title;
      m.TicketPrice = mf.TicketPrice;
      //m.Director = mf.Director;
      m.Director.Name = mf.Director.Name;

      List<Int32> ls = new List<int>();// 10
      var nums = ids.Split(','); //12

      foreach (var item in nums) { // 15
        ls.Add(Convert.ToInt32(item));
      }

      foreach (var item in ls) { // 20
        m.Genres.Add(dc.Genres.FirstOrDefault(n => n.Id == item));
      }

      dc.Movies.Add(m); // 22
      dc.SaveChanges(); // 25

      return getMovieFull(m.Id); // 30
    }

    //===================================================================================================
    // createMovie() - when a MovieFull object is passed
    // 3. instantiate new student
    // 5. savechanges is the equivalent to a database commit statement
    // 10. return a copy of the new Movie as a MovieFull
    //===================================================================================================
    public MovieFull createMovie(MovieFull mf) {

      Movie mo = new Movie(mf.Title, mf.TicketPrice, mf.Director, mf.Id); // 3

      dc.Movies.Add(mo);
      dc.SaveChanges(); // 5

      return getMovieFull(mo.Id); // 10
    }


  }
}
