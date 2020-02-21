using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Passion_Project.Models
{
    public class Artist
    {
        public int ArtistID { get; set; }
        public string ArtistName { get; set; }
       
        public string ArtistDOB { get; set; }
        public string ArtistEmail { get; set; }
        public string ArtistContact { get; set; }

        //Mant poetries to many artists
        public ICollection<poetry> Poetries { get; set; }

    }
}