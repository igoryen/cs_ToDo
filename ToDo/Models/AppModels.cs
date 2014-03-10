using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDo.Models {
  public class AppModels {

    //================================================================
    // Since we are using Entity Framework Code First, EF will create 
    // the right keys between Users and ToDo table.
    //================================================================

    //================================================================
    // CREATE TABLE MyUser (HomeTown, ToDoes);
    //================================================================
    public class MyUser : IdentityUser {
      public string HomeTown { get; set; }
      public virtual ICollection<ToDo> ToDoes { get; set; }
    }

    //================================================================
    // CREATE TABLE ToDo (Id, Description, IsDone, User);
    //================================================================
    public class ToDo {
      public int Id { get; set; }
      public string Description { get; set; }
      public bool IsDone { get; set; }
      public virtual MyUser User { get; set; }
    }

  }
}