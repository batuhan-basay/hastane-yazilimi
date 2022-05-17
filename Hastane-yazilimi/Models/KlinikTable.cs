using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hastane_yazilimi.Models
{
    public class KlinikTable
    {
        [Key]
        public int KlinikId { get; set; }
        public string KlinikAd { get; set; }
    }
}