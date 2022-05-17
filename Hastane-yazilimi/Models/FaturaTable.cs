using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hastane_yazilimi.Models
{
    public class FaturaTable
    {
        [Key]
        public int FaturaId { get; set; }
        public decimal FaturaTutar { get; set; }
        public DateTime FaturaTarihi { get; set; }
        public List<RandevuTable> Randevular { get; set; }

    }
}