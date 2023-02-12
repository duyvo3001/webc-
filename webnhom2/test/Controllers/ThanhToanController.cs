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
    public class ThanhToanController : Controller
    {
        public string connectionString = Properties.Settings.Default.connectionString;
        public conectDB sql = new conectDB();
        //
        // GET: /ThanhToan/
        [HttpPost]
        public ActionResult Addthanhtoan(thanhtoan tt)
        {
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    //------------------------------------------------------------------------------/
                    tt.MaKH = Convert.ToInt32(Session["user"]);
                    //------------------------------------------------------------------------------/
                    if (tt.MaKH != 0)
                    {
                        tt.MaNV = "NV01";
                        string query = @"insert into HoaDon (MaHD,MaKH,MaNV,NgayLapHD,HoTen,DiaChi,SDT,Email)
	                        values (@MaHD,@MaKH,@MaNV,CURRENT_TIMESTAMP,@HoTen,@DiaChi,@SDT,@Email)";
                        string query3 = @"select Max(CONVERT(int, MaHD)) from HoaDon";
                        DataTable data2 = sql.ExcuteQuery1(query3);
                        tt.MaHD = Convert.ToString(/*data2.Rows[0]["MaxCard"].ToString() == "" ? 1 :*/ Convert.ToInt32(data2.Rows[0][0].ToString()) + 1);//gán card id
                        int roweffected = sql.ExcuteNonQuery(query, new Dictionary<string, object>() {
                            {"@MaHD", tt.MaHD},
                            {"@MaKH", tt.MaKH},
                            {"@MaNV",tt.MaNV },
                            {"@HoTen", tt.Hoten},
                            {"@DiaChi", tt.DiaChi},
                            {"@SDT", tt.SDT},
                            {"@Email", tt.Email}
                        }, CommandType.Text);
                        if (roweffected > 0) {
                            string query1 = "updateThanhToan";
                            roweffected = sql.ExcuteNonQuery(query1, new Dictionary<string, object>() {
                                {"@CardID", tt  } 
                            
                            });
                            if(roweffected > 0) { string test1 = "hihi";}
                            return Json("oke"); 
                        }
                        else { return Json("eror"); }
                    }
                    else { return Json("vui lòng đăng nhập"); }
                }
                catch (Exception ex)
                { return Json("eror"); }
            }
            return Json("thanh toán thành công");
        }
        public ActionResult Checkout(giohang gh)
        {
            List<giohang> Viewgiohang = new List<giohang>();
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                try
                {
                    double tongthanhtien = 0, gia1 = 0, tongthanhtien1 = 0;
                    int soluong1 = 0;
                    string query1 = @"push_giohang_store";// đẩy data lên
                    //---------------------------------------------------------------------------
                    gh.MaKH = Convert.ToInt32(Session["user"]);
                    //---------------------------------------------------------------------------
                    // tạo dữ liệu cho table
                    DataTable data = sql.ExcuteQuery(query1, new Dictionary<string, object>() {
                        {"@MaKH" ,gh.MaKH }
                    });
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        Viewgiohang.Add(new giohang
                        {
                            Hinh1 = data.Rows[i][0].ToString(),
                            TenLK = data.Rows[i][1].ToString(),
                            Gia = Convert.ToInt32(data.Rows[i][2].ToString()),
                            SoLuong = Convert.ToInt32(data.Rows[i][3].ToString())
                        });
                    }
                    ViewBag.GH1 = Viewgiohang;
                    //---------------------------------------------------------------------------
                    foreach (var item in ViewBag.GH1)
                    {
                        soluong1 = item.SoLuong;
                        gia1 = item.Gia;
                        tongthanhtien1 = soluong1 * gia1;
                        tongthanhtien += tongthanhtien1;
                    }
                    ViewBag.gh2 = tongthanhtien; // tính thành tiền tất cả
                }
                catch (Exception ex) { return View("sai"); }
            }
            return View();
        }
        public ActionResult Checkout_done()
        {
            return View();
        }
    }
}
