using DAL.DBContext.Models;
using System;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Foto> Fotos { get; }
        IRepository<User> Users { get; }
        void Save();
    }
}
