using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hastane_yazilimi.Models
{
    public class IslemTable
    {
        [Key]
        public int IslemId { get; set; }
        public string IslemAd { get; set; }
        public decimal IslemUcret { get; set; }
        public List<RandevuTable> Randevular { get; set; }

    }
}