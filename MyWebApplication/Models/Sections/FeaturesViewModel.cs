using MyWebApplication.Models.Components;

namespace MyWebApplication.Models.Sections
{
	public class FeaturesViewModel
	{
		//linking ImageViewModel
		//LinkViewModel via properties
		public string? Id { get; set; }
		public ImageViewModel FeaturesImage { get; set; } = null!;
		public string? Title { get; set; }
		public string? Text { get; set; }
		public LinkViewModel Link { get; set; } = new LinkViewModel();
		
		public List<ImageViewModel>? Features { get; set; }
		public string? FeatureTitle { get; set; }
		public string? FeatureText { get; set; }
	}
}
