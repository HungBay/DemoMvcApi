using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoMvcApi.Models;
using Microsoft.AspNetCore.Mvc;

namespace DemoMvcApi.Controllers
{
    public class ProductController : Controller
    {
        private readonly DemoDbContext _db;

        public ProductController(DemoDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View(_db.Products.ToList());
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost, ActionName("Create")]
        public IActionResult CreateProduct(Product model)
        {
            var product = new Product() { Name = model.Name, Description = model.Description };
            _db.Products.Add(product);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}