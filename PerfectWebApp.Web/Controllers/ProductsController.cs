using Microsoft.AspNetCore.Mvc;
using PerfectWebApp.Core.Entities;
using PerfectWebApp.Core.Interfaces;
using PerfectWebApp.Data.Repositories;

namespace PerfectWebApp.Web.Controllers
{
    public class ProductsController : Controller
    {
        private const string SprocketConnectionString = "Server=...";
        private readonly ILogger<ProductsController> _logger;
        private readonly IWidgetRepository _widgetRepository;
        private readonly SprocketRepository _sp;

        public ProductsController(ILogger<ProductsController> logger, IWidgetRepository widgetRepository)
        {
            _logger = logger;
            _widgetRepository = widgetRepository;
            _sp = new SprocketRepository(SprocketConnectionString);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Widgets()
        {
            var widgets = _widgetRepository.GetWidgets();
            return View(widgets);
        }

        public async Task<IActionResult> Sprockets()
        {
            var s = await _sp.GetSprocketsAsync();
            Process(s.ToList());
            return View(s);
        }

        private async void Process(List<Sprocket> sprockets)
        {
            foreach (var s in sprockets)
            {
                if (s.Description.Contains("flange"))
                {
                    // process flange
                    await Task.Delay(100);
                }
                else
                {
                    // process sprocket
                    await Task.Delay(500);
                }
            }
        }
    }
}
