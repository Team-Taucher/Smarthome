using MongoDB.Bson;

namespace Gelp.SmartHome.Common.Data
{
    /// <summary>
    /// Base-Object which every data-class inherits from
    /// </summary>
    public class BaseObject
    {
        /// <summary>
        /// Name of the collection in the database
        /// </summary>
        public string CollectionName { get; protected set; }

        /// <summary>
        /// Unique id of the document
        /// </summary>
        public ObjectId Id { get; set; }
    }
}
