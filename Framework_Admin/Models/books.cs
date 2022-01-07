using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework_Admin.Models
{
    public class books
    {
        private int masach;
        private int danhgia;
        private int giaban;
        private int giagoc;
        private int giamgia;
        private string hinhanh;
        private string hinhthuc;
        private string mota;
        private DateTime namxb;
        private string ngonngu;
        private string nxb;
        private string sobinhchon;
        private string tacgia;
        private string tensach;     
        private string theloai;
        private int soluong;

        public int Masach { get => masach; set => masach = value; }
        public string Tensach { get => tensach; set => tensach = value; }
        public string Hinhanh { get => hinhanh; set => hinhanh = value; }
        public string Theloai { get => theloai; set => theloai = value; }
        public int Danhgia { get => danhgia; set => danhgia = value; }
        public int Giaban { get => giaban; set => giaban = value; }
        public int Giagoc { get => giagoc; set => giagoc = value; }
        public int Giamgia { get => giamgia; set => giamgia = value; }
        public string Mota { get => mota; set => mota = value; }
        public string Tacgia { get => tacgia; set => tacgia = value; }
        public DateTime Namxb { get => namxb; set => namxb = value; }
        public string Nxb { get => nxb; set => nxb = value; }
        public string Ngonngu { get => ngonngu; set => ngonngu = value; }
        public string Hinhthuc { get => hinhthuc; set => hinhthuc = value; }
        public string Sobinhchon { get => sobinhchon; set => sobinhchon = value; }
        public int Soluong { get => soluong; set => soluong = value; }

        public books() { }

        public books(int Masach, int danhgia, int giaban, int giagoc, int giamgia, string hinhanh, string hinhthuc, string mota, DateTime namxb, string ngonngu, string nxb, string sobinhchon, string tacgia, string tensach, string theloai, int soluong)
        {
            this.masach = Masach;
            this.danhgia = danhgia;
            this.giaban = giaban;
            this.giagoc = giagoc;
            this.giamgia = giamgia;
            this.hinhanh = hinhanh;
            this.hinhthuc = hinhthuc;
            this.mota = mota;
            this.namxb = namxb;
            this.ngonngu = ngonngu;
            this.nxb = nxb;
            this.sobinhchon = sobinhchon;
            this.tacgia = tacgia;
            this.tensach = tensach;
            this.theloai = theloai;
            this.soluong = soluong;
        }





    }
}
