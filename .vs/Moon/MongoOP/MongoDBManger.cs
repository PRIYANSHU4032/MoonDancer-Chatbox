using MongoDB.Driver;
using Moon.IMongo;

namespace Moon.MongoOP
{
    public class MongoDBManger : IMongoDBManager
    {
        private IMongoClient mongoClient;
        private readonly IMongoDatabase _database;

        public MongoDBManger(IMongoClient mongoClient, string databaseName)
        {
            this.mongoClient = mongoClient;
            _database = mongoClient.GetDatabase(databaseName);
        }

        public MongoDBManger()
        {
        }

        public List<T> getAllDocuments<T>() where T : class
        {
            var collection = _database.GetCollection<T>(typeof(T).Name);
            return collection.Find(FilterDefinition<T>.Empty).ToList();
        }

        public T GetDocument<T>(Guid id) where T : class
        {
            var collection = _database.GetCollection<T>(typeof(T).Name);
            var filter = Builders<T>.Filter.Eq("_id", id);
            return collection.Find(filter).FirstOrDefault();
        }

        public void insertAllDocumnets<T>(List<T> docs) where T : class
        {
            if (docs == null || !docs.Any())
            {
                throw new ArgumentException("The document list is empty or null.", nameof(docs));
            }
            var collection = _database.GetCollection<T>(typeof(T).Name);
            collection.InsertMany(docs);
        }

        public void insertOneDocumnts<T>(T docs) where T : class
        {
            if (docs == null)
            {
                throw new ArgumentException("The document is empty or null.", nameof(docs));
            }
            var collection = _database.GetCollection<T>(typeof(T).Name);
            collection.InsertOne(docs);
        }
    }
}
