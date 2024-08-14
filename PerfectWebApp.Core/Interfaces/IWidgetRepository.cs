
using PerfectWebApp.Core.Entities;

namespace PerfectWebApp.Core.Interfaces
{
    public interface IWidgetRepository
    {
        IEnumerable<Widget> GetWidgets();
        Widget GetWidgetById(int id);
        void AddWidget(Widget widget);
        void UpdateWidget(Widget widget);
        void DeleteWidget(int id);
    }
}
