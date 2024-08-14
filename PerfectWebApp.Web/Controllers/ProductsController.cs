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
        private readonly SprocketRepository _sprocketRepository;

        public ProductsController(ILogger<ProductsController> logger, IWidgetRepository widgetRepository)
        {
            _logger = logger;
            _widgetRepository = widgetRepository;
            _sprocketRepository = new SprocketRepository(SprocketConnectionString);
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
            var sprockets = await _sprocketRepository.GetSprocketsAsync();
            Process(sprockets.ToList());
            return View(sprockets);
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
