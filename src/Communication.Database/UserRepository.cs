using Gelp.SmartHome.Common.Data;
using MongoDB.Driver;
using System.Linq;

namespace Gelp.SmartHome.Communication.Database
{
    /// <summary>
    /// Repository for <see cref="User"/>
    /// </summary>
    public class UserRepository : BaseRepository<User>
    {
        /// <summary>
        /// Constructor
        /// </summary>
        public UserRepository() : base("User")
        {
        }

        /// <summary>
        /// Tries to find a user based on the credentials
        /// </summary>
        /// <param name="username">Username to search for</param>
        /// <param name="password">Password to search for</param>
        /// <returns>User based on the credentials</returns>
        public User FindUserByCredentials(string username, string password)
        {
            // Gets the correct collection from it to work with
            var collection = GetCollection();

            // Queries through the collection and searches for the correct document which corresponds with the given id
            User user = collection.AsQueryable().Where(u => u.Username == username && u.Password == password).First();

            return user;
        }
    }
}
