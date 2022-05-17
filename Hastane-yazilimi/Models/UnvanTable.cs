using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Hastane_yazilimi.Models
{
    public class UnvanTable
    {
        [Key]
        public int UnvanId { get; set; }
        public string UnvanAd { get; set; }
        public List<DoktorTable> Doktorlar { get; set; }
    }
}