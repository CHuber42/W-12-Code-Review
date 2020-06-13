using Microsoft.AspNetCore.Mvc;
using SweetSavory.Models;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using System.Security.Claims;
using System.Collections.Generic;

namespace SweetSavory.Controllers 
{
  [Authorize]
  public class FlavorsController : Controller
  {
    private readonly SweetSavoryContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    public FlavorsController(SweetSavoryContext db, UserManager<ApplicationUser> userManager)
    {
      _db = db;
      _userManager = userManager;
    }

    [AllowAnonymous]
    public ActionResult Index()
    {
      IEnumerable<Flavor> userFlavors = _db.Flavors.ToList();
      return View("Index", userFlavors);
    }

    public ActionResult Create()
    {
      return View("Create");
    }

    [HttpPost]
    public async Task<ActionResult> Create(Flavor flavor)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      flavor.User = currentUser;
      _db.Flavors.Add(flavor);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    [AllowAnonymous]
    public ActionResult Details(int id)
    {
      Flavor thisFlavor = _db.Flavors
          .Include(flavor => flavor.FlavorTreats)
          .ThenInclude(flavortreats => flavortreats.Treat)
          .FirstOrDefault(flavor => flavor.FlavorId == id);
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
      return View("Delete", thisFlavor);
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