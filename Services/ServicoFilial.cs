using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWeb.Data;
using VendasWeb.Models;

namespace VendasWeb.Services
{
    public class ServicoFilial
    {
        private readonly VendasWebContext _context;

        public ServicoFilial(VendasWebContext context)
        {
            _context = context;
        }

        public List<Filial> EncontreTodos()
        {
            return _context.Filial.ToList();
        }
    }
}
