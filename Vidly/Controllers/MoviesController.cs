using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Vidly.Models;

namespace Vidly.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies/Random
        public ActionResult Random()
        {
            Movies movie = new Movies { Name = "Black Panther" };
            return View(movie);
        }


        //movies/edit/id or /movies/edit?id=val
        public ContentResult Edit(int id)
        {
            return Content(String.Format("id = {0}", id));
        }

        //some other action results which can be ActionResult
        public HttpNotFoundResult Error()
        {
            return HttpNotFound();
        }

        //empty result
        public EmptyResult Empty()
        {
            return new EmptyResult();
        }

        public ActionResult Optional(int? id, string name)
        {
            if (!id.HasValue)
            {
                id = 0;
            }
            if (String.IsNullOrWhiteSpace(name))
                name = "Empty string";

            return Content("id = " + id + " name = " + name);
        }

        //custom attribute routing
        [Route("movies/released/{month}/{year}")]
        public ActionResult ByReleasedYear(int? month, int? year)
        {
            if (!month.HasValue && !year.HasValue)
            {
                month = 0;
                year = 0;
            }
            
               return Content(String.Format("Month: {0} / Year: {1}", month, year));
        }

    }
}