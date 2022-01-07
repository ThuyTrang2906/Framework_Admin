using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework_Admin.Models
{
    public class user_voucher
    {
        private int matk, makm;

        public int Matk { get => matk; set => matk = value; }
        public int Makm { get => makm; set => makm = value; }

        public user_voucher() { }

        public user_voucher(int matk,int makm)
        {
            this.matk = matk;
            this.makm = makm;
        }
    }
}
