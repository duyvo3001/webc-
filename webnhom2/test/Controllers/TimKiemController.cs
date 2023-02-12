using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.Models;
using System.Data;
using System.Data.SqlClient;
using test.ConnectDB;

namespace test.Controllers
{
    public class TimKiemController : Controller
    {
        public string connectionString = Properties.Settings.Default.connectionString;
        public conectDB sql = new conectDB();
        static string tenlinhkien = null;
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]//
        public ActionResult timkiem(timkiem tk, int id = 1, int PageSize = 15)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                tenlinhkien = tk.TenLK;
                // string query = @"select Hinh1 , TenLK , Gia  from LinhKien where TenLK like" + " " + tenlinhkien;
               string query = "TIMKIEM";
                //  DataTable data = sql.ExcuteQuery1(query, new Dictionary<string, object>());

                DataTable data = sql.ExcuteQuery(query, new Dictionary<string, object>() {
                    {"@TenLK", tk.TenLK  },
                    {"@PageIndex",id },
                    {"@PageSize",PageSize} 
                });
                if (data.Rows.Count > 0)
                    {return Json("oke");}
                else { return Json("không có dữ liệu"); }
            }
            return View();
        }
        public ActionResult Ttimkiem(timkiem tk, int id = 1, int PageSize = 8)
        {
            List<timkiem> timkiem1 = new List<timkiem>();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                int tien = (Convert.ToInt32(id)) + 1;
                int lui = (Convert.ToInt32(id)) - 1;
                conn.Open();
                //string query = @"select MaLK, Hinh1 , TenLK , Gia  from LinhKien where TenLK like" + " " + tenlinhkien
                                ;// chưa chỉnh sang procedure được 
                string query = "TIMKIEM";
                DataTable data = sql.ExcuteQuery(query, new Dictionary<string, object>()
                {
                {"@TenLK",tenlinhkien},{"PageIndex",id},{"@PageSize",PageSize}
                });
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    timkiem1.Add(new timkiem()
                    {
                        MaLK = data.Rows[i][0].ToString(),
                        Hinh1 = data.Rows[i][3].ToString(),
                        TenLK = data.Rows[i][1].ToString(),
                        Gia = Convert.ToDecimal(data.Rows[i][2].ToString())
                    });
                }
                ViewBag.tien = tien;
                ViewBag.lui = lui;
                ViewBag.TK1 = timkiem1;
            }
            return View();
        }
    }
}
