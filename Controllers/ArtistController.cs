using System;
using System.Collections.Generic;
using System.Data;
//required for SqlParameter class
using System.Data.SqlClient;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Passion_Project.Data;
using Passion_Project.Models;
using Passion_Project.Models.ViewModels;
using System.Diagnostics;
using System.IO;
namespace Passion_Project.Controllers
{
    public class ArtistController : Controller
    {
        private PassionProjectContext db = new PassionProjectContext();
        // GET: Artist
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult List()
        {
            //can we access the search key?
            //Debug.WriteLine("The search key is " + petsearchkey);

            string query = "Select * from artists";
            List<Artist> artists = db.Artists.SqlQuery(query).ToList();
            return View(artists);

        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(string ArtistName,string ArtistDOB,string ArtistEmail,string ArtistContact)
        {
            string query = "insert into artists (ArtistName, ArtistDOB, ArtistEmail, ArtistContact) values (@ArtistName,@ArtistDOB,@ArtistEmail,@ArtistContact)";
            SqlParameter[] sqlparams = new SqlParameter[4]; //0,1,2,3,4 pieces of information to add
            //each piece of information is a key and value pair
            sqlparams[0] = new SqlParameter("@ArtistName", ArtistName);
            sqlparams[1] = new SqlParameter("@ArtistDOB", ArtistDOB);
            sqlparams[2] = new SqlParameter("@ArtistEmail", ArtistEmail);
            sqlparams[3] = new SqlParameter("@ArtistContact", ArtistContact);

            db.Database.ExecuteSqlCommand(query, sqlparams);
          
            return RedirectToAction("List");
        }

        public ActionResult Show(int id)
        {
            string query = "select * from artists where artistid = @id";
            var parameter = new SqlParameter("@id", id);
            Artist selectedartist = db.Artists.SqlQuery(query, parameter).FirstOrDefault();

            string aside_query = "select * from artists inner join artistpoetries on artist.artistID = artistpoetries.artist_artistID where artistpoetries.poetry.poetry_ID=@id";
            var parameter1 = new SqlParameter("@id", id);
            List<poetry> poetrieswritten = db.Poetries.SqlQuery(aside_query, parameter1).ToList();

            string all_poetries_query = "select * from poetries";
            List<poetry> AllPoetries = db.Poetries.SqlQuery(all_poetries_query).ToList();

            ShowArtist viewmodel = new ShowArtist();
            viewmodel.artist = selectedartist;
            viewmodel.poetries = poetrieswritten;
            viewmodel.all_poetries = AllPoetries;
            return View(viewmodel);
        }

        public ActionResult Update(int id)
        {
            string query = "select * from artists where artistid = @id";
            var parameter = new SqlParameter("@id", id);
            Artist selectedartist = db.Artists.SqlQuery(query, parameter).FirstOrDefault();

            return View(selectedartist);
        }
        [HttpPost]
        public ActionResult Update(int id, string ArtistName,string ArtistDOB,string ArtistEmail,string ArtistContact)
        {
            string query = "update artists set ArtistName = @ArtistName,ArtistDOB = @ArtistDOB,ArtistEmail = @ArtistEmail, ArtistContact = @ArtistContact where artistid = @id";
            SqlParameter[] sqlparams = new SqlParameter[5];
            sqlparams[0] = new SqlParameter("@ArtistName", ArtistName);
            sqlparams[1] = new SqlParameter("@ArtistDOB", ArtistDOB);
            sqlparams[2] = new SqlParameter("@ArtistEmail", ArtistEmail);
            sqlparams[3] = new SqlParameter("@ArtistContact", ArtistContact);
            sqlparams[4] = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, sqlparams);

            return RedirectToAction("List");
        }

        public ActionResult DeleteConfirm(int id)
        {
            string query = "select * from artists where artistID=@id";
            SqlParameter param = new SqlParameter("@id", id);
            Artist selectedartist = db.Artists.SqlQuery(query, param).FirstOrDefault();
            return View(selectedartist);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            string query = "delete from artists where artistid=@id";
            SqlParameter param = new SqlParameter("@id", id);
            db.Database.ExecuteSqlCommand(query, param);


            //for the sake of referential integrity, unset the species for all pets
            //string refquery = "update pets set SpeciesID = '' where SpeciesID=@id";
            //db.Database.ExecuteSqlCommand(refquery, param); //same param as before

            return RedirectToAction("List");
        }
    }
}