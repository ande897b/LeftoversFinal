using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheLeftOversClubTest.Models;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;
using Newtonsoft.Json;
using System.Diagnostics;
using Microsoft.Extensions.Logging;
using System.Net;
using System.Text;

namespace TheLeftOversClubTest.Controllers
{
    public class ProductsController : Controller
    {
        private readonly TheLeftOversClubTestContext _context;
        private readonly ILogger _logger;
        private readonly WebClient webClient = new WebClient();
        private readonly string urlApi = "https://localhost:44394/api/values/";

        public ProductsController(TheLeftOversClubTestContext context, ILogger<ProductsController> logger)
        {
            _context = context;
            _logger = logger;
        }
        public IActionResult Index()
        {
            _logger.LogInformation("\nEn person   har besøgt produkt siden!\n");

            byte[] myDataBuffer = webClient.DownloadData(urlApi);
            string downloadedString = Encoding.UTF8.GetString(myDataBuffer);

            var products = JsonConvert.DeserializeObject<List<Product>>(downloadedString);

            return View(products);
        }
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            byte[] myDataBuffer = webClient.DownloadData(urlApi +  id);
            string downloadedString = Encoding.UTF8.GetString(myDataBuffer);

            var product = JsonConvert.DeserializeObject<Product>(downloadedString);

            return View(product);
        }
        private bool ProductExists(int id)
        {
            return _context.Product.Any(e => e.ProductID == id);
        }

    }

}

