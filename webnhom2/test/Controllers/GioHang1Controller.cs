using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using test.Models;
using test.ConnectDB;

namespace test.Controllers
{
    public class GioHang1Controller : Controller
    {
        //
        // GET: /GioHang1/
        public string connectionString = Properties.Settings.Default.connectionString;
        public conectDB sql = new conectDB();
        public ActionResult ViewGioHang(giohang gh)
        {
            List<giohang> Viewgiohang = new List<giohang>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    double tongthanhtien = 0, gia1 = 0, tongthanhtien1 = 0;
                    int soluong1 = 0,KH = Convert.ToInt32(Session["user"]) ;
                    string query1 = @"push_giohang_store";// đẩy data lên
                    DataTable data = sql.ExcuteQuery(query1, new Dictionary<string, object>() {
                        {"@MaKH" ,KH },
                        {"@ThanhToan" ,  0  }
                    });
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        Viewgiohang.Add(new giohang
                        {
                            Hinh1 = data.Rows[i][0].ToString(),
                            TenLK = data.Rows[i][1].ToString(),
                            Gia = Convert.ToInt32(data.Rows[i][2].ToString()),
                            SoLuong = Convert.ToInt32(data.Rows[i][3].ToString()),
                            cardID = data.Rows[i][4].ToString() 
                        });
                    }
                    ViewBag.GH1 = Viewgiohang;
                    foreach (var item in ViewBag.GH1)
                    {
                        soluong1 = item.SoLuong;
                        gia1 = item.Gia;
                        tongthanhtien1 = soluong1 * gia1;
                        tongthanhtien = tongthanhtien + tongthanhtien1;
                    }
                    ViewBag.gh2 = tongthanhtien;
                }
                catch (Exception ex) { return View("sai"); }
            }
            return View();
        }
        [HttpPost]
        public ActionResult addGioHang(giohang gh)
        {
            try
            {
                gh.MaKH = Convert.ToInt32(Session["user"]);
                if (gh.MaKH != 0)
                {
                    //Lấy thông tin cardId cuối cùng được thêm vào DB sau đó set cardId hiện tại được tạo = maxCardId + 1
                    string query1 = @"select Max(CardId) as MaxCard from GioHang";//..
                    string query3 = @"select Max(CONVERT(int, CardID)) from GioHang";
                    DataTable data = sql.ExcuteQuery1(query3);//gán card id//
                    gh.cardID = Convert.ToString(data.Rows[0][0].ToString() == "" ? 1 : Convert.ToInt32(data.Rows[0][0].ToString()) + 1);// tự động gán card id 

                    string query = @"giohang_store";
                    int roweffected = sql.ExcuteNonQuery(query, new Dictionary<string, object>() {
                        {"@cardID",gh.cardID },
                        { "@MaLK",gh.MaLK}, 
                        { "@SoLuong",gh.SoLuong},
                        { "@MaKH",gh.MaKH},
                        {"@ThanhToan" , 0  }
                    });

                    if (roweffected > 0) return Json("oke");
                    else return Json("dữ liệu sai");
                }
                else return Json("vui lòng đăng nhập");
            }
            catch (Exception ex)
            {
                return Json("loi");
            }
        }
        [HttpPost]
        public ActionResult xoaGioHang(giohang gh)
        {  
            string query1 = @"delete_giohang_store";
            gh.MaKH = Convert.ToInt32(Session["user"]);
            int roweffected = sql.ExcuteNonQuery(query1, new Dictionary<string, object>() {
                {"@CardID",gh.cardID },{"@MaKH",gh.MaKH}
            });
            if (roweffected > 0)
                return Json("oke");
            else return Json("eror");
        }
    }
}
