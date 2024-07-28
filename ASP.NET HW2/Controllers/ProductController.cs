using ASP.NET_HW2.Entities;
using ASP.NET_HW2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ASP.NET_HW2.Controllers
{
	public class ProductController : Controller
	{
		public static List<Products> products { get; set; } = new List<Products>()
		   {

				new Products()
				{
				   Id= 1,
				   Name ="Apple iPhone 15",
				   Description="Latest model with advanced features",
				   Price = 999.99,
				   Discount = 10.0
				},
				new Products()
				{
				   Id= 2,
				   Name ="Samsung Galaxy S22 ",
				   Description="High-end smartphone with sleek design",
				   Price =799.99,
				   Discount = 15.16
				},
				new Products()
				{
				   Id= 3,
				   Name ="Sony WH-1000XM4",
				   Description="Noise-cancelling wireless headphones",
				   Price = 349.99,
				   Discount = 20.0
				},
				new Products()
				{
				   Id= 4,
				   Name ="Dell XPS 13",
				   Description="Powerful and compact laptop",
				   Price = 1399.99,
				   Discount = 30.0
				},
				new Products()
				{
				   Id= 5,
				   Name ="Apple Watch Series 6",
				   Description="Advanced health and fitness tracker",
				   Price = 399.99,
				   Discount = 0.0
				}
                //CotrollerName/ActionName
                //Home/Index
                //GetById
                //EmployeeDetailsViewModel
           };

		[HttpGet]
		public ActionResult Index()
		{
			var vm = new ProductListViewModel
			{
				products = products
			};
			return View(vm);
		}

		[HttpGet]
		public IActionResult Add()
		{
			var vm = new ProductAddViewModel
			{
				Products = new Products()
			};
			return View(vm);
		}
		[HttpPost]
		public IActionResult Add(ProductAddViewModel vm)
		{
			if(ModelState.IsValid)
			{
				vm.Products.Id = (new Random()).Next(100, 1000);
				products.Add(vm.Products);
				return RedirectToAction("Index");

			}
			else
			{
				return View(vm);
			}
		}

		[HttpGet]
		public IActionResult Delete(int id)
		{
			var item = products.SingleOrDefault(e => e.Id == id);
			if(item != null)
			{
				products.Remove(item);
			}
			return RedirectToAction("Index");
		}


		[HttpGet]
		public IActionResult Update(int id)
		{
			var item = products.SingleOrDefault(i=>i.Id == id);
			if(item == null)
			{
				return NotFound();
			}

			var vm = new ProductRemoveViewModel
			{
				Products = item
			};

			return View(vm);

		}

		[HttpPost]

		public IActionResult Update(ProductRemoveViewModel vm ,int id)
		{
			var item = products.SingleOrDefault(i=>i.Id==id);

			if(ModelState.IsValid)
			{
				item.Name = vm.Products.Name;
				item.Description = vm.Products.Description;
				item.Price = vm.Products.Price;
				item.Discount = vm.Products.Discount;
				return RedirectToAction("Index");
			}
			return View(vm);
		}
		
		
	}
}
