using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DemoMvcApi.Models;
using DemoMvcApi.ResponseModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoMvcApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductApiController : ControllerBase
    {
        private readonly DemoDbContext _db;

        public ProductApiController(DemoDbContext db)
        {
            _db = db;
        }

        [HttpGet]
        [Route("get-all-product")]
        public List<ProductResponseModel> GetAllProduct()
        {
            var StatusActive = new int[] { 1 };
            var product = _db.Products.Where(x => StatusActive.Contains((int)x.Status)).Select(x => new ProductResponseModel {
                Name = x.Name,
                Description = x.Description
            }).ToList();
            return product;
        }

        [HttpPost]
        [Route("add-new-product")]
        public Product AddNewProduct(Product model)
        {
            if (model != null)
            {
                _db.Products.Add(model);
                _db.SaveChanges();
                return model;
            }
            return null;
        }
    }
}