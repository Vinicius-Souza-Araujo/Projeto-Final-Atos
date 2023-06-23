using FrontEndProjetoFinalAtos.Models;
using FrontEndProjetoFinalAtos.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEndProjetoFinalAtos.Controllers
{
    
    public class PedidoController : Controller
    {
        string BaseUrl = "http://localhost:5209/";
       
        public async Task<IActionResult> Index()
        {
            PedidoViewModel model = new PedidoViewModel();
            List<Produto> produtos = new List<Produto>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage respostaProdutosAtivos = await client.GetAsync("produtocontroller/produtos/ativos");

            if (respostaProdutosAtivos.IsSuccessStatusCode)
            {
                var retorno = respostaProdutosAtivos.Content.ReadAsStringAsync().Result;
                produtos = JsonConvert.DeserializeObject<List<Produto>>(retorno);
            }
            else
            {
                Console.WriteLine("Erro: " + respostaProdutosAtivos.StatusCode);
            }

            model.Produtos = produtos;
            return View(model);
        }

       
        public async Task<IActionResult> AdicionarItemPedido(string cliente, int mesa, List<ItensPedido> dados)
        {
            
            Pedido pedido = new Pedido();
            pedido.Cliente = cliente;
            pedido.Mesa = mesa;
            pedido.ItensPedidos = dados;
            pedido.Andamento = "em andamento";

            HttpClient client = new HttpClient();
            HttpResponseMessage respostaPost = await client.PostAsJsonAsync(BaseUrl + "pedidocontroller/pedidos", pedido);
            return RedirectToAction("Index");
        }
    }


    

}
