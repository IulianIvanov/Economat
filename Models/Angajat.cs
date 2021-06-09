using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace Economat_v2.Models
{
    public class Angajat
    {
        public int Id { get; set; }
        [Display(Name = "Nume si Prenume")]
        public string Nume_Prenume { get; set; }
        public int CIM { get; set; }
        public string CNP { get; set; }
        public int Sold { get; set; }
        [Display(Name = "Restanta Totala")]
        public int Restanta_Totala { get; set; }
        public ICollection<Factura> Facturi { get; set; }

    }


}
