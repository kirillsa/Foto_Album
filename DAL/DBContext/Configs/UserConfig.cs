using DAL.DBContext.Models;
using System.Data.Entity.ModelConfiguration;

namespace DAL.DBContext.Configs
{
    public class UserConfig : EntityTypeConfiguration<User>
    {
        public UserConfig()
        {
            HasKey(x => x.Id);
            //Property(x => x.UserAuthorizedID).IsRequired();
            Property(x => x.Name).HasMaxLength(20);
            HasMany(x => x.Fotos).WithRequired(x => x.UserOwner).HasForeignKey(x => x.UserOwnerId).WillCascadeOnDelete(false);
            //HasMany(x => x.FavoriteFotos).WithMany(x => x.UsersWithLike);
            
        }

    }
}
