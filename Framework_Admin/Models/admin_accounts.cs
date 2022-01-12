using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework_Admin.Models
{
    public class admin_accounts
    {
        private int maad;
        private string tenad;
        private string matkhau;

        public int Maad { get => maad; set => maad = value; }
        public string Tenad { get => tenad; set => tenad = value; }
        public string Matkhau { get => matkhau; set => matkhau = value; }

        public admin_accounts() { }
        public admin_accounts(int maad, string tenad, string matkhau)
        {
            this.maad = maad;
            this.tenad = tenad;
            this.matkhau = matkhau;
        }
    }
}
