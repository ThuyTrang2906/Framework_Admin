﻿using MySql.Data.MySqlClient;
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

        public List<object> GetBook( int soLS)
        {
            List<object> list = new List<object>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select s.masach,danhgia,giaban,giagoc,giamgia,hinhanh,hinhthuc,mota,ngonngu,nxb,sobinhchon,tacgia,namxb,tensach, theloai, s.soluong, sum(o.soluong) as soluongban  from booklist s, detail_order o where s.masach=o.masach group by s.masach,danhgia,giaban,giagoc,giamgia,hinhanh,hinhthuc,mota,ngonngu,nxb,sobinhchon,tacgia,namxb,tensach, theloai, s.soluong";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("soluongban", soLS);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var ob = new 
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
                            Soluongban= Convert.ToInt32(reader["soluongban"]),
                        };
                        list.Add(ob);
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

        public int XoaSach(int Id)
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

        public books GetBookById(int Id)
        {

            books list = new books();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from booklist where masach=@Masach";
                
                MySqlCommand d = new MySqlCommand(str, conn);
                d.Parameters.AddWithValue("Masach", Id);
                

                using (var reader = d.ExecuteReader())
                {
                    reader.Read();
                    
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
                    list.Masach = Convert.ToInt32(reader["masach"]);

                };
            }
            return list;
        }

        public int GetSLBan(int Id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                int sumsoluong = 0;
                conn.Open();
                string str = "select sum(soluong) as sl from detail_order where masach=@Masach";

                MySqlCommand d = new MySqlCommand(str, conn);
                d.Parameters.AddWithValue("Masach", Id);

                using (var reader = d.ExecuteReader())
                {
                    reader.Read();
                    sumsoluong = Convert.ToInt32(reader["sl"]);

                };
                return sumsoluong;
            }
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
                            Ngaytao = Convert.ToDateTime(reader["ngaytao"]),
                            Tinhtrang = reader["tinhtrang"].ToString(),
                            Sodt = reader["sodt"].ToString(),
                            Ngaysinh = Convert.ToDateTime(reader["ngaysinh"]),


                        });
                    }
                    reader.Close();
                }

                conn.Close();

            }
            return list;
        }

        public List<client_accounts_framework> GetAccountById(int Id)
        {
            List<client_accounts_framework> list = new List<client_accounts_framework>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select * from client_accounts where matk=@matk";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("matk", Id);
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
                            Ngaytao = Convert.ToDateTime(reader["ngaytao"]),
                            Tinhtrang = reader["tinhtrang"].ToString(),
                            Sodt = reader["sodt"].ToString(),
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

        public khuyenmais GetKhuyenMaiById(int id)
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
                    if (reader.Read())
                    {
                        list.Daluu = Convert.ToInt32(reader["daluu"]);
                        list.Dieukien = Convert.ToInt32(reader["dieukien"]);
                        list.Makm = Convert.ToInt32(reader["makm"]);
                        list.Phantram = Convert.ToInt32(reader["phantram"]);
                        list.Sl = Convert.ToInt32(reader["sl"]);
                        list.Loai = reader["loai"].ToString();
                        list.Manhap = reader["manhap"].ToString();
                        list.Noidung = reader["noidung"].ToString();
                        list.Img = reader["img"].ToString();

                        list.Ngaybd = Convert.ToDateTime(reader["ngaybd"]);
                        list.Ngaykt = Convert.ToDateTime(reader["ngaykt"]);
                    }
                    
                    };
                return list;

            }
        }

        public int UpdateKhuyenMaiById(khuyenmais kh)
        {
            using (MySqlConnection conn = GetConnection())
            {

                conn.Open();
                var str = "UPDATE  khuyenmais SET daluu=@daluu,dieukien=@dieukien,img=@img,loai=@loai," +
                    "manhap=@manhap,ngaybd=@ngaybd,ngaykt=@ngaykt,noidung=@noidung,phantram=@phantram,sl=@sl," +
                    " WHERE makm=@makm";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("daluu", kh.Daluu);
                cmd.Parameters.AddWithValue("dieukien", kh.Dieukien);
                cmd.Parameters.AddWithValue("img", kh.Img);
                cmd.Parameters.AddWithValue("loai", kh.Loai);
                cmd.Parameters.AddWithValue("manhap", kh.Manhap);
                cmd.Parameters.AddWithValue("ngaybd", kh.Ngaybd);
                cmd.Parameters.AddWithValue("ngaykt", kh.Ngaykt);
                cmd.Parameters.AddWithValue("phantram", kh.Phantram);
                cmd.Parameters.AddWithValue("sl", kh.Sl);
                cmd.Parameters.AddWithValue("noidung", kh.Noidung);
                
                return (cmd.ExecuteNonQuery());
            }
        }

        public int XoaKhuyenMai(int Id)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                var str = "delete from khuyenmais where makm=@Makm";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("Makm", Id);
                return (cmd.ExecuteNonQuery());
            }
        }

        public int InsertKhuyenmai(khuyenmais bk)
        {
            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "INSERT INTO khuyenmais values(@daluu, @dieukien, @img, @loai, @makm, @manhap, @ngaybd, @ngaykt, @noidung,@phantram, @sl )";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("daluu", bk.Daluu);
                cmd.Parameters.AddWithValue("dieukien", bk.Dieukien);
                cmd.Parameters.AddWithValue("img", bk.Img);
                cmd.Parameters.AddWithValue("loai", bk.Loai);
                cmd.Parameters.AddWithValue("makm", bk.Makm);
                cmd.Parameters.AddWithValue("manhap", bk.Manhap);
                cmd.Parameters.AddWithValue("ngaybd", bk.Ngaybd);
                cmd.Parameters.AddWithValue("ngaykt", bk.Ngaykt);
                cmd.Parameters.AddWithValue("noidung", bk.Noidung);
                cmd.Parameters.AddWithValue("phantram", bk.Phantram);
                cmd.Parameters.AddWithValue("sl", bk.Sl);
                return cmd.ExecuteNonQuery();
            }
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

        public orders ViewDonHang(int Id)
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

        public List<object> GetObject_Book(int Id)
        {
            List<object> list = new List<object>();

            using (MySqlConnection conn = GetConnection())
            {
                conn.Open();
                string str = "select o.masach,tongtien, giaban, o.soluong, o.madh, tienship from booklist s, detail_order o, orders where s.masach=o.masach and orders.madh=o.madh and o.madh=@Madh";
                int thanhtien = 0;
                int sll = 0;
                int gb = 0;
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("Madh", Id);

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var ob = new
                        {
                            Masach = Convert.ToInt32(reader["masach"]),
                            Giaban = Convert.ToInt32(reader["giaban"]),
                            Soluong = Convert.ToInt32(reader["soluong"]),
                            Tongtien = Convert.ToInt32(reader["tongtien"]),
                            Madh = Convert.ToInt32(reader["madh"]),
                            Tienship = Convert.ToInt32(reader["tienship"]),
                            thanhtien = Convert.ToInt32(reader["soluong"])* Convert.ToInt32(reader["giaban"]),
                    };
                        list.Add(ob);
                    }
                    reader.Close();
                }

                conn.Close();

            }
            return list;
        }

        public int TinhThanhTien(int Madh)
        {
            using(MySqlConnection conn = GetConnection())
            {
                int thanhtien = 0; 
                int Tongtien = 0;
                int Tienship = 0;
                conn.Open();
                string str = "SELECT tongtien, tienship  from booklist b, detail_order o, orders where b.masach=o.masach and o.madh=orders.madh and o.madh=@madh";
                MySqlCommand cmd = new MySqlCommand(str, conn);
                cmd.Parameters.AddWithValue("madh", Madh);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        reader.Read();
                        Tongtien = Convert.ToInt32(reader["tongtien"]);
                        Tienship = Convert.ToInt32(reader["tienship"]);
                        thanhtien = Tongtien - Tienship;
                    }
                }
                return thanhtien;

            }
        }

       

    }
}
