using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework_Admin.Models
{
    public class orders
    {
        private int madh, makm, matk, tienship, tongtien;
        private string hinhthucthanhtoan, phanhoi, tinhtrangdonhang, tinhtrangthanhtoan;
        private DateTime ngaycapnhat, ngaylap;

        public int Madh { get => madh; set => madh = value; }
        public int Makm { get => makm; set => makm = value; }
        public int Matk { get => matk; set => matk = value; }
        public int Tienship { get => tienship; set => tienship = value; }
        public int Tongtien { get => tongtien; set => tongtien = value; }

        public string Hinhthucthanhtoan { get => hinhthucthanhtoan; set => hinhthucthanhtoan = value; }
        public string Phanhoi { get => phanhoi; set => phanhoi = value; }
        public string Tinhtrangdonhang { get => tinhtrangdonhang; set => tinhtrangdonhang = value; }
        public string Tinhtrangthanhtoan { get => tinhtrangthanhtoan; set => tinhtrangthanhtoan = value; }

        public DateTime Ngaycapnhat { get => ngaycapnhat; set => ngaycapnhat = value; }
        public DateTime Ngaylap { get => ngaylap; set => ngaylap = value; }

        public orders() { }

        public orders(int madh, string hinhthucthanhtoan, int makm, int matk, DateTime ngaycapnhat, DateTime ngaylap, string phanhoi, int tienship, string tinhtrangdonhang, string tinhtrangthanhtoan, int tongtien)
        {
            this.madh = madh;
            this.hinhthucthanhtoan = hinhthucthanhtoan;
            this.makm = makm;
            this.matk = matk;
            this.ngaycapnhat = ngaycapnhat;
            this.ngaylap = ngaylap;
            this.phanhoi = phanhoi;
            this.tienship = tienship;
            this.tinhtrangdonhang = tinhtrangdonhang;
            this.tinhtrangthanhtoan = tinhtrangthanhtoan;
            this.tongtien = tongtien;
        }
    }
}
