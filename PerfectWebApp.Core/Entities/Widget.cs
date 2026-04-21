
namespace PerfectWebApp.Core.Entities
{
    public class Widget
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public double Price { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
