using Core.Component.Library.SQL;

namespace Weelo.Repository
{
    public class AppDatabase : IDatabase
    {
        public AppDatabase(string cnn)
        {
            this.ConnectionString = cnn;
        }
    }
}