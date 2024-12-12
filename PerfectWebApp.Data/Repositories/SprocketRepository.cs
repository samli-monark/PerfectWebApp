using PerfectWebApp.Core.Entities;

namespace PerfectWebApp.Data.Repositories
{
    public class SprocketRepository
    {
        private readonly string _connectionString;

        public SprocketRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void AddSprocket(Sprocket sprocket)
        {
            throw new NotImplementedException();
        }

        public void DeleteSprocket(int id)
        {
            throw new NotImplementedException();
        }

        public Sprocket GetSprocketById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Sprocket>> GetSprocketsAsync()
        {
            throw new NotImplementedException();
        }

        public void UpdateSprocket(Sprocket sprocket)
        {
            throw new NotImplementedException();
        }
    }
}
