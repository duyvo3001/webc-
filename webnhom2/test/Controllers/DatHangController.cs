using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.ConnectDB;
using test.Models;
namespace test.Controllers
{
    public class DatHangController : Controller
    {
        //
        // GET: /DatHang/
        public  string connectionString = Properties.Settings.Default.connectionString;
        public conectDB sql = new conectDB();
        private const string cartSes = "CartSession"; 
        [HttpPost]
        public ActionResult Ddathang(string malk , int soluong  )
        {
            var cart = Session[cartSes];
            if (cart != null)
            {
                var list = (List<DatHang>)cart;
                if(list.Exists(x=>x.SoLuong == soluong))
                {
                    foreach (var item in list)
                    {
                        item.SoLuong += soluong;
                    }
                }
            }
            else
            {
                // tạo mới đối tuọng cart item
                var item = new DatHang() ;
                item.MaLK = malk;
                item.SoLuong = soluong;
                var list = new List<DatHang>();
                list.Add(item);

                Session[cartSes] = list;// gán vào session
            }
            return RedirectToAction("dathang");
        }
        public ActionResult dathang()
        {
            var cart = Session[cartSes];
            var list = new List<DatHang>();
            if(cart != null)
            {
                 list = (List<DatHang>)cart;
            }
            return View();
        }

    }
}
