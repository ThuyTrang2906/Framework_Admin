using Framework_Admin.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Framework_Admin.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly StoreContext _storeContext;

        public AdminController(ILogger<AdminController> logger, StoreContext storeContext)
        {
            _logger = logger;
            _storeContext = storeContext;
        }

        public IActionResult Index()
        {

            return View();
        }


        public IActionResult CapNhat_Sach(int Id)
        {
           
            ViewBag.Book = _storeContext.GetBookById(Id);
           // ViewBag.SLBan = _storeContext.GetSLBan(Id); 
            return View();
        }
        public IActionResult ThemSach()
        {
            return View();
        }
        public IActionResult InsertBook(books bk)
        {
             _storeContext.InsertBook(bk);

            return RedirectToAction("Index", "Home");

        }
        public IActionResult UpdateById(books book)
        {
            _storeContext.UpdateBookById(book);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult DeleteBook(int Id)
        {
            _storeContext.XoaSach(Id);
            return RedirectToAction("Index", "Home");

        }


        public IActionResult QL_taikhoan()
        {
           /* var listaccount = _storeContext.GetAccount();
            if (listaccount != null)
            {
                return View(listaccount);
            }*/

           ViewBag.listaccount = _storeContext.GetAccount();
            ViewBag.uservoucher = _storeContext.GetUserVoucher();
            return View();


        }

        public IActionResult KhoaTaiKhoan(client_accounts_framework Id)
        {
           _storeContext.KhoaTK(Id);
            return RedirectToAction("QL_taikhoan", "Admin");
        }

        public IActionResult MoTaiKhoan(client_accounts_framework Id)
        {
            _storeContext.MoTK(Id);
            return RedirectToAction("QL_taikhoan", "Admin");
        }

        public IActionResult DS_KhuyenMai()
        {
            var listKhuyenMai = _storeContext.GetKhuyenMai();
            if (listKhuyenMai != null)
            {
                return View(listKhuyenMai);
            }
            return View();


        }

        public IActionResult CapNhat_KM(int Id)
        {
            ViewBag.khuyenmai=_storeContext.GetKhuyenMaiById(Id);
            return View();

        }

        public IActionResult UpdateKhuyenMaiById(khuyenmais km)
        {
            _storeContext.UpdateKhuyenMaiById(km);
            return RedirectToAction("DS_KhuyenMai", "Admin");
        }

        public IActionResult Xoa_KM(int Id)
        {
            _storeContext.XoaKhuyenMai(Id);
            return RedirectToAction("DS_KhuyenMai", "Admin");

        }

        public IActionResult Them_KM()
        {
            return View();
        }
        public IActionResult InsertKhuyenmai(khuyenmais bk)
        {
            _storeContext.InsertKhuyenmai(bk);
            return RedirectToAction("DS_KhuyenMai", "Admin");

        }


        // ĐƠN HÀNG

        public IActionResult DS_DonHang()
        {
            ViewBag.listDonHang = _storeContext.GetDonHang();
            ViewBag.listaccount = _storeContext.GetAccount();
            
            return View();
        }

        public IActionResult VanChuyen(int Madh, int Matk)
        {
            ViewBag.listDonHang = _storeContext.ViewDonHang(Madh);          
            ViewBag.listaccount = _storeContext.GetAccountById(Matk);
            ViewBag.listbook = _storeContext.GetObject_Book(Madh);
            ViewBag.ThanhTien = _storeContext.TinhThanhTien(Madh);
            return View();
        }
    }
}
