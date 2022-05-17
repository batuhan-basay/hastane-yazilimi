using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hastane_yazilimi.Models
{
    public class HastaTable
    {
        [Key]
        public int HastaId { get; set; }
        public string HastaTC { get; set; }
        public string HastaAd { get; set; }
        public string HastaSoyad { get; set; }
        public bool Cinsiyet { get; set; }
        public string TelNo { get; set; }
        public string Email { get; set; }
        public List<RandevuTable> Randevular { get; set; }
    }
}