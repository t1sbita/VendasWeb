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
        public float VendedorSalario { get; set; }
        public Filial Filial { get; set; }
        public int FilialId { get; set; }
        
        public ICollection<RegistroVendas> VendasRealizadas = new List<RegistroVendas>();

        public Vendedor()
        {

        }

        public Vendedor(int vendedorId, string vendedorNome, string vendedorEmail, DateTime vendedorAniversario, float vendedorSalario, Filial filial)
        {
            VendedorId = vendedorId;
            VendedorNome = vendedorNome;
            VendedorEmail = vendedorEmail;
            VendedorAniversario = DateTime.Parse(vendedorAniversario.ToString("dd/MM/yyyy"));
            VendedorSalario = vendedorSalario;
            Filial = filial;

            
        }

        public void AdicionarVenda(RegistroVendas vendagem)
        {
            VendasRealizadas.Add(vendagem);
        }

        public void RemoverVenda(RegistroVendas vendagem)
        {
            VendasRealizadas.Remove(vendagem);
        }

       public float TotalVendas(DateTime inicio, DateTime final)
        {
            return VendasRealizadas.Where(vendas => vendas.DataVenda >= inicio && vendas.DataVenda <= final)
                .Sum(vendas => vendas.ValorVenda);
        }

        
    }
}
