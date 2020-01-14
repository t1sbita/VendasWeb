using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWeb.Models.Enums;

namespace VendasWeb.Models
{
    public class RegistroVendas
    {
        public int RegistroVendasId { get; set; }
        public DateTime DataVenda { get; set; }
        public Vendedor Vendedor { get; set; }
        public float ValorVenda { get; set; }
        public StatusVenda StatusVenda { get; set; }
        public RegistroVendas()
        {

        }

        public RegistroVendas(int registroVendasId, DateTime dataVenda, Vendedor vendedor, float valorVenda, StatusVenda statusVenda)
        {
            RegistroVendasId = registroVendasId;
            DataVenda = dataVenda;
            Vendedor = vendedor;
            ValorVenda = valorVenda;
            StatusVenda = statusVenda;

        }
    }
}
