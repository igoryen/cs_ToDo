using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ToDo.Models {
  public class MyDbInitializer : DropCreateDatabaseAlways<MyDbContext> {

    protected override void Seed(MyDbContext context) {
      //==========================================================================
      // Create a UserManger from ASP.NET Identity system which will let us 
      // do operations on the User such as Create, List, Edit and Verify the user. 
      //==========================================================================
      var UserManager = new UserManager<MyUser>(new UserStore<MyUser>(context));

      //==================================================================================
      // Create a RoleManager from ASP.NET Identity system which lets us operate on Roles.
      //==================================================================================
      var RoleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));

      string name = "Admin";
      string password = "123456";


      //Create Role Admin if it does not exist
      if (!RoleManager.RoleExists(name)) {
        var roleresult = RoleManager.Create(new IdentityRole(name));
      }

      //Create User=Admin with password=123456
      var user = new MyUser();
      user.UserName = name;
      var adminresult = UserManager.Create(user, password);

      //Add User Admin to Role Admin
      if (adminresult.Succeeded) {
        var result = UserManager.AddToRole(user.Id, name);
      }
      base.Seed(context);
    }
  }
}