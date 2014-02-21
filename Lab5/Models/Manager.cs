using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Lab5.Models {
  public class Manager {

    // this is essentailly a ViewModel because the SelectList only 
    // carries the data needed to display a list control
    public SelectList getSelectList() {
      SelectList sl = new SelectList(dc.Genres, "Id", "Name");
      return sl;
    }


    // implementation details
    public Manager() { 
      dc = new DataContext();
    }
    DataContext dc;

  }
}