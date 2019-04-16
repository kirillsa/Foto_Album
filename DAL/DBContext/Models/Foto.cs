using System.Collections.Generic;

namespace DAL.DBContext.Models
{
    public class Foto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }

        public int UserOwnerId { get; set; }
        public virtual User UserOwner { get; set; }

        public virtual ICollection<User> UsersWithLike { get; set; }

        public Foto()
        {
            UsersWithLike = new List<User>();
        }
    }
}