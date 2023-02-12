using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using test.ConnectDB;
using System.Data;


namespace Controllers
{
    public class RegisterController : Controller
    {
        //
        // GET: /Register/
        public conectDB sql = new conectDB();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult register(register model)
        {
            string query = @"store_insertuser";
            string query1 = @"select * from KhachHang";
            DataTable data = sql.ExcuteQuery1(query1, new Dictionary<string, object>());
            model.MaKH = data.Rows.Count + 1;
            int roweffected = sql.ExcuteNonQuery(query, new Dictionary<string, object>() {
                {"@MaKH",model.MaKH },
                {"@PassWord", model.PassWord},
                {"@hoten", model.name},
                {"@sdt", model.sdt},
                {"@Email", model.Email},
                {"@diachi", model.diachi}
            });


            if (roweffected > 0)
            {
                return Json("ok");
            }

            return Json("ERROR");

        }
        public ActionResult Register_done()
        {
            return View();
        }
    }
}
