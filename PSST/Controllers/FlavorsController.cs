using Microsoft.AspNetCore.Mvc;
using SweetSavory.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;

namespace SweetSavory.Controllers 
{
  public class FlavorController : Controller
  {
    private readonly SweetSavoryContext _db;
    FlavorController(SweetSavoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      return View("Index");
    }

    public ActionResult Create()
    {
      return View("Create");
    }

    [HttpPost]
    public ActionResult Create(Flavor flavor)
    {
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      return View("Details");
    }

    public ActionResult Edit(int id)
    {
      return View("Edit");
    }
    
    [HttpPost]
    public ActionResult Edit(Flavor flavor)
    {
      return RedirectToAction("Index");
    }

    public ActionResult Delete(int id)
    {
      return RedirectToAction("Index");
    }

  }
}