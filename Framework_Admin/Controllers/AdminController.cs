using Framework_Admin.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
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
            ViewBag.khuyenmai = _storeContext.GetKhuyenMai();
            return View();



        }

        public IActionResult CapNhap_KM(int Id)
        {
            ViewBag.khuyenmai =_storeContext.GetKhuyenMaiById(Id);
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
        public IActionResult FilterDonHang(DateTime start, DateTime end)
        {
            ViewBag.listDonHang = _storeContext.FilterDonHang(start, end);
            ViewBag.listaccount = _storeContext.GetAccount();
            return View("DS_DonHang");
                
        }
        public IActionResult FilterCNDonHang(DateTime start, DateTime end)
        {
            ViewBag.listDonHang = _storeContext.FilterDonHang(start, end);
            ViewBag.listaccount = _storeContext.GetAccount();
            return View("CapNhat_VanChuyen");

        }
        public IActionResult VanChuyen(int Madh, int Matk)
        {
            ViewBag.listDonHang = _storeContext.ViewDonHang(Madh);          
            ViewBag.listaccount = _storeContext.GetAccountById(Matk);
            ViewBag.listbook = _storeContext.GetObject_Book(Madh);
            ViewBag.ThanhTien = _storeContext.TinhThanhTien(Madh);
            ViewBag.TienGiam = _storeContext.GetPhanTramKM(Madh);
            return View();
        }

        public IActionResult CapNhat_VanChuyen()
        {

            ViewBag.listDonHang = _storeContext.GetDonHang();
            ViewBag.listaccount = _storeContext.GetAccount();
            return View();
        }
       

        public IActionResult UpdateDonHangById(int Id,string Tinhtrangdonhang,string Phanhoi)
        {
            _storeContext.UpdateDonHangById(Id,Tinhtrangdonhang,Phanhoi);
            return RedirectToAction("CapNhat_VanChuyen", "Admin");
        }

        public IActionResult ThongKe()
        {
            ViewBag.ThongKe = _storeContext.ThongKe();
            ViewBag.ThongKeTheLoai = _storeContext.GetThongKeTheLoai();
            ViewBag.DataDoanhThu = _storeContext.DataDoanhThu();
            
            return View();
        }

        public IActionResult FilterThongKe(DateTime start, DateTime end)
        {
            ViewBag.ThongKe = _storeContext.FilterThongKe(start, end);
            ViewBag.ThongKeTheLoai = _storeContext.FilterThongKeTheLoai( start,  end);
            return View("ThongKe");

        }

        public IActionResult login()
        {
            string username = HttpContext.Request.Form["username"];
            string password = HttpContext.Request.Form["password"];

            StoreContext context = HttpContext.RequestServices.GetService(typeof(Framework_Admin.Models.StoreContext)) as StoreContext;
            admin_accounts res = context.login(username, password);
            if (res != null)
            {
                ViewBag.status = "Success";
                ViewBag.infor = res;
                HttpContext.Session.SetString("UserSession", JsonSerializer.Serialize(res));
            }
            else
            {
                ViewBag.status = "Fail";
            }
            return View();
        }
    }
}
