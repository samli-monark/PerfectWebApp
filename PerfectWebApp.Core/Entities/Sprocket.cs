namespace PerfectWebApp.Core.Entities
{
    public class Sprocket
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string ImageFile { get; set; } = string.Empty;
        public byte[] ImageBytes { get; set; } = Array.Empty<byte>();
    }
}
