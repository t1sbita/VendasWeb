using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using VendasWeb.Models;
using VendasWeb.Models.Enums;

namespace VendasWeb.Data
{
    public class AlimentaBanco
    {
        private VendasWebContext _context;

        public AlimentaBanco(VendasWebContext contex)
        {
            _context = contex;
        }

        public void Alimenta()
        {
            if (_context.Filial.Any() || _context.Vendedor.Any() || _context.RegistroVendas.Any())
            {
                return;
            }
            Filial centro = new Filial(1, "Centro");
            Filial cajazeiras = new Filial(2, "Cajazeiras");
            Filial barra = new Filial(3, "Barra");
            Filial ondina = new Filial(4, "Ondina");

            Vendedor pedro = new Vendedor(10, "Pedro Henrique", "pedro@vendas.com.br", new DateTime(1993, 03, 27), 2500, centro);
            Vendedor otavio = new Vendedor(11, "Otavio Oliveira", "otavio@vendas.com.br", new DateTime(1997, 02, 08), 2400, barra);
            Vendedor raquel = new Vendedor(12, "Raquel Garcia", "keel@vendas.com.br", new DateTime(1997, 12, 05), 3100, cajazeiras);
            Vendedor cardoso = new Vendedor(13, "Antonio Cardoso", "cardoso@vendas.com.br", new DateTime(1968, 04, 04), 2740, ondina);
            Vendedor felipe = new Vendedor(14, "Felipe Ferreira", "ferreira@vendas.com.br", new DateTime(1999, 10, 20), 2000, cajazeiras);

            RegistroVendas vendas1 = new RegistroVendas(101, new DateTime(2019, 05, 10), raquel, 1500, StatusVenda.Faturada);
            RegistroVendas vendas2 = new RegistroVendas(102, new DateTime(2019, 07, 20), cardoso, 1000, StatusVenda.Pendente);
            RegistroVendas vendas3 = new RegistroVendas(103, new DateTime(2019, 08, 23), otavio, 900, StatusVenda.Cancelada);
            RegistroVendas vendas4 = new RegistroVendas(104, new DateTime(2019, 09, 10), raquel, 1000, StatusVenda.Faturada);
            RegistroVendas vendas5 = new RegistroVendas(105, new DateTime(2019, 09, 23), felipe, 1400, StatusVenda.Faturada);
            RegistroVendas vendas6 = new RegistroVendas(106, new DateTime(2019, 10, 23), pedro, 700, StatusVenda.Faturada);
            RegistroVendas vendas7 = new RegistroVendas(107, new DateTime(2019, 11, 29), cardoso, 1200, StatusVenda.Pendente);

            _context.Filial.AddRange(centro, cajazeiras, barra, ondina);

            _context.Vendedor.AddRange(pedro, otavio, raquel, cardoso, felipe);

            _context.RegistroVendas.AddRange(vendas1, vendas2, vendas3, vendas4, vendas5, vendas6, vendas7);

            _context.SaveChanges();
        }
    }
}
