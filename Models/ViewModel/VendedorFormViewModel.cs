using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasWeb.Models.ViewModel
{
    public class VendedorFormViewModel
    {
        public Vendedor Vendedor { get; set; }
        public Filial Filial { get; set; }
        public List<Filial> Filiais { get; set; }
    }
}
