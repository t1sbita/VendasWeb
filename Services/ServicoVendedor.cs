using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWeb.Data;
using VendasWeb.Models;

namespace VendasWeb.Services
{
    public class ServicoVendedor
    {
        private readonly VendasWebContext _context;

        public ServicoVendedor(VendasWebContext context)
        {
            _context = context;
        }

        public List<Vendedor> EncontreTodos()
        {
            return _context.Vendedor.ToList();
        }
    }
}
