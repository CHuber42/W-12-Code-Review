// using Microsoft.AspNetCore.Mvc;
// using Microsoft.AspNetCore.Identity;
// using SweetSavory.Models;
// using System.Threading.Tasks;
// using SweetSavory.ViewModels;


// namespace SweetSavory.Controllers
// {
//   public class AccountController : Controller
//   {
//       private readonly SweetSavoryContext _db;
//       private readonly UserManager<ApplicationUser> _userManager;
//       private readonly SignInManager<ApplicationUser> _signInManager;

//       public AccountController (UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, SweetSavoryContext db)
//       {
//           _userManager = userManager;
//           _signInManager = signInManager;
//           _db = db;
//       }

//       public ActionResult Index()
//       {
//           return RedirectToAction("Index", "Home");
//       }

//       public IActionResult Register()
//       {
//           return View("Register");
//       }

//       [HttpPost]
//       public async Task<ActionResult> Register (RegisterViewModel model)
//       {
//           var user = new ApplicationUser { UserName = model.Email };
//           IdentityResult result = await _userManager.CreateAsync(user, model.Password);
//           if (result.Succeeded)
//           {
//               return RedirectToAction("Index");
//           }
//           else
//           {
//               return RedirectToAction("Index");
//           }
//       }

//       public ActionResult Login()
//       {
//           return RedirectToAction("Index");
//       }

//     [HttpPost]
//     public async Task<ActionResult> Login(LoginViewModel model)
//     {
//       Microsoft.AspNetCore.Identity.SignInResult result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, isPersistent: true, lockoutOnFailure: false);
//       if (result.Succeeded)
//       {
//         return RedirectToAction("Index");
//       }
//       else
//       {
//         return RedirectToAction("Index");
//       }
//     }

//     [HttpPost]
//     public async Task<ActionResult> LogOff()
//     {
//         await _signInManager.SignOutAsync();
//         return RedirectToAction("Index");
//     }
//   }
// }