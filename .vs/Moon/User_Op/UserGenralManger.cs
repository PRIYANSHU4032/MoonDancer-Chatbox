using Moon.DTOs;
using Moon.Moon_BLL;

namespace Moon.User_Op
{
    public class UserGenralManger
    {
        public UserGenralManger() { }

        private readonly Genral_Oprations<User> _genral_Oprations;
        public UserGenralManger(Genral_Oprations<User> genral_Oprations) 
        {
            _genral_Oprations = genral_Oprations;
        }

        public Guid createUser(User user)
        {
            return _genral_Oprations.createUser(user);
        }

        public List<User> getALLUsers() { 
            return _genral_Oprations.getAllRecords();
        
        }

    }
}
