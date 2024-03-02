using Microsoft.AspNetCore.Mvc;
using MyWebApplication.Models.Views;

namespace MyWebApplication.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        var viewModel = new HomeIndexViewModel();
           ViewData["Title"] = viewModel.Title;

           return View(viewModel);
    }
}

