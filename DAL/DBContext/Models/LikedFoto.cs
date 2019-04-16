using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DBContext.Models
{
    public class LikedFoto
    {
        public int Id { get; set; }

        public int FotoId { get; set; }
        public virtual Foto Foto { get; set; }

        public virtual ICollection<User> UsersWithLike { get; set; }

        public LikedFoto()
        {
            UsersWithLike = new List<User>();
        }
    }
}
