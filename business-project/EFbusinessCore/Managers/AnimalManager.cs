using System.Collections.Generic;
using System.Threading.Tasks;
using  EFBusinessCore.Model;
using Microsoft.EntityFrameworkCore;

namespace EFBusinessCore.Managers
{
    public class AnimalManager: IDataRepository<Animal>
    {
        private readonly AnimalContext _animalContext;

        public AnimalManager(AnimalContext animalContext)
        {
            _animalContext = animalContext;
        }

        public async Task<IEnumerable<Animal>> GetAll()
        {
            return await _animalContext.Animals.ToListAsync();
        }

        public async Task<Animal> Get(long id)
        {
            return await _animalContext.Animals
                .FirstOrDefaultAsync(a => a.AnimalId == id);
        }

        public async Task Add(Animal entity)
        {
            _animalContext.Animals.Add(entity);
            await _animalContext.SaveChangesAsync();
        }

        public async Task Update(Animal currentVersion, Animal newVersion)
        {
            currentVersion.Food = newVersion.Food;
            currentVersion.Specie = newVersion.Specie;
            await _animalContext.SaveChangesAsync();
        }

        public async Task Delete(Animal entity)
        {
            _animalContext.Remove(entity);
            await _animalContext.SaveChangesAsync();
        }
    }
}