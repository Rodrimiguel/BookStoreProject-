using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BOOKSTORE00.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace BOOKSTORE00.Controllers;

[Authorize]
public class UsersController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<IdentityUser> _userManager; // identity User (Pasamos la clase)
    private readonly RoleManager<IdentityRole> _roleManager;

    public UsersController(
        ILogger<HomeController> logger,
        UserManager<IdentityUser> userManager,
        RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _userManager = userManager;
        _roleManager = roleManager;
    }

    public IActionResult Index()
    {
        //listar todos los usuarios
        var users = _userManager.Users.ToList();
        return View(users);
    }
}
