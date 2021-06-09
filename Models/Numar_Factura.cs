using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Economat_v2.Models
{
    public class Numar_Factura
    {
        public int Id { get; set; }
        public int Serie { get; set; }
        [Display(Name = "Numar Inceput")]
        public int Numar_Inceput { get; set; }
        [Display(Name = "Numar Sfarsit")]
        public int Numar_Sfarsit { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }
        [Display(Name = "Numar Curent")]
        public int Numar_Curent { get; set; }
        public virtual Factura Factura { get; set; }
    }
}
