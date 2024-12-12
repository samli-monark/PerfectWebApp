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

        private async void Process(List<Sprocket> l)
        {
            foreach (var s in l)
            {
                if (s.Description.Contains("flange"))
                {
                    // process flange
                    await Task.Delay(100);
                }
                else
                {
                    // process non-flange
                    s.ImageBytes = GetImg(s.ImageFile);
                }
            }
        }

        private byte[] GetImg(string imageFile)
        {
            // get image from file
            var st = new FileStream(imageFile, FileMode.Open);

            try
            {
                var buffer = new byte[st.Length];
                st.Read(buffer, 0, buffer.Length);
                return buffer;
            }
            catch
            {
                return Array.Empty<byte>();
            }
            finally
            {
                st.Dispose();
            }
        }
    }
}
