using Microsoft.AspNetCore.Mvc;
using PerfectWebApp.Core.Interfaces;

namespace PerfectWebApp.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IWidgetRepository _widgetRepository;

        public ProductsController(ILogger<ProductsController> logger, IWidgetRepository widgetRepository)
        {
            _logger = logger;
            _widgetRepository = widgetRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Widgets()
        {
            var widgets = _widgetRepository.GetAllWidgets().Result;
            return View(widgets);
        }

        public async void LogWidgetCount()
        {
            var widgets = await _widgetRepository.GetAllWidgets();
            _logger.LogInformation("Total widgets: " + widgets.Count);
        }
    }
}
