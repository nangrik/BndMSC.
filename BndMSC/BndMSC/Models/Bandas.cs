using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BndMSC.Models
{
    public class Bandas
    {
        [Key]
        public int BandasId { get; set; }
        [Display(Name ="Nombre")]
        public string BandaName { get; set; }
    }
}
