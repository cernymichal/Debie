using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Debie.Models;
using Debie.Models.DB;
using Debie.Services;
using Debie.Services.Repositories;

namespace Debie.Controllers {
    public class ProductController : Controller {
        private readonly IProductRepository _ProductRepo;
        private readonly IOrderService _OrderService;

        public ProductController(IProductRepository productRepo, IOrderService orderService) {
            _ProductRepo = productRepo;
            _OrderService = orderService;
        }

        public IActionResult List() {
            return View(_ProductRepo.GetAll());
        }

        public IActionResult Detail(int id) {
            return View(_ProductRepo.GetByID(id));
        }

        [HttpPost]
        public IActionResult AddToOrder(int id, int count, string redirect = null) {
            _OrderService.AddProduct(id, count);

            _OrderService.SaveCurrentOrder();

            if (redirect == "on")
                return RedirectToAction("Index", "Cart");

            return RedirectToAction("Detail", new { id });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
