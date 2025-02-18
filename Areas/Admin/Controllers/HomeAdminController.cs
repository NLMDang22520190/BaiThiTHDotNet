﻿using BaiThiTHDotNet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace BaiThiTHDotNet.Areas.Admin.Controllers
{
    [Area("admin")]
    [Route("admin")]
    [Route("admin/homeadmin")]
    public class HomeAdminController : Controller
    {
        QlbanVaLiContext db = new QlbanVaLiContext();

        [Route("")]
        [Route("index")]
        public IActionResult Index()
        {
            return View();
        }

        [Route("danhmucsanpham")]
        public IActionResult DanhMucSanPham(int? page)
        {
            int pageSize = 12;
            int pageNuimber = page == null || page < 0 ? 1 : page.Value;

            var listsanpham = db.TDanhMucSps.AsNoTracking().OrderBy(x => x.TenSp);
            PagedList<TDanhMucSp> lst = new PagedList<TDanhMucSp>(listsanpham, pageNuimber, pageSize);

            return View(lst);
        }


        [Route("ThemSanPhamMoi")]
        [HttpGet]

        public IActionResult ThemSanPhamMoi()
        {
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(),
                "MaChatLieu",
                "ChatLieu");
            ViewBag.MaHangSx = new SelectList(db.THangSxes.ToList(),
               "MaHangSx",
               "HangSx");
            ViewBag.MaNuocSx = new SelectList(db.TQuocGia.ToList(),
               "MaNuoc",
               "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(),
               "MaLoai",
               "Loai");
            ViewBag.MaDt = new SelectList(db.TLoaiDts.ToList(),
               "MaDt",
               "TenLoai");
            return View();
        }
        [Route("ThemSanPhamMoi")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult ThemSanPhamMoi(TDanhMucSp SanPham)
        {
            if (ModelState.IsValid)
            {
                db.TDanhMucSps.Add(SanPham);
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham");
            }
            return View(SanPham);
        }
        [Route("SuaSanPham")]
        [HttpGet]

        public IActionResult SuaSanPham(string maSanPham)
        {
            ViewBag.MaChatLieu = new SelectList(db.TChatLieus.ToList(),
                "MaChatLieu",
                "ChatLieu");
            ViewBag.MaHangSx = new SelectList(db.THangSxes.ToList(),
               "MaHangSx",
               "HangSx");
            ViewBag.MaNuocSx = new SelectList(db.TQuocGia.ToList(),
               "MaNuoc",
               "TenNuoc");
            ViewBag.MaLoai = new SelectList(db.TLoaiSps.ToList(),
               "MaLoai",
               "Loai");
            ViewBag.MaDt = new SelectList(db.TLoaiDts.ToList(),
               "MaDt",
               "TenLoai");

            var SanPham = db.TDanhMucSps.Find(maSanPham);
            return View(SanPham);
        }
        [Route("SuaSanPham")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult SuaSanPham(TDanhMucSp SanPham)
        {
            if (ModelState.IsValid)
            {
                db.Entry(SanPham).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("DanhMucSanPham", "HomeAdmin");
            }
            return View(SanPham);
        }
        [Route("XoaSanPham")]
        [HttpGet]
        public IActionResult XoaSanPham(string maSanPham)
        {
            TempData["Message"] = "";
            var chiTietSanPham = db.TChiTietSanPhams.Where(x => x.MaSp == maSanPham).ToList();
            if (chiTietSanPham.Count > 0)
            {
                TempData["Message"] = "Khong xoa duoc san pham nay";
                return RedirectToAction("DanhMucSanPham", "HomeAdmin");
            }
            var anhSanPham = db.TAnhSps.Where(x => x.MaSp == maSanPham);
            if (anhSanPham.Any())
            {
                db.TAnhSps.RemoveRange(anhSanPham);
            }
            db.Remove(db.TDanhMucSps.Find(maSanPham));
            db.SaveChanges();
            TempData["Message"] = "San pham da duoc xoa";
            return RedirectToAction("DanhMucSanPham", "HomeAdmin");
        }

        [Route("quanlynguoidung")]
        public IActionResult QuanLyNguoiDung(int? page)
        {
            int pageSize = 12;
            int pageNumber = page == null || page < 0 ? 1 : page.Value;

            var listuser = db.TUsers.AsNoTracking().OrderBy(x => x.Username);
            PagedList<TUser> lst = new PagedList<TUser>(listuser, pageNumber, pageSize);

            return View(lst);
        }


    }
}
