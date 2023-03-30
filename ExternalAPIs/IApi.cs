using AdoteUmPet.Models;

namespace AdoteUmPet.ExternalAPIs
{
    public interface IApi
    {
        IApi NextApi { get; set; }
        Task<string> RandomImage(TipoDePet type);
    }
}
