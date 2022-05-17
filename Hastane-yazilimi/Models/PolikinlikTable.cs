using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hastane_yazilimi.Models
{
    public class PolikinlikTable
    {
        [Key]
        public int PoliklinikId { get; set; }
        public string PoliklinikAd { get; set; }
        public int KlinikId { get; set; }
        public KlinikTable Klinik { get; set; }
        public List<DoktorTable> Doktorlar { get; set; }
    }
}