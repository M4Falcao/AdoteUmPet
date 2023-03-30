using AdoteUmPet.Data;
using AdoteUmPet.ExternalAPIs;
using AdoteUmPet.Models;

namespace AdoteUmPet.Repos
{
    public class PetRepositorio : IPetRepositorio
    {
        private readonly PetContext _context;
 
        public PetRepositorio(PetContext context)
        {
            _context = context;
        }

        public async Task<Pet> Create(Pet pet, IApi api)
        {
            
            pet.Imagem = await api.RandomImage(pet.Tipo);
            
            _context.Pets.Add(pet);
            _context.SaveChanges();
            return pet;
        }

        public bool Delete(int id)
        {
            var pet = this.GetById(id);
            if(pet != null)
            {
                _context.Pets.Remove(pet);
                _context.SaveChanges();
                return true;

            }
            return false;
        }

        public Pet GetById(int id)
        {
            return _context.Pets.FirstOrDefault(x => x.Id == id);
        }

        public List<Pet> ListAll()
        {
            return _context.Pets.ToList();
        }

        public Pet Update(Pet pet)
        {
            var dbPet = this.GetById(pet.Id); 
            if(dbPet != null) {
                dbPet.Tipo = pet.Tipo;
                dbPet.Descricao = pet.Descricao;
                dbPet.Nome = pet.Nome;
                _context.Pets.Update(dbPet);
                _context.SaveChanges();
                return dbPet;
            }
            return null;
        }
    }
}
