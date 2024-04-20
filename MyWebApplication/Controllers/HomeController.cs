using Microsoft.AspNetCore.Mvc;
using MyWebApplication.Models.Views;
using Newtonsoft.Json;
using System.Text;

namespace MyWebApplication.Controllers;

public class HomeController : Controller
{
    private readonly HttpClient _httpClient;

	public HomeController(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public IActionResult Index()
    {
        var viewModel = new HomeIndexViewModel();
           ViewData["Title"] = viewModel.Title;
		   

		return View(viewModel);
    }

    [HttpPost]
    public async Task <IActionResult> Subscribe (SubscribeViewModel model)
    {
        if (ModelState.IsValid)
        {
            var content = new StringContent(JsonConvert.SerializeObject(model), Encoding.UTF8,"application/json");
            var response = await _httpClient.PostAsync("https://localhost:7040/api/subscribe", content);
            if(response.IsSuccessStatusCode)
            {
                TempData["StatusMessage"] = "You are now subscribed";
            }
            else if (response.StatusCode == System.Net.HttpStatusCode.Conflict)
            {
				TempData["StatusMessage"] = "You are already subscribed";
			}
			
        }
        else
        {
            TempData["StatusMessage"] = "Invalid email address";
        }

        return RedirectToAction("Index", "Home", "", "subscribe");
        
    }
}

