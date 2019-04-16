using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using DAL.DBContext;
using DAL.DBContext.Models;
using DAL.Interfaces;

namespace DAL.Repositories
{
    class UserRepository : IRepository<User>
    {
        private FotoAlbumContext db;

        public UserRepository(FotoAlbumContext context)
        {
            db = context;
        }

        public void Create(User item)
        {
            if (item != null)
            {
                db.Users.Add(item);
            }
        }

        public User Get(int id)
        {
            return db.Users.Find(id);
        }

        public IEnumerable<User> GetAll()
        {
            return db.Users;
        }

        public void Update(User item)
        {
            db.Users.AddOrUpdate(item);
        }

        public void Delete(int id)
        {
            var user = db.Users.Find(id);
            if (user != null)
            {
                db.Users.Remove(user);
            }
        }
    }
}
