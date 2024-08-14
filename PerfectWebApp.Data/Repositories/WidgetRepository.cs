using PerfectWebApp.Core.Entities;
using PerfectWebApp.Core.Interfaces;

namespace PerfectWebApp.Data.Repositories
{
    public class WidgetRepository : IWidgetRepository
    {
        private readonly string _connectionString;

        public WidgetRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddWidget(Widget widget)
        {
            throw new NotImplementedException();
        }

        public void DeleteWidget(int id)
        {
            throw new NotImplementedException();
        }

        public Widget GetWidgetById(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Widget> GetWidgets()
        {
            throw new NotImplementedException();
        }

        public void UpdateWidget(Widget widget)
        {
            throw new NotImplementedException();
        }
    }
}
