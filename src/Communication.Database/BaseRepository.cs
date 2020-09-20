using Gelp.SmartHome.Common.Data;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Linq;
using System.Threading.Tasks;

namespace Gelp.SmartHome.Business.Database
{
    /// <summary>
    /// Repository containing default-implementations for communicating with the database.
    /// </summary>
    /// <typeparam name="T">Corresponding data-class for collections</typeparam>
    public abstract class BaseRepository<T> where T : BaseObject
    {
        protected readonly DatabaseConnector DatabaseConnector; // Connects to the database
        protected readonly string CollectionName; // Name of the collection to connect to

        /// <summary>
        /// Constructor for inherited repositories
        /// </summary>
        /// <param name="collectionName">Name of the collection to connect to</param>
        public BaseRepository(string collectionName)
        {
            DatabaseConnector = new DatabaseConnector();
            CollectionName = collectionName;
        }

        /// <summary>
        /// Creates a new document in the collection with an random-generated id
        /// </summary>
        /// <param name="entity">Entity to add to the collection</param>
        /// <returns></returns>
        public virtual async Task<bool> Create(T entity)
        {
            // Gets the correct collection from it to work with
            var collection = GetCollection();

            // inserts the entity
            await collection.InsertOneAsync(entity);

            return true;
        }

        /// <summary>
        /// Reads a specific document in the collection based on the id
        /// </summary>
        /// <param name="id">Id to search for in the collection</param>
        /// <returns>Entity of type <see cref="T"/> corresponding with the given id</returns>
        public virtual T Read(ObjectId id)
        {
            // Gets the correct collection from it to work with
            var collection = GetCollection();

            // Queries through the collection and searches for the correct document which corresponds with the given id
            T result = collection.AsQueryable().Where(e => e.Id == id).First();

            return result;
        }

        /// <summary>
        /// Updates an existing document in the collection
        /// </summary>
        /// <param name="id">id to search for in the collection</param>
        /// <param name="entity">Entity which replaces the old one</param>
        /// <returns>Indicates whether the entity got updated successfully</returns>
        public virtual async Task<bool> Update(ObjectId id, T entity)
        {
            // Gets the correct collection from it to work with
            var collection = GetCollection();

            // Sets the given id as a filter to search for in the colletion.
            var filter = Builders<T>.Filter.Eq("Id", id);

            // Replaces the existing document with the new one based on the id
            var result = await collection.ReplaceOneAsync(filter, entity);

            return result.IsAcknowledged;
        }

        /// <summary>
        /// Removes an existing entity in the collection
        /// </summary>
        /// <param name="id">Id to search for</param>
        /// <returns>Indicates whether the entity got deleted successfully</returns>
        public virtual async Task<bool> Remove(ObjectId id)
        {
            // Gets the correct collection from it to work with
            var collection = GetCollection();

            // Sets the given id as a filter to search for in the colletion.
            var filter = Builders<T>.Filter.Eq("Id", id);

            // Deletes the ecisting document based on the id
            var result = await collection.DeleteOneAsync(filter);

            return result.IsAcknowledged;
        }

        /// <summary>
        /// Gets the correct collection from the database
        /// </summary>
        /// <returns>Correct collection</returns>
        protected IMongoCollection<T> GetCollection()
        {
            IMongoDatabase database = DatabaseConnector.Connect();

            return database.GetCollection<T>(CollectionName);
        }
    }
}
