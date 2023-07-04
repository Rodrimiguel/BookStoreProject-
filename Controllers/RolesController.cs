using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using BOOKSTORE00.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using BOOKSTORE00.Views.Roles.ViewModels;

namespace BOOKSTORE00.Controllers;

[Authorize]
public class RolesController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly RoleManager<IdentityRole> _roleManager; // identity Role (Pasamos la clase)
    
   public RolesController(
        ILogger<HomeController> logger,
        RoleManager<IdentityRole> roleManager)
    {
        _logger = logger;
        _roleManager = roleManager;
    }

    [Authorize(Roles = "Principal Administrator")]
    public IActionResult Index()
    {
        //listar todos los usuarios
        var roles = _roleManager.Roles.ToList();
        return View(roles);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(RoleCreateViewModel model)
    {
        if(string.IsNullOrEmpty(model.RoleName))
        {
            return View();
        }

        var role = new IdentityRole(model.RoleName);
        _roleManager.CreateAsync(role);

        return RedirectToAction("Index");
    }

}
















