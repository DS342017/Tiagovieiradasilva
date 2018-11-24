using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoMVC.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            Models.Modelo_Pedido modelo_Pedido = new Models.Modelo_Pedido()
                {
                  IdPedido = "1",
                  NomeMedicamento = "acnova",
                  QtdeMedicamento = "03",
                  CodCliente= "001",
                  DataEntrega= "08/05/1989",
                };

            ViewData["chave1"] = "textoqualquer";
            ViewData["chave2"] = 123;
            ViewData["chave3"] = modelo_Pedido.nome;
            ViewBag.chave1 = "texto do ViewBag";
            ViewBag.numero = 234;
            ViewBag.IdPedido = modelo_Pedido.IdPedido;
            return View(modelo_Pedido);
        }
    }
}