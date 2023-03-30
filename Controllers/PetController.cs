using AdoteUmPet.ExternalAPIs;
using AdoteUmPet.Models;
using AdoteUmPet.Repos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Drawing;
using System.Net.Http.Json;

namespace AdoteUmPet.Controllers
{

    public class PetController : Controller
    {
        private readonly IApi externalApi;
        private readonly IPetRepositorio _petRepositorio;

        public PetController(IPetRepositorio petRepositorio)
        {
            this._petRepositorio = petRepositorio;
            externalApi = new DogApi();
         
        }

        public ActionResult Index()
        {
            var lista = _petRepositorio.ListAll();
            return View(lista);
        }

        public ActionResult Gerador()
        {
            return View();
        }
        public ActionResult Cadastro()
        {
            return View();
        }
        public ActionResult Administracao()
        {
            var lista = _petRepositorio.ListAll();
            return View(lista);
        }

        public ActionResult Atualizar(int id)
        {
            var pet = _petRepositorio.GetById(id);
            return View(pet);
        }

        public ActionResult Excluir(int id)
        {
            var pet = _petRepositorio.GetById(id);
            return View(pet);
        }

        public async Task<ActionResult> getImage(TipoDePet type)
        {
            string resposta = await externalApi.RandomImage(type);
          

            return View("Gerador", resposta);

        }

        public async Task<ActionResult> PartialGetImage(TipoDePet type)
        {
            string resposta = await externalApi.RandomImage(type);

            return PartialView("PartialIcone", resposta);

        }

        [HttpPost]
        public async Task<ActionResult> Cadastro(Pet pet)
        {
            Pet resposta;
           
            resposta = await _petRepositorio.Create(pet, externalApi);
            
            
            if(resposta != null)
            {
                return RedirectToAction("Index");
            }
            return BadRequest();
        }

        [HttpPost]
        public IActionResult Atualizar(Pet pet)
        {
            var resposta = _petRepositorio.Update(pet);
            if (resposta != null)
            {
                return RedirectToAction("Administracao");
            }
            return BadRequest();
        }

        public IActionResult Deletar(int id)
        {
            var resposta = _petRepositorio.Delete(id);
            if (resposta)
            {
                return RedirectToAction("Administracao");
            }
            return BadRequest();
        }


    }
}
