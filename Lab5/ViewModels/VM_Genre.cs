using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace INT422TestOne.ViewModels
{
    public class GenreBase
    {
        [Key]
        public int GenreId { get; set; }
        [Required]
        public string Name { get; set; }
    }

    public class GenreFull: GenreBase
    {
        public List<MovieFull> Movies { get; set; }

        public GenreFull()
        {
            this.Name = string.Empty;
            this.Movies = new List<MovieFull>();
        }

    }
}