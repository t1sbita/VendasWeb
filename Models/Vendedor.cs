using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasWeb.Models
{
    public class Vendedor
    {
        public int VendedorId { get; set; }
        public string VendedorNome { get; set; }
        public string VendedorEmail { get; set; }
        public DateTime VendedorAniversario { get; set; }
        public decimal VendedorSalario { get; set; }
        public Filial Filial { get; set; }

        public Vendedor()
        {

        }

        public Vendedor(int vendedorId, string vendedorNome, string vendedorEmail, DateTime vendedorAniversario, decimal vendedorSalario, Filial filial)
        {
            VendedorId = vendedorId;
            VendedorNome = vendedorNome;
            VendedorEmail = vendedorEmail;
            VendedorAniversario = vendedorAniversario;
            VendedorSalario = vendedorSalario;
            Filial = filial;
        }
    }
}
