using AdoteUmPet.Models;
using Microsoft.EntityFrameworkCore;

namespace AdoteUmPet.Data
{
    public class PetContext : DbContext
    {
        public PetContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Pet> Pets { get; set; }
    }
}
