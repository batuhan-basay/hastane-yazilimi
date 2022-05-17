using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hastane_yazilimi.Models
{
    public class DoktorTable
    {

        [Key]
        public int DoktorId { get; set; }
        public string DoktorTC { get; set; }
        public string DoktorAd { get; set; }
        public string DoktorSoyad { get; set; }
        public string UnvanId { get; set; }
        public UnvanTable Unvan { get; set; }
        public bool Cinsiyet { get; set; }
        public string TelNo { get; set; }
        public string Email { get; set; }
        public string PoliklinikId { get; set; }
        public PolikinlikTable Poliklinik { get; set; }
        public List<RandevuTable> Randevular { get; set; }
    }
}