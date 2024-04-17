using Microsoft.AspNetCore.Mvc;
using static System.Net.WebRequestMethods;

namespace MyWebApplication.Controllers;

public class CoursesController : Controller
{
	public IActionResult Index()
	{
		HttpClient client = new HttpClient();
		client.GetAsync("https://localhost:7040/api/Course");
		return View();
	}
}
