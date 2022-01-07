﻿using Framework_Admin.Models;
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


        public IActionResult CapNhat_Sach(string Id)
        {
            return View(_storeContext.GetBookById(Id));
        }

        public IActionResult UpdateById(books book)
        {
            _storeContext.UpdateBookById(book);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult DeleteBook(string Id)
        {
            // ViewData["id"] = Id;
            int count = _storeContext.XoaSach(Id);
            /*if (count > 0)
                ViewData["thongbao"] = "Xóa thành công";
            else
                ViewData["thongbao"] = "Xóa không thành công";*/
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

        public IActionResult CapNhat_KM(string Id)
        {
            return View(_storeContext.GetKhuyenMaiById(Id));
        }

        // ĐƠN HÀNG

        public IActionResult DS_DonHang()
        {
            ViewBag.listDonHang = _storeContext.GetDonHang();
            ViewBag.listaccount = _storeContext.GetAccount();
            return View();
        }

        public IActionResult VanChuyen(string Id)
        {
            orders kh = _storeContext.ViewDonHang(Id);
            ViewBag.listaccount = _storeContext.GetAccount();
            ViewData.Model = kh;
            return View();
        }
    }
}