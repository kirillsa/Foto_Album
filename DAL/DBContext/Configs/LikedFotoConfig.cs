using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DBContext.Models;

namespace DAL.DBContext.Configs
{
    public class LikedFotoConfig : EntityTypeConfiguration<LikedFoto>
    {
        public LikedFotoConfig()
        {
            HasKey(x => x.Id);
            Property(x => x.FotoId).IsRequired();
            //HasMany(x => x.UsersWithLike).WithMany(x => x.FavoriteFotos);
        }
    }
}
