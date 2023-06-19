using FrontEndProjetoFinalAtos.Models;
using FrontEndProjetoFinalAtos.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEndProjetoFinalAtos.Controllers
{
    public class CategoriaController : Controller
    {
        string BaseUrl = "http://localhost:5209/";

        public async Task<IActionResult> Index()
        {
            CategoriaViewModel model = new CategoriaViewModel();
            List<Categoria> categorias = new List<Categoria>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage resposta = await client.GetAsync("categoriacontroller/categorias");

            if (resposta.IsSuccessStatusCode)
            {
                var retorno = resposta.Content.ReadAsStringAsync().Result;
                categorias = JsonConvert.DeserializeObject<List<Categoria>>(retorno);
            }
            else
            {
                Console.WriteLine("Erro: " + resposta.StatusCode);
            }





            model.Categorias = categorias;
            return View(model);
        }

        public async Task<IActionResult> BuscarInativas()
        {
            CategoriaViewModel model = new CategoriaViewModel();
            List<Categoria> categorias = new List<Categoria>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage resposta = await client.GetAsync("categoriacontroller/categorias/inativas");

            if (resposta.IsSuccessStatusCode)
            {
                var retorno = resposta.Content.ReadAsStringAsync().Result;
                categorias = JsonConvert.DeserializeObject<List<Categoria>>(retorno);
            }
            else
            {
                Console.WriteLine("Erro: " + resposta.StatusCode);
            }

            model.Categorias = categorias;
            return View("Index", model);
        }

        public async Task<IActionResult> BuscarAtivas()
        {
            CategoriaViewModel model = new CategoriaViewModel();
            List<Categoria> categorias = new List<Categoria>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage resposta = await client.GetAsync("categoriacontroller/categorias/ativas");

            if (resposta.IsSuccessStatusCode)
            {
                var retorno = resposta.Content.ReadAsStringAsync().Result;
                categorias = JsonConvert.DeserializeObject<List<Categoria>>(retorno);
            }
            else
            {
                Console.WriteLine("Erro: " + resposta.StatusCode);
            }

            model.Categorias = categorias;
            return View("Index",model);
        }

        public async Task<IActionResult> CadastrarCategoria(CategoriaViewModel model)
        {
            Categoria categoria = new Categoria();
            categoria.Nome = model.Categoria.Nome;
            HttpClient client = new HttpClient();
            HttpResponseMessage respostaPost = await client.PostAsJsonAsync(BaseUrl + "categoriacontroller/categorias", categoria);
            return RedirectToAction("Index");


        }

        public async Task<IActionResult> AtualizarCategoria(CategoriaViewModel model)
        {
            Categoria categoria = new Categoria();
            categoria.Id = model.Categoria.Id;
            categoria.Nome = model.Categoria.Nome;
            categoria.Ativo = model.Categoria.Ativo;

            HttpClient client = new HttpClient();
            HttpResponseMessage respostaPut = await client.PutAsJsonAsync(BaseUrl + "categoriacontroller/categorias/" + categoria.Id, categoria);
            return RedirectToAction("Index");




        }
    }
}
