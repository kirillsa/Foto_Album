using System.Collections.Generic;

namespace DAL.DBContext.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Login { get; set; }
        //public int UserAuthorizedID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Foto> Fotos { get; set; }
        public virtual ICollection<Foto> FavoriteFotos { get; set; }

        public User()
        {
            this.Fotos = new List<Foto>();
            this.FavoriteFotos = new List<Foto>(); 
        }
    }
}
