using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcWebGrid.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/

        public ActionResult Index()
        {
            var albums = AlbumRepo.GetAlbums();
            return View(albums);
        }

        [HttpPost]
        public ActionResult Index(int? albumId, string albumName)
        {
            var albums = AlbumRepo.GetAlbums();

            if (!string.IsNullOrEmpty(albumName))
                albums = albums.Where(a => a.Title.Contains(albumName)).ToList();

            if (albumId.HasValue)
                albums = albums.Where(a => a.AlbumId == albumId).ToList();

            return PartialView("_grid", albums);
        }
    }
}
