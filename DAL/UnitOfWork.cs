using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;
using DAL.Interfaces;
using DAL.Repositories;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        private AnkhMorporkContext _context;

        public IRepository<AssassinNpc> _assassinNpcs;

        public IRepository<BeggarNpc> _beggarNpcs;

        public IRepository<FoolNpc> _foolNpcs;

        public UnitOfWork(AnkhMorporkContext context)
        {
            _context = context;

            _assassinNpcs = new Repository<AssassinNpc>(context);
            _beggarNpcs = new Repository<BeggarNpc>(context);
            _foolNpcs = new Repository<FoolNpc>(context);
        }


        public IRepository<AssassinNpc> AssassinNpcs => 
            _assassinNpcs ??= new Repository<AssassinNpc>(_context);

        public IRepository<BeggarNpc> BeggarNpcs => 
            _beggarNpcs ??= new Repository<BeggarNpc>(_context);

        public IRepository<FoolNpc> FoolNpcs => 
            _foolNpcs ??= new Repository<FoolNpc>(_context);

        public void Dispose()
        {
            _context.Dispose();
        }

        public int Save()
        {
            return _context.SaveChanges();
        }
    }
}
