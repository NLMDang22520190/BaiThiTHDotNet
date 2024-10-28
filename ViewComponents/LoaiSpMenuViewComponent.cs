using BaiThiTHDotNet.Repository;
using Microsoft.AspNetCore.Mvc;

namespace BaiThiTHDotNet.ViewComponents
{
    public class LoaiSpMenuViewComponent : ViewComponent
    {
        private readonly ILoaiSpRepository _loaiSp;

        public LoaiSpMenuViewComponent(ILoaiSpRepository loaiSpRepository)
        {
            _loaiSp = loaiSpRepository;
        }

        public IViewComponentResult Invoke()
        {
            var loaiSps = _loaiSp.GetAllLoaiSp().OrderBy(x => x.Loai);
            return View(loaiSps);
        }
    }
}
