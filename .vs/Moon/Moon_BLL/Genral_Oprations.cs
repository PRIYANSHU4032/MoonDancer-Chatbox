using Moon.DTOs;
using Moon.IMongo;
using Moon.MongoOP;

namespace Moon.Moon_BLL
{
    public class Genral_Oprations<T> where T : class
    {

        private readonly IMongoDBManager _mongoDBManager;
        public Genral_Oprations(IMongoDBManager mongoDBManager)
        {
            _mongoDBManager = mongoDBManager;
        }
        public Genral_Oprations()
        {
            
        }
        public Guid createUser(User user)
        {
            user._id = Guid.NewGuid();
            _mongoDBManager.insertOneDocumnts(user);
            return user._id;
        }
        public List<T> getAllRecords()
        {
            return _mongoDBManager.getAllDocuments<T>();
        }

    }
}
