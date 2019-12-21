using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VendasWeb.Models
{
    public class Filial
    {
        public int FilialId { get; set; }
        public string FilialNome { get; set; }

        public Filial()
        {

        }

        public Filial (int filialId, string filialNome)
        {
            FilialId = filialId;
            FilialNome = filialNome;
        }
    }
}
