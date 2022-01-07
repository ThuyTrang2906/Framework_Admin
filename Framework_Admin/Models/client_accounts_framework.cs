using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework_Admin.Models
{
    public class client_accounts_framework
    {
        private int matk;
        private string diachi;
        private int diem;
        private string email;
        private string gioitinh;
        private string hoten;
        private string tentk;
        private string matkhau;
        private DateTime ngaysinh;
        private DateTime ngaytao;
        private int sl_giohang;
        private string sodt;
        private string tinhtrang;

        public int Matk { get => matk; set => matk = value; }
        public string Diachi { get => diachi; set => diachi = value; }
        public int Diem { get => diem; set => diem = value; }
        public string Email { get => email; set => email = value; }
        public string Gioitinh { get => gioitinh; set => gioitinh = value; }
        public string Hoten { get => hoten; set => hoten = value; }
        public string Tentk { get => tentk; set => tentk = value; }
        public string Matkhau { get => matkhau; set => matkhau = value; }
        public DateTime Ngaysinh { get => ngaysinh; set => ngaysinh = value; }
        public DateTime Ngaytao { get => ngaytao; set => ngaytao = value; }
        public int Sl_giohang { get => sl_giohang; set => sl_giohang = value; }
        public string Sodt { get => sodt; set => sodt = value; }
        public string Tinhtrang { get => tinhtrang; set => tinhtrang = value; }

        public client_accounts_framework() { }
        public client_accounts_framework(int matk, string diachi, int diem, string email, string gioitinh, string hoten, string tentk, string matkhau, DateTime ngaysinh, DateTime ngaytao, int sl_giohang, string sodt, string tinhtrang)
        {
            this.matk = matk;
            this.diachi = diachi;
            this.diem = diem;
            this.email = email;
            this.gioitinh = gioitinh;
            this.hoten = hoten;
            this.tentk = tentk;
            this.matkhau = matkhau;
            this.ngaysinh = ngaysinh;
            this.ngaytao = ngaytao;
            this.sl_giohang = sl_giohang;
            this.sodt = sodt;
            this.tinhtrang = tinhtrang;
        }
    }
}
