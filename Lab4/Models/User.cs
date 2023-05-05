using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Lab4.Models
{
    public class UserModel : IdentityUser
    {
        
        public string Avatar {get;set;} 
    }

    public class Manager : UserModel{
        public virtual IList<UserModel> Employees {get; set;}
    }
}