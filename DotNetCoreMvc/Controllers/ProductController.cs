using DotNetCoreMvc.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DotNetCoreMvc.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Create()
        
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create(Product product)
        {
            Repository.Create(product);
            return View("Thanks", product);
        }
        public IActionResult Display()
        {
            return View(Repository.AllProducts);
        }
        public IActionResult Edit(int id)
        {
            var ProductId = Repository.AllProducts.Where(pId => pId.Id == id).FirstOrDefault();
            if (ProductId != null)
            {
                return View(ProductId);
            }
            else
            {
                return View();
            }
        }
        [HttpPost]
        public IActionResult Edit(Product product,int id)
        {
            Repository.AllProducts.Where(product => product.Id == id).FirstOrDefault().Id = product.Id;
            Repository.AllProducts.Where(product => product.Id == id).FirstOrDefault().Name = product.Name;
            Repository.AllProducts.Where(product => product.Id == id).FirstOrDefault().Age = product.Age;
            return RedirectToAction("Display");
        }
        public IActionResult Delet(int empID)
        {
            Repository.Delete(empID);
            return RedirectToAction("Display");
        }
       
    
        public IActionResult Index(int id)
        {
            var All = Repository.AllProducts.Where(product => product.Id == id).FirstOrDefault();
            return View("Index",All);
        }
       
        

    }
}
