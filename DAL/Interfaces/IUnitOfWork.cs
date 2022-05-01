using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<AssassinNpc> AssassinNpcs { get; }

        IRepository<BeggarNpc> BeggarNpcs { get; }

        IRepository<FoolNpc> FoolNpcs { get; }

        int Save();
    }
}
