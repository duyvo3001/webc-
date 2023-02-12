using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace test.Models
{
    [Serializable]
    public class DatHang
    {
        public string cardID { get; set; }
        public string  MaLK { get; set; }
        public int SoLuong { get; set; }
    }
}