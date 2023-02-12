using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
namespace test.Models
{
    public class giohang
    {
        public string cardID { get; set; }
        public string MaLK { get; set; }
        public int SoLuong { get; set; }
        public int MaKH { get; set; }
        public string Hinh1 { get; set; }
        public double Gia { get; set; }
        public string TenLK { get; set; }
        public double ThanhTien { get; set; }
        public int ThanhToan { get; set; }
    }
}