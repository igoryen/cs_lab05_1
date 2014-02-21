﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Lab5.Models {
  public class Movie {

    //=======================================================
    // Constructor with no parameters
    //=======================================================
    public Movie() {
      this.Genres = new List<Genre>();
    }

    //=======================================================
    // Constructor with 4 parameters
    // t=Title, tp=TicketPrice, d=Director
    //=======================================================
    public Movie(string t, decimal tp, Director d, int sid){
      this.Genres = new List<Genre>();
      Id = sid;
    }

    [Key]
    public int Id { get; set; }
    [Required]
    public string Title { get; set; }
    [Required]
    public decimal TicketPrice { get; set; }

    public Director Director { get; set; }

    public List<Genre> Genres { get; set; }
  }

  public class Director {
    public Director() {
      this.Name = string.Empty;
      this.Movies = new List<Movie>();
    }
    public Director(string d) {
      this.Name = d;
      this.Movies = new List<Movie>();
    }
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public List<Movie> Movies { get; set; }
  }
  public class Genre {
    public Genre() {
      this.Name = string.Empty;
      this.Movies = new List<Movie>();
    }
    public Genre(string d) {
      this.Name = d;
      this.Movies = new List<Movie>();
    }
    [Key]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
    public List<Movie> Movies { get; set; }
  }
}