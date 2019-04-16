using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using DAL.DBContext;
using DAL.DBContext.Models;
using DAL.Interfaces;

namespace DAL.Repositories
{
    class FotoRepository : IRepository<Foto>
    {
        private FotoAlbumContext db;

        public FotoRepository(FotoAlbumContext context)
        {
            db = context;
        }

        public void Create(Foto item)
        {
            if (item != null)
            {
                db.Fotos.Add(item);
            }
        }

        public Foto Get(int id)
        {
            return db.Fotos.Find(id);
        }

        public IEnumerable<Foto> GetAll()
        {
            return db.Fotos;
        }

        public void Update(Foto item)
        {
            db.Fotos.AddOrUpdate(item);
        }

        public void Delete(int id)
        {
            var foto = db.Fotos.Find(id);
            if (foto != null)
            {
                db.Fotos.Remove(foto);
            }
        }
    }
}
