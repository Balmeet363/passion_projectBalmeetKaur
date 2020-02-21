using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
namespace Passion_Project.Data
{
    public class PassionProjectContext: DbContext
    {
        public PassionProjectContext() : base("name=PassionProjectContext")
        {

        }

        public System.Data.Entity.DbSet<Passion_Project.Models.Artist>Artists { get; set; }
        public System.Data.Entity.DbSet<Passion_Project.Models.poetry> Poetries { get; set; }


    }
}