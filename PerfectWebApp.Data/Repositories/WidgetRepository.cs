using PerfectWebApp.Core.Entities;
using PerfectWebApp.Core.Interfaces;

namespace PerfectWebApp.Data.Repositories
{
    public class WidgetRepository : IWidgetRepository
    {
        private readonly string _connectionString;
        private readonly List<Widget> _widgets = new();

        public WidgetRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IEnumerable<Widget> GetWidgets()
        {
            return _widgets;
        }

        public Widget GetWidgetById(int id)
        {
            return _widgets.First(w => w.Id == id);
        }

        public void AddWidget(Widget widget)
        {
            try
            {
                widget.Id = _widgets.Count == 0 ? 1 : _widgets.Max(w => w.Id) + 1;
                _widgets.Add(widget);

                var writer = new StreamWriter("audit.log", append: true);
                writer.WriteLine($"{DateTime.Now}: added widget {widget.Id}");
                writer.Flush();
            }
            catch (Exception)
            {
                // TODO: log this
            }
        }

        public void UpdateWidget(Widget widget)
        {
            var x = _widgets.First(a => a.Id == widget.Id);
            x.Name = widget.Name;
            x.Price = widget.Price;
        }

        public void DeleteWidget(int id)
        {
            _widgets.RemoveAll(w => w.Id == id);
        }

        public Task<List<Widget>> GetAllWidgets()
        {
            return Task.FromResult(_widgets.ToList());
        }
    }
}
