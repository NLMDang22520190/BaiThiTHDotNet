﻿using BaiThiTHDotNet.Models;
using BaiThiTHDotNet.Repository;

namespace BaiThiTHDotNet.Repository
{
    public class LoaiSpRepositorycs : ILoaiSpRepository
    {
        private readonly QlbanVaLiContext _context;

        public LoaiSpRepositorycs(QlbanVaLiContext context)
        {
            _context = context;
        }


        public TLoaiSp Add(TLoaiSp loaiSp)
        {
            _context.TLoaiSps.Add(loaiSp);
            _context.SaveChanges();
            return loaiSp;
        }

        public TLoaiSp Delete(string maLoaiSp)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<TLoaiSp> GetAllLoaiSp()
        {
            return _context.TLoaiSps; 
        }

        public TLoaiSp GetLoaiSp(string maLoaiSp)
        {
            return _context.TLoaiSps.Find(maLoaiSp);
        }

        public TLoaiSp Update(TLoaiSp loaiSp)
        {
            _context.Update(loaiSp);
            _context.SaveChanges();
            return loaiSp;
        }
    }
}
