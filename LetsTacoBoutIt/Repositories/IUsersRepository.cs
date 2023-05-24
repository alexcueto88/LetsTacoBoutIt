using LetsTacoBoutIt.Models;

namespace LetsTacoBoutIt.Repositories
{
    public interface IUsersRepository
    {
        void Delete(int id);
        List<Users> GetAll();
        Users GetUserById(int id);
        void Insert(Users user);
        void Update(Users user);
        void UpdateUser(Users user);
    }
}