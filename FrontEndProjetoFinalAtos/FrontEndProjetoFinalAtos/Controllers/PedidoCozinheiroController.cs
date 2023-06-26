using FrontEndProjetoFinalAtos.Models;
using FrontEndProjetoFinalAtos.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEndProjetoFinalAtos.Controllers
{
    public class PedidoCozinheiroController : Controller
    {
        string BaseUrl = "http://localhost:5209/";
        

        public async Task<IActionResult> Index()
        {
            PedidoViewModel model = new PedidoViewModel();
            List<Pedido> pedidos = new List<Pedido>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage respostaPedidossEmAndamento = await client.GetAsync("pedidocontroller/pedidos/emAndamento");

            if (respostaPedidossEmAndamento.IsSuccessStatusCode)
            {
                var retorno = respostaPedidossEmAndamento.Content.ReadAsStringAsync().Result;
                pedidos = JsonConvert.DeserializeObject<List<Pedido>>(retorno);
            }
            else
            {
                Console.WriteLine("Erro: " + respostaPedidossEmAndamento.StatusCode);
            }

            model.Pedidos = pedidos;
            return View(model);
        }

        public async Task<IActionResult> BuscarItensPedidos(int id)
        {
            PedidoViewModel model = new PedidoViewModel();
            List<ItensPedido> itens = new List<ItensPedido>();
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(BaseUrl);
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage respostaItensPedido = await client.GetAsync("itenspedidocontroller/itenspedidos/" + id);


            if (respostaItensPedido.IsSuccessStatusCode)
            {
                var retorno = respostaItensPedido.Content.ReadAsStringAsync().Result;
                itens = JsonConvert.DeserializeObject<List<ItensPedido>>(retorno);
            }
            else
            {
                Console.WriteLine("Erro: " + respostaItensPedido.StatusCode);
            }

            return Json(itens);

        }
    }
}
