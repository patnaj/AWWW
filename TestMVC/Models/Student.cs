using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace TestMVC.Models
{
    public class Student : IdentityUser
    {
        [RegularExpression(@"^\p{Lu}\p{Ll}+$")]
        public string FirstName {get;set;} = "";
        [RegularExpression(@"^\p{Lu}\p{Ll}+$")]
        public string LastName {get;set;} = "";
        public int? IndexID {get;set;} = null;        
        public virtual List<Mark> Marks {get;set;} = null!;
    }
}