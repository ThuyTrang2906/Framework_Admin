using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework_Admin.Models
{
    public class khuyenmais
    {
        private int daluu, dieukien, makm, phantram, sl;
        private string img, loai, manhap, noidung;
        private DateTime ngaybd, ngaykt;

        public int Daluu { get => daluu; set => daluu = value; }
        public int Dieukien { get => dieukien; set => dieukien = value; }
        public int Makm { get => makm; set => makm = value; }
        public int Phantram { get => phantram; set => phantram = value; }
        public int Sl { get => sl; set => sl = value; }

        public string Img { get => img; set => img = value; }
        public string Loai { get => loai; set => loai = value; }
        public string Manhap { get => manhap; set => manhap = value; }
        public string Noidung { get => noidung; set => noidung = value; }

        public DateTime Ngaybd { get => ngaybd; set => ngaybd = value; }
        public DateTime Ngaykt { get => ngaykt; set => ngaykt = value; }

        public khuyenmais() { }
        public khuyenmais(int daluu, int dieukien, string img, string loai, int makm, string manhap, DateTime ngaybd, DateTime ngaykt, string noidung, int phantram, int sl)
        {
            this.daluu = daluu;
            this.dieukien = dieukien;
            this.img = img;
            this.loai = loai;
            this.makm = makm;
            this.manhap = manhap;
            this.ngaybd = ngaybd;
            this.ngaykt = ngaykt;
            this.noidung = noidung;
            this.phantram = phantram;
            this.sl = sl;

        }
    }
}
