using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyWebApplication.Models.Views;
using Newtonsoft.Json;
using System.Collections;
using static System.Net.WebRequestMethods;

namespace MyWebApplication.Controllers;

[Authorize]
[Route("/courses")]
public class CoursesController : Controller
{
	private readonly HttpClient _httpClient;

	public CoursesController(HttpClient httpClient)
	{
		_httpClient = httpClient;
	}

	public async Task<IActionResult> Index()
	{
		var viewModel = new CourseIndexViewModel();

		var response = await _httpClient.GetAsync("https://localhost:7040/api/course");
		if (response.IsSuccessStatusCode) 
		{
			var courses = JsonConvert.DeserializeObject<IEnumerable<CourseViewModel>>(await response.Content.ReadAsStringAsync());
			if (courses != null && courses.Any())
			{
				viewModel.Courses = courses;
			}
		}
		return View(viewModel);


	}
}
