using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Models;
using test.ConnectDB;
using test.Models;

namespace test.Controllers
{
    public class ITNEXTController : Controller
    {
        //
        // GET: /ITNEXT/
        public conectDB sql = new conectDB();
        public ActionResult Index( Linhkien model)
        {  
            List<Linhkien> MANHINH = new List<Linhkien>();
            string ConnectionString = Properties.Settings.Default.connectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                   
                    con.Open();
                    string query = @"SELECT TOP 8 MaLK, TenLK , Gia,Hinh1
                                    from LinhKien
                                    where MaLoai = 'A03'
                                    ";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter dataApp = new SqlDataAdapter(cmd);
                    DataTable data = new DataTable();
                    dataApp.Fill(data);
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        MANHINH.Add(new Linhkien() { MaLK = data.Rows[i][0].ToString(), TenLK = data.Rows[i][1].ToString(), Gia = Convert.ToDouble( data.Rows[i][2].ToString()), Hinh = data.Rows[i][3].ToString() });
                    }
                }
                catch (Exception ex)
                {
                    return View("lỗi");
                }
            }
            List<Linhkien> BANCHAY = new List<Linhkien>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    
                    con.Open();
                    string query = @"SELECT TOP 8 MaLK, TenLK , Gia,Hinh1
                                        FROM LinhKien
                                        ORDER BY GIA asc";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter dataApp = new SqlDataAdapter(cmd);
                    DataTable data = new DataTable();
                    dataApp.Fill(data);
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        BANCHAY.Add(new Linhkien() { MaLK = data.Rows[i][0].ToString(), TenLK = data.Rows[i][1].ToString(),
                                                     Gia =Convert.ToDouble( data.Rows[i][2].ToString()), Hinh = data.Rows[i][3].ToString() });
                    }
                }
                catch (Exception ex)
                {
                    return View("lỗi");
                }
            }
            List<Linhkien> LAP = new List<Linhkien>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    string query = @"SELECT TOP 8  MaLK,TenLK , Gia,Hinh1
                                    from LinhKien
                                    where MaLoai = 'LAP'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter dataApp = new SqlDataAdapter(cmd);
                    DataTable data = new DataTable();
                    dataApp.Fill(data);
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        LAP.Add(new Linhkien() { MaLK = data.Rows[i][0].ToString(), TenLK = data.Rows[i][1].ToString(), Gia = Convert.ToDouble(data.Rows[i][2].ToString()), Hinh = data.Rows[i][3].ToString() });
                    }
                }
                catch (Exception ex)
                {
                    return View("lỗi");
                }
            }
            List<Linhkien> LINHKIEN = new List<Linhkien>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    string query = @"select  top 8  MaLK ,TenLK, gia,Hinh1
                                        from LinhKien
                                        where TGBH = 15";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter dataApp = new SqlDataAdapter(cmd);
                    DataTable data = new DataTable();
                    dataApp.Fill(data);
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        LINHKIEN.Add(new Linhkien() { MaLK = data.Rows[i][0].ToString(), TenLK = data.Rows[i][1].ToString(), Gia = Convert.ToDouble(data.Rows[i][2].ToString()), Hinh = data.Rows[i][3].ToString() });
                    }
                }
                catch (Exception ex)
                {
                    return View("lỗi");
                }
            }
            List<Linhkien> PHUKIEN = new List<Linhkien>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    string query = @"SELECT top 8 MaLK , TenLK, gia,Hinh1
                                    from LinhKien
                                    where  MaLoai = 'NIC' OR MaLoai='VR'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter dataApp = new SqlDataAdapter(cmd);
                    DataTable data = new DataTable();
                    dataApp.Fill(data);
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        PHUKIEN.Add(new Linhkien() { MaLK=data.Rows[i][0].ToString(), TenLK = data.Rows[i][1].ToString(), Gia = Convert.ToDouble(data.Rows[i][2].ToString()), Hinh = data.Rows[i][3].ToString() });
                    }
                }
                catch (Exception ex)
                {
                    return View("lỗi");
                }
            }

            ViewBag.Lap = LAP;
            ViewBag.BANCHAY = BANCHAY;
            ViewBag.manhinh = MANHINH;
            ViewBag.linhkien = LINHKIEN;
            ViewBag.phukien = PHUKIEN;
            return View();

        }
        public ActionResult Laptop(int id = 1, int PageSize = 8)
        {
            List<Linhkien> Linhkiens = new List<Linhkien>();
            string ConnectionString = Properties.Settings.Default.connectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    //string query = @"SELECT MaLK ,TenLK,Gia,Hinh1
                    //                FROM LinhKien
                    //                WHERE MaLoai = 'LAP'";
                    int tien = (Convert.ToInt32(id)) + 1;
                    int lui = (Convert.ToInt32(id)) - 1;
                    string ml = "LAP";
                    string query = @"[PHANTRANG]";
                    DataTable data = sql.ExcuteQuery(query, new Dictionary<string, object>() {
                        {"@PageIndex",id},
                        {"@PageSize",PageSize },
                        {"@MaLoai",ml }
                    });
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        Linhkiens.Add(new Linhkien() { MaLK = data.Rows[i][0].ToString(), TenLK = data.Rows[i][1].ToString(), Gia = Convert.ToDouble(data.Rows[i][2].ToString()), Hinh = data.Rows[i][3].ToString() });
                    }
                    ViewBag.tien = tien;
                    ViewBag.lui = lui;
                }
                catch (Exception ex)
                {
                    return View("lỗi");
                }
            }
           
            ViewBag.linhkien = Linhkiens;

            return View();




        }
        public ActionResult ManHinh(int id = 1, int PageSize = 8)
        {
            List<Linhkien> MANHINH = new List<Linhkien>();
            string ConnectionString = Properties.Settings.Default.connectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    //string query = @"SELECT MaLK ,TenLK,Gia,Hinh1
                    //                from LinhKien
                    //                where MaLoai = 'A03'";
                    int tien = (Convert.ToInt32(id)) + 1;
                    int lui = (Convert.ToInt32(id)) - 1;
                    string ml = "A03";
                    string query = @"[PHANTRANG]";
                    DataTable data = sql.ExcuteQuery(query, new Dictionary<string, object>() {
                        {"@PageIndex",id},
                        {"@PageSize",PageSize },
                        {"@MaLoai",ml }
                    });
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        MANHINH.Add(new Linhkien() { MaLK = data.Rows[i][0].ToString(), TenLK = data.Rows[i][1].ToString(), Gia = Convert.ToDouble(data.Rows[i][2].ToString()), Hinh = data.Rows[i][3].ToString() });
                    }
                    ViewBag.tien = tien;
                    ViewBag.lui = lui;
                }
                catch (Exception ex)
                {
                    return View("lỗi");
                }
            }
            ViewBag.ManHinh = MANHINH;
            return View();
        }

        public ActionResult LinhKien(int id = 1, int PageSize = 15)
        {

            int tien = (Convert.ToInt32(id)) + 1;
            int lui = (Convert.ToInt32(id)) - 1;
            List<Linhkien> Linhkiens = new List<Linhkien>();
            string ConnectionString = Properties.Settings.Default.connectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    string query = "[PHANTRANG_gaminggear]";
                    string ml1 = "A04", ml2 = "VGA", ml3 = "A11", ml4 = "Mai", ml5 = "A06";
                    DataTable data = sql.ExcuteQuery(query, new Dictionary<string, object>() {
                        {"@PageIndex",id},
                        {"@PageSize",PageSize },
                        {"@MaLoai1",ml1 },
                        {"@MaLoai2",ml2 },
                        {"@MaLoai3",ml3 },
                        {"@MaLoai4",ml4 },
                        {"@MaLoai5",ml5 }
                    });
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        Linhkiens.Add(new Linhkien() { MaLK = data.Rows[i][0].ToString(), TenLK = data.Rows[i][1].ToString(), Gia = Convert.ToDouble(data.Rows[i][2].ToString()), Hinh = data.Rows[i][3].ToString() });
                    }
                }
                catch (Exception ex)
                {
                    return View("lỗi");
                }
            }
            ViewBag.tien = tien;
            ViewBag.lui = lui;

            ViewBag.linhkien = Linhkiens;
            return View();
        }
        /* cấp con  của linh kiện *////////////////////////////////////////////////////////////////

        public ActionResult CPU (int id = 1, int PageSize = 8)
        {
            List<Linhkien> Linhkiens = new List<Linhkien>();
            string ConnectionString = Properties.Settings.Default.connectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    int tien = (Convert.ToInt32(id)) + 1;
                    int lui = (Convert.ToInt32(id)) - 1;
                    //string query = @"SELECT MaLK,TenLK,Gia,Hinh1
                    //                FROM LinhKien
                    //                WHERE MaLoai = 'A04'";
                    string ml = "A04";
                    string query = @"[PHANTRANG]";
                    DataTable data = sql.ExcuteQuery(query, new Dictionary<string, object>() {
                       {"@PageIndex",id},
                        {"@PageSize",PageSize },
                        {"@MaLoai",ml }
                    });
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        Linhkiens.Add(new Linhkien() { MaLK = data.Rows[i][0].ToString(), TenLK = data.Rows[i][1].ToString(), Gia = Convert.ToDouble(data.Rows[i][2].ToString()), Hinh = data.Rows[i][3].ToString() });
                    }
                    ViewBag.tien = tien;
                    ViewBag.lui = lui;
                }
                catch (Exception ex)
                {
                    return View("lỗi");
                }
            }

            ViewBag.linhkien = Linhkiens;
            return View();

        }
        public ActionResult VGA(int id = 1, int PageSize = 8)
        {
            List<Linhkien> Linhkiens = new List<Linhkien>();
            int tien = (Convert.ToInt32(id)) + 1;
            int lui = (Convert.ToInt32(id)) - 1;
            string ConnectionString = Properties.Settings.Default.connectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    //string query = @"SELECT MaLK ,TenLK,Gia,Hinh1
                    //                FROM LinhKien
                    //                WHERE MaLoai = 'VGA'";
                    string ml = "VGA"; 
                    string query = @"[PHANTRANG]";
                    DataTable data = sql.ExcuteQuery(query, new Dictionary<string, object>() {
                    {"@PageIndex",id},
                        {"@PageSize",PageSize },
                        {"@MaLoai",ml }
                    });
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        Linhkiens.Add(new Linhkien() { MaLK = data.Rows[i][0].ToString(), TenLK = data.Rows[i][1].ToString(), Gia = Convert.ToDouble(data.Rows[i][2].ToString()), Hinh = data.Rows[i][3].ToString() });
                    }
                    ViewBag.tien = tien;
                    ViewBag.lui = lui;
                }
                catch (Exception ex)
                {
                    return View("lỗi");
                }
            }

            ViewBag.linhkien = Linhkiens;
            return View();

        }
        public ActionResult HDD(int id = 1, int PageSize = 8)
        {
            int tien = (Convert.ToInt32(id)) + 1;
            int lui = (Convert.ToInt32(id)) - 1;
            List<Linhkien> Linhkiens = new List<Linhkien>();
            string ConnectionString = Properties.Settings.Default.connectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    //string query = @"SELECT MaLK,TenLK,Gia,Hinh1
                    //                FROM LinhKien
                    //                WHERE MaLoai = 'A07' or MaLoai = 'A11'";
                    string ml = "A11";
                    string query = @"[PHANTRANG]";
                    DataTable data = sql.ExcuteQuery(query, new Dictionary<string, object>() {
                        {"@PageIndex",id},
                        {"@PageSize",PageSize },
                        {"@MaLoai",ml }
                    });
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        Linhkiens.Add(new Linhkien() { MaLK = data.Rows[i][0].ToString(), TenLK = data.Rows[i][1].ToString(), Gia = Convert.ToDouble(data.Rows[i][2].ToString()), Hinh = data.Rows[i][3].ToString() });
                    }
                    ViewBag.tien = tien;
                    ViewBag.lui = lui;
                }
                catch (Exception ex)
                {
                    return View("lỗi");
                }
            }

            ViewBag.linhkien = Linhkiens;
            return View();

        }
        public ActionResult MainBoard(int id = 1, int PageSize = 8)
        {
            int tien = (Convert.ToInt32(id)) + 1;
            int lui = (Convert.ToInt32(id)) - 1;
            List<Linhkien> Linhkiens = new List<Linhkien>();
            string ConnectionString = Properties.Settings.Default.connectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    //string query = @"SELECT MaLK,TenLK,Gia,Hinh1
                    //                FROM LinhKien
                    //                WHERE MaLoai = 'MAI'";
                    string ml = "MAI";
                    string query = @"[PHANTRANG]";
                    DataTable data = sql.ExcuteQuery(query, new Dictionary<string, object>() {
                       {"@PageIndex",id},
                        {"@PageSize",PageSize },
                        {"@MaLoai",ml }
                    });
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        Linhkiens.Add(new Linhkien() { MaLK = data.Rows[i][0].ToString(), TenLK = data.Rows[i][1].ToString(), Gia = Convert.ToDouble(data.Rows[i][2].ToString()), Hinh = data.Rows[i][3].ToString() });
                    }
                    ViewBag.tien = tien;
                    ViewBag.lui = lui;
                }
                catch (Exception ex)
                {
                    return View("lỗi");
                }
            }

            ViewBag.linhkien = Linhkiens;
            return View();

        }
        public ActionResult Ram(int id = 1, int PageSize = 8)
        {
            int tien = (Convert.ToInt32(id)) + 1;
            int lui = (Convert.ToInt32(id)) - 1;
            List<Linhkien> Linhkiens = new List<Linhkien>();
            string ConnectionString = Properties.Settings.Default.connectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    //string query = @"SELECT MaLK,TenLK,Gia,Hinh1
                    //                FROM LinhKien
                    //                WHERE MaLoai = 'A06'";
                    string ml = "A06";
                    string query = @"[PHANTRANG]";
                    DataTable data = sql.ExcuteQuery(query, new Dictionary<string, object>() {
                        {"@PageIndex",id},
                        {"@PageSize",PageSize },
                        {"@MaLoai",ml }
                    });
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        Linhkiens.Add(new Linhkien() { MaLK = data.Rows[i][0].ToString(), TenLK = data.Rows[i][1].ToString(), Gia = Convert.ToDouble(data.Rows[i][2].ToString()), Hinh = data.Rows[i][3].ToString() });
                    }
                    ViewBag.tien = tien;
                    ViewBag.lui = lui;
                }
                catch (Exception ex)
                {
                    return View("lỗi");
                }
            }

            ViewBag.linhkien = Linhkiens;
            return View();

        }
        public ActionResult NGUON(int id = 1, int PageSize = 8)
        {
            int tien = (Convert.ToInt32(id)) + 1;
            int lui = (Convert.ToInt32(id)) - 1;
            List<Linhkien> PSU = new List<Linhkien>();
            string ConnectionString = Properties.Settings.Default.connectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    //string query = @"SELECT MaLK,TenLK,Gia,Hinh1
                    //                FROM LinhKien
                    //                WHERE MaLoai = 'A06'";
                    string ml = "A06";
                    string query = @"[PHANTRANG]";
                    DataTable data = sql.ExcuteQuery(query, new Dictionary<string, object>() {
                        {"@PageIndex",id},
                        {"@PageSize",PageSize },
                        {"@MaLoai",ml }
                    });
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        PSU.Add(new Linhkien() { MaLK = data.Rows[i][0].ToString(), TenLK = data.Rows[i][1].ToString(), Gia = Convert.ToDouble(data.Rows[i][2].ToString()), Hinh = data.Rows[i][3].ToString() });
                    }
                    ViewBag.tien = tien;
                    ViewBag.lui = lui;
                }
                catch (Exception ex)
                {
                    return View("lỗi");
                }
            }

            ViewBag.PSU = PSU;
            return View();

        }
        public ActionResult CASE1(int id = 1, int PageSize = 8)
        {
            int tien = (Convert.ToInt32(id)) + 1;
            int lui = (Convert.ToInt32(id)) - 1;
            List<Linhkien> CASE = new List<Linhkien>();
            string ConnectionString = Properties.Settings.Default.connectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    string query = @"SELECT MaLK,TenLK,Gia,Hinh1
                                    FROM LinhKien
                                    WHERE MaLoai = 'A06'";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter dataApp = new SqlDataAdapter(cmd);
                    DataTable data = new DataTable();
                    dataApp.Fill(data);
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        CASE.Add(new Linhkien() { MaLK = data.Rows[i][0].ToString(), TenLK = data.Rows[i][1].ToString(), Gia = Convert.ToDouble(data.Rows[i][2].ToString()), Hinh = data.Rows[i][3].ToString() });
                    }
                    ViewBag.tien = tien;
                    ViewBag.lui = lui;
                }
                catch (Exception ex)
                {
                    return View("lỗi");
                }
            }

            ViewBag.CASE = CASE;
            return View();

        }
        /* cấp con *///////////////////////////////////////////////////////////////

        public ActionResult GamingGear(int id = 1, int PageSize = 8)
        {
            int tien = (Convert.ToInt32(id)) + 1;
            int lui = (Convert.ToInt32(id)) - 1;
            List<Linhkien> GamingGear = new List<Linhkien>();
            string ConnectionString = Properties.Settings.Default.connectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    //string query = @"SELECT MaLK ,TenLK,Gia,Hinh1
                    //                FROM LinhKien
                    //                WHERE MaLoai= 'A01' OR MaLoai= 'A02' OR MaLoai= 'A09' OR MaLoai= 'BOX '  OR MaLoai= 'VR '";
                    //string ml = "'A01' OR MaLoai= 'A02' OR MaLoai= 'A09' OR MaLoai= 'BOX'  OR MaLoai= 'VR' OR MaLoai='NIC'";
                    string ml1 = "A01"  , ml2 = "A02" , ml3 = "A09" , ml4 = "BOX" , ml5 ="VR"  ;
                    string query = @"[PHANTRANG_gaminggear]";
                    DataTable data = sql.ExcuteQuery(query, new Dictionary<string, object>() {
                        {"@PageIndex",id},
                        {"@PageSize",PageSize },
                        {"@MaLoai1",ml1 },
                        {"@MaLoai2",ml2 },
                        {"@MaLoai3",ml3 },
                        {"@MaLoai4",ml4 },
                        {"@MaLoai5",ml5 }
                    });
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        GamingGear.Add(new Linhkien() { MaLK = data.Rows[i][0].ToString(), TenLK = data.Rows[i][1].ToString(), Gia = Convert.ToDouble(data.Rows[i][2].ToString()), Hinh = data.Rows[i][3].ToString() });
                    }
                    ViewBag.tien = tien;
                    ViewBag.lui = lui;
                }
                catch (Exception ex)
                {
                    return View("lỗi");
                }
            }
            ViewBag.game = GamingGear;
            return View();
        }
        /* cấp con gaming gear *////
        public ActionResult Chuot(int id = 1, int PageSize = 8)
        {
            int tien = (Convert.ToInt32(id)) + 1;
            int lui = (Convert.ToInt32(id)) - 1;
            List<Linhkien> Chuot = new List<Linhkien>();
            string ConnectionString = Properties.Settings.Default.connectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    //string query = @"SELECT MaLK,TenLK,Gia,Hinh1
                    //                FROM LinhKien
                    //                WHERE MaLoai = 'A01'";
                    string ml = "A01";
                    string query = @"[PHANTRANG]";
                    DataTable data = sql.ExcuteQuery(query, new Dictionary<string, object>() {
                       {"@PageIndex",id},
                        {"@PageSize",PageSize },
                        {"@MaLoai",ml }
                    });
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        Chuot.Add(new Linhkien() { MaLK = data.Rows[i][0].ToString(), TenLK = data.Rows[i][1].ToString(), Gia = Convert.ToDouble(data.Rows[i][2].ToString()), Hinh = data.Rows[i][3].ToString() });
                    }
                    ViewBag.tien = tien;
                    ViewBag.lui = lui;
                }
                catch (Exception ex)
                {
                    return View("lỗi");
                }
            }


            ViewBag.linhkien = Chuot;
            return View();
        }
        public ActionResult BanPhim(int id = 1, int PageSize = 8)
        {
            int tien = (Convert.ToInt32(id)) + 1;
            int lui = (Convert.ToInt32(id)) - 1;
            List<Linhkien> BanPhim = new List<Linhkien>();
            string ConnectionString = Properties.Settings.Default.connectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    //string query = @"SELECT MaLK,TenLK,Gia,Hinh1
                    //                FROM LinhKien
                    //                WHERE MaLoai = 'A02 '";
                    string ml = "A02";
                    string query = @"[PHANTRANG]";
                    DataTable data = sql.ExcuteQuery(query, new Dictionary<string, object>() {
                       {"@PageIndex",id},
                        {"@PageSize",PageSize },
                        {"@MaLoai",ml }
                    });
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        BanPhim.Add(new Linhkien() { MaLK = data.Rows[i][0].ToString(), TenLK = data.Rows[i][1].ToString(), Gia = Convert.ToDouble(data.Rows[i][2].ToString()), Hinh = data.Rows[i][3].ToString() });
                    }
                    ViewBag.tien = tien;
                    ViewBag.lui = lui;
                }
                catch (Exception ex)
                {
                    return View("lỗi");
                }
            }


            ViewBag.linhkien = BanPhim;

            return View();
        }
        public ActionResult TaiNghe(int id = 1, int PageSize = 8)
        {
            int tien = (Convert.ToInt32(id)) + 1;
            int lui = (Convert.ToInt32(id)) - 1;
            List<Linhkien> TaiNghe = new List<Linhkien>();
            string ConnectionString = Properties.Settings.Default.connectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    //string query = @"SELECT MaLK,TenLK,Gia,Hinh1
                    //                FROM LinhKien
                    //                WHERE MaLoai = 'A09 '";
                    string ml = "A09";
                    string query = @"[PHANTRANG]";
                    DataTable data = sql.ExcuteQuery(query, new Dictionary<string, object>() {
                       {"@PageIndex",id},
                        {"@PageSize",PageSize },
                        {"@MaLoai",ml }
                    });
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        TaiNghe.Add(new Linhkien() { MaLK = data.Rows[i][0].ToString(), TenLK = data.Rows[i][1].ToString(), Gia = Convert.ToDouble(data.Rows[i][2].ToString()), Hinh = data.Rows[i][3].ToString() });
                    }
                    ViewBag.tien = tien;
                    ViewBag.lui = lui;
                }
                catch (Exception ex)
                {
                    return View("lỗi");
                }
            }
            ViewBag.linhkien = TaiNghe;

            return View();
        }
        public ActionResult TayCam(int id = 1, int PageSize = 8)
        {
            int tien = (Convert.ToInt32(id)) + 1;
            int lui = (Convert.ToInt32(id)) - 1;
            List<Linhkien> BOX = new List<Linhkien>();
            string ConnectionString = Properties.Settings.Default.connectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    //string query = @"SELECT MaLK,TenLK,Gia,Hinh1
                    //                FROM LinhKien
                    //                WHERE MaLoai = 'BOX'";
                    string ml = "'BOX'";
                    string query = @"[PHANTRANG]";
                    DataTable data = sql.ExcuteQuery(query, new Dictionary<string, object>() {
                        {"@PageIndex",id},
                        {"@PageSize",PageSize },
                        {"@MaLoai",ml }
                    });
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        BOX.Add(new Linhkien() { MaLK = data.Rows[i][0].ToString(), TenLK = data.Rows[i][1].ToString(), Gia = Convert.ToDouble(data.Rows[i][2].ToString()), Hinh = data.Rows[i][3].ToString() });
                    }
                    ViewBag.tien = tien;
                    ViewBag.lui = lui;
                }
                catch (Exception ex)
                {
                    return View("lỗi");
                }
            }


            ViewBag.linhkien = BOX;

            return View();
        }
        public ActionResult VR(int id = 1, int PageSize = 8)
        {
            int tien = (Convert.ToInt32(id)) + 1;
            int lui = (Convert.ToInt32(id)) - 1;
            List<Linhkien> VR = new List<Linhkien>();
            string ConnectionString = Properties.Settings.Default.connectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    //string query = @"SELECT MaLK,TenLK,Gia,Hinh1
                    //                FROM LinhKien
                    //                WHERE MaLoai = 'VR'";
                    string ml = "VR";
                    string query = @"[PHANTRANG]";
                    DataTable data = sql.ExcuteQuery(query, new Dictionary<string, object>() {
                        {"@PageIndex",id},
                        {"@PageSize",PageSize },
                        {"@MaLoai",ml }
                    });
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        VR.Add(new Linhkien() { MaLK = data.Rows[i][0].ToString(), TenLK = data.Rows[i][1].ToString(), Gia = Convert.ToDouble(data.Rows[i][2].ToString()), Hinh = data.Rows[i][3].ToString() });
                    }
                    ViewBag.tien = tien;
                    ViewBag.lui = lui;
                }
                catch (Exception ex)
                {
                    return View("lỗi");
                }
            }


            ViewBag.linhkien = VR;

            return View();
        }
        //////////////////////////////////////////////////////////
        public ActionResult PhuKien(int id = 1, int PageSize = 8)
        {
            int tien = (Convert.ToInt32(id)) + 1;
            int lui = (Convert.ToInt32(id)) - 1;
            List<Linhkien> PhuKien = new List<Linhkien>();
            string ConnectionString = Properties.Settings.Default.connectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    //string query = @"SELECT MaLK,TenLK,Gia,Hinh1
                    //                FROM LinhKien
                    //                WHERE TenLK like N'%phụ kiện %'";
                    string ml = "MaLoai= 'MIN' OR MaLoai= 'LOA' OR MaLoai= 'BOX '  OR MaLoai= 'TB'";
                    string ml1 = "MIN", ml2 = "LOA", ml3 = "BOX", ml4 = "BOX", ml5 = "TB";
                    string query = @"[PHANTRANG_gaminggear]";
                    DataTable data = sql.ExcuteQuery(query, new Dictionary<string, object>() {
                        {"@PageIndex",id},
                        {"@PageSize",PageSize },
                        {"@MaLoai1",ml1 },
                        {"@MaLoai2",ml2 },
                        {"@MaLoai3",ml3 },
                        {"@MaLoai4",ml4 },
                        {"@MaLoai5",ml5 }
                    });
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        PhuKien.Add(new Linhkien() { MaLK = data.Rows[i][0].ToString(), TenLK = data.Rows[i][1].ToString(), Gia = Convert.ToDouble(data.Rows[i][2].ToString()), Hinh = data.Rows[i][3].ToString() });
                    }
                    ViewBag.tien = tien;
                    ViewBag.lui = lui;
                }
                catch (Exception ex)
                {
                    return View("lỗi");
                }
            }
            ViewBag.PhuKien = PhuKien;
            return View();
        }
        public ActionResult MayIn(int id = 1, int PageSize = 8)
        {
            int tien = (Convert.ToInt32(id)) + 1;
            int lui = (Convert.ToInt32(id)) - 1;
            List<Linhkien> Mayin = new List<Linhkien>();
            string ConnectionString = Properties.Settings.Default.connectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    //string query = @"SELECT MaLK,TenLK,Gia,Hinh1
                    //                FROM LinhKien
                    //                WHERE MaLoai='MIN'";
                    string ml = "MIN";
                    string query = @"[PHANTRANG]";
                    DataTable data = sql.ExcuteQuery(query, new Dictionary<string, object>() {
                       {"@PageIndex",id},
                        {"@PageSize",PageSize },
                        {"@MaLoai",ml }
                    });
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        Mayin.Add(new Linhkien() { MaLK = data.Rows[i][0].ToString(), TenLK = data.Rows[i][1].ToString(), Gia = Convert.ToDouble(data.Rows[i][2].ToString()), Hinh = data.Rows[i][3].ToString() });
                    }
                    ViewBag.tien = tien;
                    ViewBag.lui = lui;
                }
                catch (Exception ex)
                {
                    return View("lỗi");
                }
            }
            ViewBag.MayIn = Mayin;
            return View();
        }
        public ActionResult Loa(int id = 1, int PageSize = 8)
        {
            int tien = (Convert.ToInt32(id)) + 1;
            int lui = (Convert.ToInt32(id)) - 1;
            List<Linhkien> Loa = new List<Linhkien>();
            string ConnectionString = Properties.Settings.Default.connectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    //string query = @"SELECT MaLK ,TenLK,Gia,Hinh1
                    //                FROM LinhKien
                    //                WHERE MaLoai='LOA'";
                    string ml = "LOA";
                    string query = @"[PHANTRANG]";
                    DataTable data = sql.ExcuteQuery(query, new Dictionary<string, object>() {
                       {"@PageIndex",id},
                        {"@PageSize",PageSize },
                        {"@MaLoai",ml }
                    });
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        Loa.Add(new Linhkien() { MaLK = data.Rows[i][0].ToString(), TenLK = data.Rows[i][1].ToString(), Gia = Convert.ToDouble(data.Rows[i][2].ToString()), Hinh = data.Rows[i][3].ToString() });
                    }
                    ViewBag.tien = tien;
                    ViewBag.lui = lui;
                }
                catch (Exception ex)
                {
                    return View("lỗi");
                }
            }
            ViewBag.Loa = Loa;
            return View();
        }
        public ActionResult ThietBiLuuTru(int id = 1, int PageSize = 8)
        {
            int tien = (Convert.ToInt32(id)) + 1;
            int lui = (Convert.ToInt32(id)) - 1;
            List<Linhkien> TB = new List<Linhkien>();
            string ConnectionString = Properties.Settings.Default.connectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    //string query = @"SELECT MaLK,TenLK,Gia,Hinh1
                    //                FROM LinhKien
                    //                WHERE MaLoai='TB'";
                    string ml = "TB";
                    string query = @"[PHANTRANG]";
                    DataTable data = sql.ExcuteQuery(query, new Dictionary<string, object>() {
                        {"@PageIndex",id},
                        {"@PageSize",PageSize },
                        {"@MaLoai",ml }
                    });
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        TB.Add(new Linhkien() { MaLK = data.Rows[i][0].ToString(), TenLK = data.Rows[i][1].ToString(), Gia = Convert.ToDouble(data.Rows[i][2].ToString()), Hinh = data.Rows[i][3].ToString() });
                    }
                    ViewBag.tien = tien;
                    ViewBag.lui = lui;
                }
                catch (Exception ex)
                {
                    return View("lỗi");
                }
            }
            ViewBag.TB = TB;
            return View();
        }
        public ActionResult ThietBiMang(int id = 1, int PageSize = 8)
        {
            int tien = (Convert.ToInt32(id)) + 1;
            int lui = (Convert.ToInt32(id)) - 1;
            List<Linhkien> TBM = new List<Linhkien>();
            string ConnectionString = Properties.Settings.Default.connectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    //string query = @"SELECT MaLK,TenLK,Gia,Hinh1
                    //                FROM LinhKien
                    //                WHERE MaLoai='NIC'";
                    string ml = "NIC";
                    string query = @"[PHANTRANG]";
                    DataTable data = sql.ExcuteQuery(query, new Dictionary<string, object>() {
                       {"@PageIndex",id},
                        {"@PageSize",PageSize },
                        {"@MaLoai",ml }
                    });
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        TBM.Add(new Linhkien() { MaLK = data.Rows[i][0].ToString(), TenLK = data.Rows[i][1].ToString(), Gia = Convert.ToDouble(data.Rows[i][2].ToString()), Hinh = data.Rows[i][3].ToString() });
                    }
                    ViewBag.tien = tien;
                    ViewBag.lui = lui;
                }
                catch (Exception ex)
                {
                    return View("lỗi");
                }
            }
            ViewBag.TBM = TBM;
            return View();
        }
        public ActionResult Details(string id ,comment model)
        {
            List<Linhkien> ChiTiet = new List<Linhkien>();
            string ConnectionString = Properties.Settings.Default.connectionString;
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                string query = "exec [chitiet] @MALK";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.Add("@MALK", id);
                SqlDataAdapter dataApp = new SqlDataAdapter(cmd);
                DataTable data = new DataTable();
                dataApp.Fill(data);
                for (int i = 0; i < data.Rows.Count; i++)
                {    
                    ChiTiet.Add(new Linhkien() { TenLK = data.Rows[i][0].ToString(), Gia = Convert.ToDouble(data.Rows[i][1].ToString()), Hinh = data.Rows[i][2].ToString(), MaLK = data.Rows[i][3].ToString(), Mota = data.Rows[i][4].ToString() });
                }

            }
            List<Linhkien> BANCHAYDETAILS = new List<Linhkien>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                try
                {
                    con.Open();
                    string query = @"select  top 3  MaLK ,TenLK, gia,Hinh1
                                        from LinhKien
                                        where TGBH = 15";
                    SqlCommand cmd = new SqlCommand(query, con);
                    SqlDataAdapter dataApp = new SqlDataAdapter(cmd);
                    DataTable data = new DataTable();
                    dataApp.Fill(data);
                    for (int i = 0; i < data.Rows.Count; i++)
                    {
                        BANCHAYDETAILS.Add(new Linhkien() { MaLK = data.Rows[i][0].ToString(), TenLK = data.Rows[i][1].ToString(), Gia = Convert.ToDouble(data.Rows[i][2].ToString()), Hinh = data.Rows[i][3].ToString() });
                    }
                }
                catch (Exception ex)
                {
                    return View("lỗi");
                }
            }
            List<comment> comment = new List<comment>();
            using (SqlConnection con = new SqlConnection(ConnectionString))
            {
                con.Open();
                string query1 = "exec store_commentDB @MaLK";
                SqlCommand cmd = new SqlCommand(query1, con);
                cmd.Parameters.Add("@MaLK", id);
                SqlDataAdapter dataApp = new SqlDataAdapter(cmd);
                DataTable data = new DataTable();
                dataApp.Fill(data);
                for (int i = 0; i < data.Rows.Count; i++)
                {
                    comment.Add(new comment() { malk = data.Rows[i][0].ToString().Trim(), name = data.Rows[i][1].ToString(), commentkh = data.Rows[i][2].ToString(), date = Convert.ToDateTime( data.Rows[i][3].ToString()), avartar = data.Rows[i][4].ToString() });
                }
            }
            ViewBag.comment = comment;
            ViewBag.BANCHAYDETAILS = BANCHAYDETAILS;
            ViewBag.ChiTiet1 = ChiTiet;
            return View();
        }
        [HttpPost]
        public ActionResult Details1(comment model)
        {
            
            string query = @"store_comment";
            model.avartar = "avartar1.jpg";
            model.date = DateTime.Now;//
            conectDB sql = new conectDB();
            int roweffected = sql.ExcuteNonQuery(query, new Dictionary<string, object>() {
                {"@malk",model.malk },
                {"@name", model.name},
                {"@comment", model.commentkh},
                {"@date", model.date},
                {"@avartar", model.avartar},

            });
            if (roweffected > 0)
            {
                return Json("ok");
            }
            return Json("ERROR");
        }
    }
}

