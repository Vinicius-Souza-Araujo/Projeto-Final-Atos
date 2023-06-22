using FrontEndProjetoFinalAtos.Models;
using FrontEndProjetoFinalAtos.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEndProjetoFinalAtos.Controllers
{
    public class ProdutoController : Controller
    {
        string BaseUrl = "http://localhost:5209/";

        public async Task<IActionResult> Index()
        {
            ProdutoViewModel model = new ProdutoViewModel();
            List<Produto> produtos = new List<Produto>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage resposta = await client.GetAsync("produtocontroller/produtos");

            if (resposta.IsSuccessStatusCode)
            {
                var retorno = resposta.Content.ReadAsStringAsync().Result;
                produtos = JsonConvert.DeserializeObject<List<Produto>>(retorno);
            }
            else
            {
                Console.WriteLine("Erro: " + resposta.StatusCode);
            }

            
            List<Categoria> categorias = new List<Categoria>();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage respostaCategoriaAtivas = await client.GetAsync("categoriacontroller/categorias/ativas");

            if (respostaCategoriaAtivas.IsSuccessStatusCode)
            {
                var retorno = respostaCategoriaAtivas.Content.ReadAsStringAsync().Result;
                categorias = JsonConvert.DeserializeObject<List<Categoria>>(retorno);
            }
            else
            {
                Console.WriteLine("Erro: " + respostaCategoriaAtivas.StatusCode);
            }

            model.Categorias = categorias;
            model.Produtos = produtos;
            return View(model);
        }

        public async Task<IActionResult> BuscarInativos()
        {
            ProdutoViewModel model = new ProdutoViewModel();
            List<Produto> produtos = new List<Produto>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage resposta = await client.GetAsync("produtocontroller/produtos/inativos");

            if (resposta.IsSuccessStatusCode)
            {
                var retorno = resposta.Content.ReadAsStringAsync().Result;
                produtos = JsonConvert.DeserializeObject<List<Produto>>(retorno);
            }
            else
            {
                Console.WriteLine("Erro: " + resposta.StatusCode);
            }


            List<Categoria> categorias = new List<Categoria>();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage respostaCategoriaAtivas = await client.GetAsync("categoriacontroller/categorias/ativas");

            if (respostaCategoriaAtivas.IsSuccessStatusCode)
            {
                var retorno = respostaCategoriaAtivas.Content.ReadAsStringAsync().Result;
                categorias = JsonConvert.DeserializeObject<List<Categoria>>(retorno);
            }
            else
            {
                Console.WriteLine("Erro: " + respostaCategoriaAtivas.StatusCode);
            }

            model.Categorias = categorias;
            model.Produtos = produtos;
            return View("Index",model);
        }

        public async Task<IActionResult> BuscarAtivos()
        {
            ProdutoViewModel model = new ProdutoViewModel();
            List<Produto> produtos = new List<Produto>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage resposta = await client.GetAsync("produtocontroller/produtos/ativos");

            if (resposta.IsSuccessStatusCode)
            {
                var retorno = resposta.Content.ReadAsStringAsync().Result;
                produtos = JsonConvert.DeserializeObject<List<Produto>>(retorno);
            }
            else
            {
                Console.WriteLine("Erro: " + resposta.StatusCode);
            }

            List<Categoria> categorias = new List<Categoria>();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage respostaCategoriaAtivas = await client.GetAsync("categoriacontroller/categorias/ativas");

            if (respostaCategoriaAtivas.IsSuccessStatusCode)
            {
                var retorno = respostaCategoriaAtivas.Content.ReadAsStringAsync().Result;
                categorias = JsonConvert.DeserializeObject<List<Categoria>>(retorno);
            }
            else
            {
                Console.WriteLine("Erro: " + respostaCategoriaAtivas.StatusCode);
            }

            model.Categorias = categorias;
            model.Produtos = produtos;
            return View("Index", model);
        }

        public async Task<IActionResult> CadastrarProduto(ProdutoViewModel model)
        {
            Produto produto = new Produto();
            produto.Nome = model.Produto.Nome;
            produto.Valor = model.Produto.Valor;
            produto.FkCategoria = model.Produto.FkCategoria;
          

            HttpClient client = new HttpClient();
            HttpResponseMessage respostaPost = await client.PostAsJsonAsync(BaseUrl + "produtocontroller/produtos", produto);
            return RedirectToAction("Index");
        }

         public async Task<IActionResult> AtualizarProduto(ProdutoViewModel model)
        {
            Produto produto = new Produto();
            produto.Id = model.Produto.Id;
            produto.Nome = model.Produto.Nome;
            produto.Valor = model.Produto.Valor;
            produto.FkCategoria = model.Produto.FkCategoria;
            produto.Ativo = model.Produto.Ativo;

            HttpClient client = new HttpClient();
            HttpResponseMessage respostaPut = await client.PutAsJsonAsync(BaseUrl + "produtocontroller/produtos/" + produto.Id, produto);
            return RedirectToAction("Index");
        }

    }
}
