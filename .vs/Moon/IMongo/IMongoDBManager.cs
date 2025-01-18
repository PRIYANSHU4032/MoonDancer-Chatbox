namespace Moon.IMongo
{
    public interface IMongoDBManager
    {
        List<T> getAllDocuments<T>() where T : class;
        T GetDocument<T>(Guid id) where T : class;

        void insertAllDocumnets<T>(List<T> docs) where T : class;
        void insertOneDocumnts<T>(T docs) where T : class;
    }
}
