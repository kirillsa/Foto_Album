using DAL.DBContext.Models;
using System.Data.Entity.ModelConfiguration;

namespace DAL.DBContext.Configs
{
    public class FotoConfig : EntityTypeConfiguration<Foto>
    {
        public FotoConfig()
        {
            ToTable("Fotos");
            HasKey(x => x.Id);
            Property(x => x.Name).HasMaxLength(20);
            Property(x => x.Link).IsRequired();
            Property(x => x.UserOwnerId).IsRequired();
            HasMany(x => x.UsersWithLike).WithMany(x => x.FavoriteFotos)
                .Map(x =>
                    {
                        x.ToTable("FavoriteFotosAndLikers");
                        x.MapLeftKey("FotoId");
                        x.MapRightKey("UserId");
                    });
        }
    }
}
