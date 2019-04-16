using System.Collections.Generic;
using System.Data.Entity;
using DAL.DBContext.Models;

namespace DAL.DBContext
{
    public class FotoAlbumContextInitializer : DropCreateDatabaseAlways<FotoAlbumContext>
    {
        protected override void Seed (FotoAlbumContext db)
        {
            User user1 = new User() { Login = "user1", Name = "user1Name" };
            User user2 = new User() { Login = "user2", Name = "user2Name" };
            User user3 = new User() { Login = "user3", Name = "user3Name" };
            User user4 = new User() { Login = "user4", Name = "user4Name" };
            db.Users.AddRange(new List<User>() { user1, user2, user3, user4 });

            Foto foto1 = new Foto() { Link = "foto1.jpg", UserOwner = user1 };
            Foto foto2 = new Foto() { Link = "foto2.jpg", UserOwner = user2 };
            Foto foto3 = new Foto() { Link = "foto3.jpg", UserOwner = user3 };
            Foto foto4 = new Foto() { Link = "foto4.jpg", UserOwner = user1 };
            db.Fotos.AddRange(new List<Foto>() { foto1, foto2, foto3, foto4 });
            db.SaveChanges();
        }
    }
}