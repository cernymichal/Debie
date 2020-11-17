using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

using Debie.Models;
using Debie.Models.DB;
using Debie.Services.Repositories;

namespace Debie.Controllers {
    public class BlogController : Controller {
        private readonly IArticleRepository _ArticleRepo;

        public BlogController(IArticleRepository articleRepo) {
            _ArticleRepo = articleRepo;
        }

        public IActionResult List() {
            return View(_ArticleRepo.GetAll());
        }

        public IActionResult Detail(int id) {
            return View(_ArticleRepo.GetByID(id));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error() {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
