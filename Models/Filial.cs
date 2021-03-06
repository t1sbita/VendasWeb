﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasWeb.Models
{
    public class Filial
    {
        public int FilialId { get; set; }
        public string FilialNome { get; set; }

        public ICollection<Vendedor> Vendedores = new List<Vendedor>();

        public Filial()
        {

        }

        public Filial (int filialId, string filialNome)
        {
            FilialId = filialId;
            FilialNome = filialNome;
        }

        public void AdicionarVendedor(Vendedor vendedor)
        {
            Vendedores.Add(vendedor);
        }

        public void RemoverVendedor(Vendedor vendedor)
        {
            Vendedores.Remove(vendedor);
        }

        public float TotalVendaFilial(DateTime inicio, DateTime final)
        {
            return Vendedores.Sum(vendedor => vendedor.TotalVendas(inicio, final));
        }
    }
}
