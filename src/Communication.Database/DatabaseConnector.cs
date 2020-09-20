using MongoDB.Driver;

namespace Gelp.SmartHome.Communication.Database
{
    /// <summary>
    /// Connector to the database
    /// </summary>
    public class DatabaseConnector
    {
        /// <summary>
        /// Connects to the database
        /// </summary>
        /// <returns></returns>
        public IMongoDatabase Connect()
        {
            var mongoDbClient = new MongoClient();
            return mongoDbClient.GetDatabase("Smarthome");
        }
    }
}
