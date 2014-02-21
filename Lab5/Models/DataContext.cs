using System.Data.Entity;

namespace INT422TestOne.Models {
  public class DataContext : DbContext {
    public DataContext() : base("name=DataContext") { }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Director> Directors { get; set; }
    public DbSet<Genre> Genres { get; set; }

    public System.Data.Entity.DbSet<INT422TestOne.ViewModels.MovieBase> MovieBases { get; set; }

    public System.Data.Entity.DbSet<INT422TestOne.ViewModels.MovieFull> MovieFulls { get; set; }

    public System.Data.Entity.DbSet<INT422TestOne.ViewModels.DirectorBase> DirectorBases { get; set; }

    public System.Data.Entity.DbSet<INT422TestOne.ViewModels.GenreBase> GenreBases { get; set; }

  }
}