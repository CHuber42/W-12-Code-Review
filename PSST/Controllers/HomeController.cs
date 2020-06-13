using Microsoft.AspNetCore.Mvc;
using SweetSavory.Models;
using System.Collections.Generic;
using System.Linq;

namespace SweetSavory.Controllers
{
  public class HomeController : Controller
  {
    private readonly SweetSavoryContext _db;

    public HomeController(SweetSavoryContext db)
    {
      _db = db;
    }
    public ActionResult Index()
    {
      return View("Index");
    }

    public ActionResult Flavors()
    {
      List<Flavor> allFlavors = _db.Flavors.ToList();
      return View("BrowseFlavors", allFlavors);
    }

    public ActionResult Treats()
    {
      List<Treat> allTreats = _db.Treats.ToList();
      return View("BrowseTreats", allTreats);
    }
  }
}