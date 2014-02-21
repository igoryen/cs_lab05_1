using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace INT422TestOne.ViewModels {
  public class DirectorBase {
    [Key]
    public int DirectorId { get; set; }
    [Required]
    public string Name { get; set; }
  }

  public class DirectorFull : DirectorBase {
    public List<MovieBase> Movies { get; set; }

    public DirectorFull() {
      this.Name = string.Empty;
      this.Movies = new List<MovieBase>();
    }
  }
}