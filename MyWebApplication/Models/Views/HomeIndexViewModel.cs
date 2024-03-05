using MyWebApplication.Models.Sections;

namespace MyWebApplication.Models.Views;
//using a indexviewmodel to actually set the values
//dynamically, and the other DTO/Model is for setting the fields
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
        Title = "Task Management Assistant You Gonna Love",
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
    public FeaturesViewModel Features { get; set; } = new Models.Sections.FeaturesViewModel
    {
        Id = "features",
        Title = "What Do You Get with Our Tool?",
        Text = "Make sure all your tasks are organized so you can set the priorities and focus on important.",

        FeatureText = "Comment on Tasks",
        //FeaturesImage = "",
        FeatureTitle = "FeatureTitle",

        Features = new List<Models.Components.ImageViewModel>
        {
        new (){ImageUrl = "/images/home/features/icon.svg",
            AltText = "features icon",
            ImageTitle="Comment on Tasks",
            ImageText="Id mollis consectetur congue egestas egestas suspendisse blandit justo."},
        new (){ImageUrl = "/images/home/features/icon-1.svg",
            AltText = "features icon 1",
            ImageTitle="Tasks Analytics",
            ImageText="Non imperdiet facilisis nulla tellus Morbi scelerisque eget adipiscing vulputate."},
		new (){ImageUrl = "/images/home/features/icon-2.svg",
            AltText = "features icon 2",
            ImageTitle = "Multiple Assignees",
            ImageText = "A elementum, imperdiet enim, pretium etiam facilisi in aenean quam mauris."},
        new (){ImageUrl = "/images/home/features/icon-3.svg",
            AltText = "features icon 3",
            ImageTitle="Notifications",
            ImageText="Diam, suspendisse velit cras ac. Lobortis diam volutpat, eget pellentesque viverra."},
        new (){ImageUrl = "/images/home/features/icon-4.svg",
            AltText = "features icon 4",
            ImageTitle = "Sections & Subtasks",
            ImageText = "Mi feugiat hac id in. Sit elit placerat lacus nibh lorem ridiculus lectus."},
        new (){ImageUrl = "/images/home/features/icon-5.svg",
            AltText = "features icon 5",
            ImageTitle="Data Security",
            ImageText="Aliquam malesuada neque eget elit nulla vestibulum nunc cras."},
		},
    };

}

