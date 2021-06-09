using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Economat_v2.Models
{
    public class Produs
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public int Stoc { get; set; }
        public int Pret_Unitate { get; set; }
        public string Categorie { get; set; }
        public ICollection<Detali> Detalii { get; set; }
    }
}
