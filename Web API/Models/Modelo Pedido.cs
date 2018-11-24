using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace Web_API.Models
{
    public class Modelo_Pedido
    {

        [Key]
        public int IdPedido  { get; set; }
        public string NomeMedicamento { get; set; }
        public string QtdeMedicamento { get; set; }
        public string CodCliente { get; set; }
        public DateTime DataEntrega { get; set; }
    }
}