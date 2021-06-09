using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace Economat_v2.Models
{
    public class Factura
    {
        public int Id { get; set; }
        [Display(Name = "CIM Angajat")]
        public int CIM_Angajat { get; set; }
        [Display(Name = "Nume Angajat")]
        public string Nume_Angajat { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }
        public int Serie { get; set; }
        [Display(Name = "Numarul Documentului")]
        public int Numar_Document { get; set; }
        [Display(Name = "Tipul Documentului")]
        public string Tip_Document { get; set; }
        [Display(Name = "Suma Totala")]
        public int Suma_Totala { get; set; }
        [Display(Name = "Suma Platita")]
        public int Suma_Platita { get; set; }
        public int Restanta { get; set; }
        [Display(Name = "Nume Angajat")]
        public int AngajatId { get; set; }
        public virtual Angajat Angajat { get; set; }
        public ICollection<Detali> Detalii { get; set; }
        [Display(Name = "Nume Companie")]
        public int CompanieId { get; set; }
        public virtual Companie Companie { get; set; }
        [Display(Name = "Numar Factura")]
        public int Numar_FacturaId { get; set; }
        public virtual Numar_Factura Numar_Factura { get; set; }
    }
}
