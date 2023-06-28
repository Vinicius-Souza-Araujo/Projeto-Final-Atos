using FrontEndProjetoFinalAtos.Models;
using FrontEndProjetoFinalAtos.ViewsModels;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace FrontEndProjetoFinalAtos.Controllers
{
    public class PedidoGarcomController : Controller
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
            HttpResponseMessage respostaPedidosPreparados = await client.GetAsync("pedidocontroller/pedidos/preparado");

            if (respostaPedidosPreparados.IsSuccessStatusCode)
            {
                var retorno = respostaPedidosPreparados.Content.ReadAsStringAsync().Result;
                pedidos = JsonConvert.DeserializeObject<List<Pedido>>(retorno);
            }
            else
            {
                Console.WriteLine("Erro: " + respostaPedidosPreparados.StatusCode);
            }

            model.Pedidos = pedidos;
            return View(model);
        }

        public async Task<IActionResult> AtualizarAndamento(PedidoViewModel model)
        {
            Pedido pedido = new Pedido();
            pedido.Andamento = "concluído";

            HttpClient client = new HttpClient();
            HttpResponseMessage respostaPut = await client.PutAsJsonAsync(BaseUrl + "pedidocontroller/pedidos/" + model.Pedido.Id, pedido);
            return RedirectToAction("Index");
        }
    }
}
