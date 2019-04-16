using System;
using DAL.DBContext;
using DAL.DBContext.Models;
using DAL.Interfaces;
using DAL.Repositories;

namespace DAL
{
    public class EF_UnitOfWork : IUnitOfWork
    {
        private FotoAlbumContext _db;
        private IRepository<User> _userRepository;
        private IRepository<Foto> _fotoRepository;
        private bool _disposed = false;

        public EF_UnitOfWork()
        {
            _db = new FotoAlbumContext();
        }

        public IRepository<User> Users
        {
            get
            {
                if (_userRepository == null)
                {
                    _userRepository = new UserRepository(_db);
                }

                return _userRepository;
            }
        }

        public IRepository<Foto> Fotos
        {
            get
            {
                if (_fotoRepository == null)
                {
                    _fotoRepository = new FotoRepository(_db);
                }

                return _fotoRepository;
            }
        }

        public void Save()
        {
            _db.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!this._disposed)
            {
                if (disposing)
                {
                    _db.Dispose();
                }
                this._disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}