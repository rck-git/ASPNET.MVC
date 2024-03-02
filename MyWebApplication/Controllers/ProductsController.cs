using Microsoft.AspNetCore.Mvc;
using MyWebApplication.Models.Products;

namespace MyWebApplication.Controllers
{
    public class ProductsController : Controller
    {


        //replace with db later
        private List<Product> productList = new List<Product>
            {
                new Product {Id= 1, Name = "name1", Category ="Test", Description = "Description" },
                new Product {Id= 2, Name = "name2", Category ="Test", Description = "Description" }
            };

        //responsible for a model and take the information and put them inside a view
        // https://site.com/products
        public IActionResult Index()
        {
			ViewData["Title"] = "Products Overview";

			var viewModel = new IndexViewModel();
            viewModel.ProductList = productList;

            // get products from db
            return View(viewModel); 
        }

        // https://site.com/products/details/1 => Details(int courseId)
        public IActionResult Details(int id)
        {
			ViewData["Title"] = "Products Detail";
			if (id > 0)
            {
                Product detailedProduct = productList.FirstOrDefault(x => x.Id == id);
                return View(detailedProduct);
            }
            else { return View(null); }
            //else return NotFound("Returned NotFound 404,The product was not found");
            
        }
    }
}
