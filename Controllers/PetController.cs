using AdoteUmPet.ExternalAPIs;
using AdoteUmPet.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace AdoteUmPet.Controllers
{

    public class PetController : Controller
    {
        private readonly IApi dogApi;
        private readonly IApi catApi;

        public PetController()
        {
            dogApi = new DogApi();
            catApi = new CatApi();
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Gerador()
        {
            return View();
        }
        public ActionResult Cadastro()
        {
            return View();
        }
        public ActionResult Edita()
        {
            return View();
        }

        public async Task<ActionResult> getImage(TipoDePet type)
        {
            string resposta = null;
            if(type == TipoDePet.Dog) {
                resposta = await dogApi.RandomImage();
            }
            else if(type == TipoDePet.Cat) {
                resposta = await catApi.RandomImage();
            }

            return View("Gerador", resposta);

        }

        public async Task<ActionResult> PartialGetImage(TipoDePet type)
        {
            string resposta = null;
            if (type == TipoDePet.Dog)
            {
                resposta = await dogApi.RandomImage();
            }
            else if (type == TipoDePet.Cat)
            {
                resposta = await catApi.RandomImage();
            }

            return PartialView("PartialIcone", resposta);

        }


    }
}
