﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Lab5.Models;

namespace Lab5.ViewModels {

  public class RepoDirector : RepositoryBase {

    public IEnumerable<DirectorsForList> getForList() {
      var ls = dc.Directors.OrderBy(n => n.Id);
      //var ls = this.Directors.OrderBy(n => n.Id);


      List<DirectorsForList> rls = new List<DirectorsForList>();

      foreach (var item in ls) {
        DirectorsForList dfl = new DirectorsForList();
        dfl.Id = item.Id;
        dfl.Name = item.Name;
        rls.Add(dfl);
      }

      return rls;
    }


    public DirectorFull getDirectorFull(int? id) {
      var dir = dc.Directors.FirstOrDefault(n => n.Id == id);
      //var dir = Directors.FirstOrDefault(n => n.Id == id);

      DirectorFull df = new DirectorFull();
      df.Id = dir.Id;
      df.Name = dir.Name;
      df.Movies = RepoMovie.getMoviesForList(dir.Movies );

      return df;

    }

    public IEnumerable<DirectorFull> getDirectorsFull() {

      var dd = dc.Directors.Include("Movies").OrderBy(n => n.Name);   
      //var st = this.Students.OrderBy(n => n.LastName);
      List<DirectorFull> rls = new List<DirectorFull>();

      foreach (var item in dd) {
        DirectorFull row = new DirectorFull();

        row.Id = item.Id;
        row.Name = item.Name;
        row.Movies = RepoMovie.getMoviesForList(item.Movies);

        rls.Add(row);  // 85
      }
      return rls; // 90
    }


    

  }
}

//getForList()
//getDirectorsFull()
//getDirectorFull()
//Directors (not needed when using a db)
