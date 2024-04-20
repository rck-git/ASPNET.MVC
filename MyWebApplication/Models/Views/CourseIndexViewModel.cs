namespace MyWebApplication.Models.Views;

public class CourseIndexViewModel
{
	public IEnumerable<CourseViewModel> Courses { get; set; } = new List<CourseViewModel>();
}
