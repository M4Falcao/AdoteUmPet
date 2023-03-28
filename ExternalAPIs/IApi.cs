using AdoteUmPet.Models;

namespace AdoteUmPet.ExternalAPIs
{
    public interface IApi
    {
        Task<string> RandomImage();
    }
}
