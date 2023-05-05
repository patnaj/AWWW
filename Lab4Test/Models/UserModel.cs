using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Lab4Test.Models
{
    public class UserModel : IdentityUser
    {

        public string managerId {get;set;}
    
        [ForeignKey("managerId")]
        public virtual ManagerModel manager {get;set;}
    }
    
    public class ManagerModel : IdentityUser
    {
        public virtual IList<UserModel> Test {get; set;}
    }


}