using DAL.DBContext.Models;
using System.Data.Entity;
using DAL.DBContext.Configs;

namespace DAL.DBContext
{
    public class FotoAlbumContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Foto> Fotos { get; set; }
        //public DbSet<LikedFoto> Likes { get; set; }

        static FotoAlbumContext()
        {
            System.Data.Entity.Database.SetInitializer<FotoAlbumContext>(new FotoAlbumContextInitializer());
        }

        public FotoAlbumContext()
            : base("FotoAlbumDB")
        {
        }

        protected override void OnModelCreating(DbModelBuilder dbModelBuilder)
        {
            dbModelBuilder.Configurations.Add(new UserConfig());
            dbModelBuilder.Configurations.Add(new FotoConfig());
          //  dbModelBuilder.Configurations.Add(new LikeConfig());
        }
    }
}