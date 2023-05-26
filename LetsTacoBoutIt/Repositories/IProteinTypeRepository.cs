using LetsTacoBoutIt.Models;

namespace LetsTacoBoutIt.Repositories
{
    public interface IProteinTypeRepository
    {
        void Delete(int id);
        List<ProteinType> GetAll();
        ProteinType GetById(int id);
        void Insert(ProteinType protein);
        void UpdateProtein(ProteinType protein);
    }
}