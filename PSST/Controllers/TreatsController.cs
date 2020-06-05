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
  [Authorize]
  public class TreatsController : Controller
  {
    private readonly SweetSavoryContext _db;
    private readonly UserManager<ApplicationUser> _userManager;
    public TreatsController(UserManager<ApplicationUser> userManager, SweetSavoryContext db)
    {
      _userManager = userManager;
      _db = db;
    }

    public async Task<ActionResult> Index()
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      var userTreats = _db.Treats.Where(entry => entry.User.Id == userId);
      return View("Index", userTreats);
    }

    public ActionResult Create()
    {
      return View("Create");
    }

    [HttpPost]
    public async Task<ActionResult> Create(Treat Treat)
    {
      var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
      var currentUser = await _userManager.FindByIdAsync(userId);
      Treat.User = currentUser;
      _db.Treats.Add(Treat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    public ActionResult Details(int id)
    {
      Treat thisTreat = _db.Treats
          .Include(treat => treat.FlavorTreats)
          .ThenInclude(flavortreats => flavortreats.Flavor)
          .FirstOrDefault(Treat => Treat.TreatId == id);
      return View("Details", thisTreat);
    }

    public ActionResult Edit(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(Treat => Treat.TreatId == id);
      return View("Edit", thisTreat);
    }
    
    [HttpPost]
    public ActionResult Edit(Treat Treat)
    {
      _db.Entry(Treat).State = EntityState.Modified;
      _db.SaveChanges();
      return RedirectToAction("Index");
    }
    
    public ActionResult Delete(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(Treat => Treat.TreatId == id);
      return View("Index", thisTreat);
    }

    [HttpPost, ActionName("Delete")]
    public ActionResult DeleteConfirmed(int id)
    {
      Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      _db.Remove(thisTreat);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult AddFlavor(int id)
    {
      ViewBag.FlavorId = new SelectList(_db.Flavors, "FlavorId", "Name");
      Treat thisTreat = _db.Treats.FirstOrDefault(treat => treat.TreatId == id);
      return View("AddFlavor", thisTreat);
    }

    [HttpPost]
    public ActionResult AddFlavor(int TreatId, int FlavorId)
    {
      if (FlavorId != 0)
      {
        _db.FlavorTreats.Add(new FlavorTreat() { FlavorId = FlavorId, TreatId = TreatId });
      }
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

    public ActionResult DeleteFlavor(int id)
    {
      FlavorTreat thisLink = _db.FlavorTreats.FirstOrDefault(flavortreat => flavortreat.FlavorTreatId == id);
      _db.FlavorTreats.Remove(thisLink);
      _db.SaveChanges();
      return RedirectToAction("Index");
    }

  }
}