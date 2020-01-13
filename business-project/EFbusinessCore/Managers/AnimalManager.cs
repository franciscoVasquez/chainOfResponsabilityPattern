using System.Collections.Generic;
using  EFBusinessCore.Model;

namespace EFBusinessCore.Managers
{
    public class AnimalManager: IDataRepository<Animal>
    {
        public IEnumerable<Animal> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public Animal Get(long id)
        {
            throw new System.NotImplementedException();
        }

        public void Add(Animal entity)
        {
            throw new System.NotImplementedException();
        }

        public void Update(Animal dbEntity, Animal entity)
        {
            throw new System.NotImplementedException();
        }

        public void Delete(Animal entity)
        {
            throw new System.NotImplementedException();
        }
    }
}