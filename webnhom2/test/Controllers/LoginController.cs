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
    public class LoginController : Controller
    {
        //
        // GET: /Login/
        public string connectionString = Properties.Settings.Default.connectionString;
        public conectDB sql = new conectDB();
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]

        public ActionResult Signin(login model)
        {
            string query = "store_Login";
            conectDB sql = new conectDB();
            DataTable data = sql.ExcuteQuery(query, new Dictionary<string, object>() {
                  {"@Email", model.Email},
                  {"@PassWord", model.PassWord}
              });
            if (data.Rows.Count > 0)
            {
                string query1 = @"store_viewKH";
                DataTable data1 = sql.ExcuteQuery(query1, new Dictionary<string, object>(){
                    {"@Email", model.Email}
                });
                Session["user"] = data.Rows[0][0]; 
                return Json("oke");
            }
            else
            {
                return Json("TÀI KHOẢN HOẶC MẬT KHẨU SAI !!!");
            }
        }
    }
}
