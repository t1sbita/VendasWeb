using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasWeb.Models
{
    public class RegistroVendas
    {
        public int RegistroVendasId { get; set; }
        public DateTime DataVenda { get; set; }
        public Vendedor Vendedor { get; set; }
        public decimal ValorVenda { get; set; }

        public RegistroVendas()
        {

        }

        public RegistroVendas(int registroVendasId, DateTime dataVenda, Vendedor vendedor, decimal valorVenda)
        {
            RegistroVendasId = registroVendasId;
            DataVenda = dataVenda;
            Vendedor = vendedor;
            ValorVenda = valorVenda;
        }
    }
}
