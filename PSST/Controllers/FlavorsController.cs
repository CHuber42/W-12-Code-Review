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
  public class FlavorsController : Controller
  {
    private readonly SweetSavoryContext _db;
    FlavorsController(SweetSavoryContext db)
    {
      _db = db;
    }

    public ActionResult Index()
    {
      List<Flavor> allFlavors = _db.Flavors.ToList();
      return View("Index", allFlavors);
    }

    public ActionResult Create()
    {
      return View("Create");
    }

    [HttpPost]
    public ActionResult Create(Flavor flavor)
    {
      _db.Flavors.Add(flavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
      return View("Details", thisFlavor);
    }

    public ActionResult Edit(int id)
    {
      Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
      return View("Edit", thisFlavor);
    }
    
    [HttpPost]
    public ActionResult Edit(Flavor flavor)
    {
      _db.Entry(flavor).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
    public ActionResult Delete(int id)
    {
      Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
      return View("Index", thisFlavor);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
      _db.Remove(thisFlavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddTreat(int id)
    {
      ViewBag.TreatId = new SelectList(_db.Treats, "TreatId", "Name");
      Flavor thisFlavor = _db.Flavors.FirstOrDefault(flavor => flavor.FlavorId == id);
      return View("AddTreat", thisFlavor);
    }

    [HttpPost]
    public ActionResult AddTreat(int FlavorId, int TreatId)
    {
      if (TreatId != 0)
      {
        _db.FlavorTreats.Add(new FlavorTreat() { FlavorId = FlavorId, TreatId = TreatId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult DeleteTreat(int id)
    {
      FlavorTreat thisLink = _db.FlavorTreats.FirstOrDefault(flavortreat => flavortreat.FlavorTreatId == id);
      _db.FlavorTreats.Remove(thisLink);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
  }
}