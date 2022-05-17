using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Hastane_yazilimi.Models
{
    public class RandevuTable
    {
        [Key]
        public int SıraNo { get; set; }
        public int RandevuNo { get; set; }
        public int HastaId { get; set; }
        public HastaTable Hasta { get; set; }
        public int DoktorId { get; set; }
        public DoktorTable Doktor { get; set; }
        public bool RandevuDurumu { get; set; }
        public DateTime RandevuTarihi { get; set; }
        public string Aciklama { get; set; }
        public int IslemId { get; set; }
        public IslemTable Islem { get; set; }
        public int FaturaId { get; set; }
        public FaturaTable Fatura { get; set; }

    }
}