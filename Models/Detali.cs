using System;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace Economat_v2.Models
{
    public class Detali
    {
        public int Id { get; set; }
        [Display(Name = "Produs")]
        public string Nume_Produs { get; set; }
        [Display(Name = "Cantitate")]
        public int Cantitate_Produs { get; set; }
        public int Pret { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime Data { get; set; }
        [Display(Name = "Factura")]
        public int FacturaId { get; set; }
        public virtual Factura Factura { get; set; }
        [Display(Name = "Nume Produs")]
        public int ProdusId { get; set; }
        public virtual Produs Produs { get; set; }


    }
}
