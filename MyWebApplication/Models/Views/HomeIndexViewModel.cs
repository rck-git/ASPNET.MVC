using MyWebApplication.Models.Sections;

namespace MyWebApplication.Models.Views;

public class HomeIndexViewModel
{
    public string Title { get; set; } = "Ultimate Task Management Assistant";
    public ShowcaseViewModel Showcase { get; set; } = new Models.Sections.ShowcaseViewModel
    {
        Id = "overview",
        ShowcaseImage = new()
        {
            ImageUrl = "/images/home/showcaseimage.svg",
            AltText = "Task Management Assistant"
        },
        Title = "Task Management Assistant",
        Text = "We offer you a new generation of task management system. Plan,manage & track all of your tasks in one flexible tool.",
        Link = new()
        {
            ControllerName = "Downloads",
            ActionName = "Index",
            Text = "Get started for free."
        },

        BrandsText = "Largest companies use our tool to work efficiently",
        Brands = new List<Models.Components.ImageViewModel>
                    {
                    new (){ImageUrl = "/images/home/logo.svg",AltText = "brands logo largest companies 1"},
                    new (){ImageUrl = "/images/home/logo-1.svg",AltText = "brands logo largest companies 2"},
                    new (){ImageUrl = "/images/home/logo-2.svg", AltText = "brands logo largest companies 3"},
                    new (){ImageUrl = "/images/home/logo-3.svg",AltText = "brands logo largest companies 4"},
                    },
    };
}

