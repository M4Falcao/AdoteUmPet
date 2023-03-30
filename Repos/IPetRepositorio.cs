using AdoteUmPet.ExternalAPIs;
using AdoteUmPet.Models;

namespace AdoteUmPet.Repos
{
    public interface IPetRepositorio
    {
        public Task<Pet> Create(Pet pet, IApi api);
        public Pet Update(Pet pet);
        public List<Pet> ListAll();
        public Pet GetById(int id);
        public bool Delete(int id);

    }
}
