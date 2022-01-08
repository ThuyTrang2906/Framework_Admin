using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework_Admin.Models
{
    public class StoreContext
    {
        public string ConnectionString { get; set; }//biết thành viên
        public StoreContext(string connectionString) //phuong thuc khoi tao
        {
            this.ConnectionString = connectionString;
        }
        private MySqlConnection GetConnection() //lấy connection
        {
            return new MySqlConnection(ConnectionString);
        }

        // Quản lý sách

        public List<books> GetBook()
        {
            List<books> list = new List<books>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from booklist";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new books()
                        {
                            Masach = Convert.ToInt32(reader["masach"]),
                            Danhgia = Convert.ToInt32(reader["danhgia"]),
                            Giaban = Convert.ToInt32(reader["giaban"]),
                            Giagoc = Convert.ToInt32(reader["giagoc"]),
                            Giamgia = Convert.ToInt32(reader["giamgia"]),
                          
                            Hinhanh = reader["hinhanh"].ToString(),
                            Hinhthuc = reader["hinhthuc"].ToString(),
                            Mota = reader["mota"].ToString(),
                            Ngonngu = reader["ngonngu"].ToString(),
                            Nxb = reader["nxb"].ToString(),
                            Sobinhchon = reader["sobinhchon"].ToString(),
                            Tacgia = reader["tacgia"].ToString(),
                            Namxb = Convert.ToDateTime(reader["namxb"]),

                            Tensach = reader["tensach"].ToString(),
                            Theloai = reader["theloai"].ToString(),
                            Soluong = Convert.ToInt32(reader["soluong"]),
                        });
                    }
                    reader.Close();
                }

                conn.Close();

            }
            return list;
        }

        public int InsertBook(books bk)
        {
            using(MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "INSERT INTO booklist values(@masach, @danhgia, @giaban, @giagoc, @giamgia, @hinhanh, @hinhthuc, @mota, @namxb,@ngonngu, @nxb, @sobinhchon, @tacgia, @tensach, @theloai, @soluong )";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("masach", bk.Masach);
                cmd.Parameters.AddWithValue("danhgia", bk.Danhgia);
                cmd.Parameters.AddWithValue("giaban", bk.Giaban);
                cmd.Parameters.AddWithValue("giagoc", bk.Giagoc);
                cmd.Parameters.AddWithValue("giamgia", bk.Giamgia);
                cmd.Parameters.AddWithValue("hinhanh", bk.Hinhanh);
                cmd.Parameters.AddWithValue("hinhthuc", bk.Hinhthuc);
                cmd.Parameters.AddWithValue("mota", bk.Mota);
                cmd.Parameters.AddWithValue("namxb", bk.Namxb);
                cmd.Parameters.AddWithValue("ngonngu", bk.Ngonngu);
                cmd.Parameters.AddWithValue("nxb", bk.Nxb);
                cmd.Parameters.AddWithValue("sobinhchon", bk.Sobinhchon);
                cmd.Parameters.AddWithValue("tacgia", bk.Tacgia);
                cmd.Parameters.AddWithValue("tensach", bk.Tensach);
                cmd.Parameters.AddWithValue("theloai", bk.Theloai);
                cmd.Parameters.AddWithValue("soluong", bk.Soluong);
                return cmd.ExecuteNonQuery();
            }
        }

        public int XoaSach(string Id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "delete from booklist where masach=@Masach";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("Masach", Id);
                return (cmd.ExecuteNonQuery());
            }
        }

        public books GetBookById(string masach, string tensach, string hinhanh, string theloai, string tacgia, string nxb, string sl)
        {
            books list = new books();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from booklist where masach=@Masach and tensach=@Tensach and Hinhanh=@Hinhanh and theloai=@Theloai and tacgia=@Tacgia and nxb=@nxb and soluong=@Soluong";
                
                MySqlCommand d = new MySqlCommand(str, conn);
                d.Parameters.AddWithValue("Masach", masach);
                d.Parameters.AddWithValue("Tensach", tensach);
                d.Parameters.AddWithValue("Hinhanh", hinhanh);
                d.Parameters.AddWithValue("Theloai", theloai);
                d.Parameters.AddWithValue("Tacgia", tacgia);
                d.Parameters.AddWithValue("Nxb", nxb);
                d.Parameters.AddWithValue("Soluong", sl);
                using (var reader = d.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        list.Masach = Convert.ToInt32(reader["masach"]);
                        list.Danhgia = Convert.ToInt32(reader["danhgia"]);
                        list.Giaban = Convert.ToInt32(reader["giaban"]);
                        list.Giagoc = Convert.ToInt32(reader["giagoc"]);
                        list.Giamgia = Convert.ToInt32(reader["giamgia"]);
                        list.Hinhanh = reader["hinhanh"].ToString();
                        list.Hinhthuc = reader["hinhthuc"].ToString();                        
                        list.Mota = reader["mota"].ToString();
                        list.Nxb = reader["nxb"].ToString();
                        list.Sobinhchon = reader["sobinhchon"].ToString();
                        list.Tacgia = reader["tacgia"].ToString();
                        list.Namxb = Convert.ToDateTime(reader["namxb"]);
                        list.Tensach = reader["tensach"].ToString();
                        list.Theloai = reader["theloai"].ToString();
                        list.Soluong = Convert.ToInt32(reader["soluong"]);

                    }
                };

                conn.Close();

            }
            return list;
        }

        public int UpdateBookById(books kh)
        {
            Console.WriteLine(kh.Masach);
            using (MySqlConnection conn = GetConnection())
            {

                conn.Open();
                var str = "UPDATE  booklist SET danhgia=@danhgia,giaban=@giaban,giagoc=@giagoc,giamgia=@giamgia," +
                    "hinhanh=@hinhanh,hinhthuc=@hinhthuc,mota=@mota,namxb=@namxb,ngonngu=@ngonngu,nxb=@nxb," +
                    "sobinhchon=@sobinhchon,tacgia=@tacgia,tensach=@tensach, soluong=@soluong, theloai=@theloai WHERE masach=@masach";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("masach", kh.Masach);
                cmd.Parameters.AddWithValue("danhgia", kh.Danhgia);
                cmd.Parameters.AddWithValue("giaban", kh.Giaban);
                cmd.Parameters.AddWithValue("giagoc", kh.Giagoc);
                cmd.Parameters.AddWithValue("giamgia", kh.Giamgia);
                cmd.Parameters.AddWithValue("hinhanh", kh.Hinhanh);
                cmd.Parameters.AddWithValue("hinhthuc", kh.Hinhthuc);
                cmd.Parameters.AddWithValue("mota", kh.Mota);
                cmd.Parameters.AddWithValue("namxb", kh.Namxb);
                cmd.Parameters.AddWithValue("ngonngu", kh.Ngonngu);
                cmd.Parameters.AddWithValue("nxb", kh.Nxb);
                cmd.Parameters.AddWithValue("sobinhchon", kh.Sobinhchon);
                cmd.Parameters.AddWithValue("tacgia", kh.Tacgia);
                cmd.Parameters.AddWithValue("tensach", kh.Tensach);
                cmd.Parameters.AddWithValue("theloai", kh.Theloai);
                cmd.Parameters.AddWithValue("soluong", kh.Soluong);


                return (cmd.ExecuteNonQuery());
            }
        }


        // Quản lý tài khoản]
        public List<client_accounts_framework> GetAccount()
        {
            List<client_accounts_framework> list = new List<client_accounts_framework>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from client_accounts";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new client_accounts_framework()
                        {
                            Diachi = reader["diachi"].ToString(),
                            Matk = Convert.ToInt32(reader["matk"]),
                            Diem = Convert.ToInt32(reader["diem"]),
                            Sl_giohang = Convert.ToInt32(reader["sl_giohang"]),
                            Email = reader["email"].ToString(),
                            Gioitinh = reader["gioitinh"].ToString(),
                            Hoten = reader["hoten"].ToString(),
                            Tentk = reader["tentk"].ToString(),
                            Matkhau = reader["matkhau"].ToString(),
                            //Ngaytao = Convert.ToDateTime(reader["ngaytao"]),
                            Tinhtrang = reader["tinhtrang"].ToString(),
                            Sodt = reader["sodt"].ToString(),
                            
                              Ngaytao = Convert.ToDateTime(reader["ngaytao"]),
                              Ngaysinh = Convert.ToDateTime(reader["ngaysinh"]),


                        });
                    }
                    reader.Close();
                }

                conn.Close();

            }
            return list;
        }

        public int KhoaTK(client_accounts_framework kh)
        {

            using (MySqlConnection conn = GetConnection())
            {

                conn.Open();
                var str = "UPDATE client_accounts SET tinhtrang='Đã khóa' WHERE matk=@matk";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                Console.WriteLine(kh.Matk);
                Console.WriteLine(kh.Tinhtrang);
                cmd.Parameters.AddWithValue("matk", kh.Matk);
                cmd.Parameters.AddWithValue("Đã khóa", kh.Tinhtrang);
                return (cmd.ExecuteNonQuery());
            }
        }

        public int MoTK(client_accounts_framework kh)
        {

            using (MySqlConnection conn = GetConnection())
            {

                conn.Open();
                var str = "UPDATE client_accounts SET tinhtrang='Đang sử dụng' WHERE matk=@matk";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                Console.WriteLine(kh.Matk);
                Console.WriteLine(kh.Tinhtrang);
                cmd.Parameters.AddWithValue("matk", kh.Matk);
                cmd.Parameters.AddWithValue("Đang sử dụng", kh.Tinhtrang);
                return (cmd.ExecuteNonQuery());
            }
        }


        public List<user_voucher> GetUserVoucher()
        {
            List<user_voucher> list = new List<user_voucher>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from user_voucher";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new user_voucher()
                        {
                           
                            Makm = Convert.ToInt32(reader["makm"]),
                            Matk = Convert.ToInt32(reader["matk"]),

                        });
                    }
                    reader.Close();
                }

                conn.Close();

            }
            return list;
        }


        //Quản lý khuyến mãi
        public List<khuyenmais> GetKhuyenMai()
        {
            List<khuyenmais> list = new List<khuyenmais>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from khuyenmais";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new khuyenmais()
                        {
                            Img = reader["img"].ToString(),
                            Daluu = Convert.ToInt32(reader["daluu"]),
                            Dieukien = Convert.ToInt32(reader["dieukien"]),
                            Makm = Convert.ToInt32(reader["makm"]),
                            Phantram = Convert.ToInt32(reader["phantram"]),
                            Sl = Convert.ToInt32(reader["sl"]),

                            Loai = reader["loai"].ToString(),
                            Manhap = reader["manhap"].ToString(),
                            Noidung = reader["noidung"].ToString(),
                            
                             Ngaybd = Convert.ToDateTime(reader["ngaybd"]),
                             Ngaykt = Convert.ToDateTime(reader["ngaykt"]),


                        });
                    }
                    reader.Close();
                }

                conn.Close();

            }
            return list;
        }

        public khuyenmais GetKhuyenMaiById(string id)
        {
            khuyenmais list = new khuyenmais();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from khuyenmais where makm=@makm";

                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("makm", id);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list = new khuyenmais()
                        {
                            Img = reader["img"].ToString(),
                            Daluu = Convert.ToInt32(reader["daluu"]),
                            Dieukien = Convert.ToInt32(reader["dieukien"]),
                            Makm = Convert.ToInt32(reader["makm"]),
                            Phantram = Convert.ToInt32(reader["phantram"]),
                            Sl = Convert.ToInt32(reader["sl"]),
                            Loai = reader["loai"].ToString(),
                            Manhap = reader["manhap"].ToString(),
                            Noidung = reader["noidung"].ToString(),

                            Ngaybd = Convert.ToDateTime(reader["ngaybd"]),
                            Ngaykt = Convert.ToDateTime(reader["ngaykt"]),

                        };
                    }
                    reader.Close();
                }

                conn.Close();

            }
            return list;
        }

        //Quản lý đơn hàng'

        public List<orders> GetDonHang()
        {
            List<orders> list = new List<orders>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from orders";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        list.Add(new orders()
                        {

                            Madh = Convert.ToInt32(reader["madh"]),
                            Matk = Convert.ToInt32(reader["matk"]),
                            Makm = Convert.ToInt32(reader["makm"]),

                            Tienship = Convert.ToInt32(reader["tienship"]),
                            Phanhoi = reader["phanhoi"].ToString(),
                            Tinhtrangdonhang = reader["tinhtrangdonhang"].ToString(),
                            Tinhtrangthanhtoan = reader["tinhtrangthanhtoan"].ToString(),
                            Tongtien = Convert.ToInt32(reader["tongtien"]),
                            Hinhthucthanhtoan = reader["hinhthucthanhtoan"].ToString(),

                               Ngaycapnhat = Convert.ToDateTime(reader["ngaycapnhat"]),
                               Ngaylap = Convert.ToDateTime(reader["ngaylap"]),


                        });
                    }
                    reader.Close();
                }

                conn.Close();

            }
            return list;
        }

        public orders ViewDonHang(string Id)
        {
            orders kh = new orders();
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "select * from orders where madh=@Id";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("Id", Id);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        kh = new orders()
                        {
                            Madh = Convert.ToInt32(reader["madh"]),
                            Matk = Convert.ToInt32(reader["matk"]),
                            Makm = Convert.ToInt32(reader["makm"]),

                            Tienship = Convert.ToInt32(reader["tienship"]),
                            Phanhoi = reader["phanhoi"].ToString(),

                            Tinhtrangdonhang = reader["tinhtrangdonhang"].ToString(),
                            Tinhtrangthanhtoan = reader["tinhtrangthanhtoan"].ToString(),
                            Tongtien = Convert.ToInt32(reader["tongtien"]),
                            Hinhthucthanhtoan = reader["hinhthucthanhtoan"].ToString(),



                          Ngaycapnhat = Convert.ToDateTime(reader["ngaycapnhat"]),
                           Ngaylap = Convert.ToDateTime(reader["ngaylap"]),
                        }; 
                    } 
                }
            }
            return (kh);
        }

    }
}
