using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Economat_v2.Models
{
    public class Companie
    {
        public int Id { get; set; }
        public string Nume { get; set; }
        public string Adresa { get; set; }
        public int Telefon { get; set; }
        public string Mail { get; set; }
        public virtual Factura Factura { get; set; }
    }
}
