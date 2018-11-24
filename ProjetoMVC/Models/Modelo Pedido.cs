using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjetoMVC.Models
{
    public class Modelo_Pedido
    {
        [Key]
        public string IdPedido { get; set; }
        public string NomeMedicamento { get; set; }
        public string QtdeMedicamento { get; set; }
        public string CodCliente { get; set; }

        [DataType(DataType.Date)]
        public DateTime DataEntrega { get; set; }
        
    }
}