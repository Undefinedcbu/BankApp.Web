using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Bank_Web.Models
{
    public class Hesap
    {
        public int HesapID { get; set; }
        public int MusteriID { get; set; }
        public decimal Bakiye { get; set; }
        public int EkNo { get; set; }
        public string HesapNo { get; set; }
        public string Durum { get; set; }
    }
}