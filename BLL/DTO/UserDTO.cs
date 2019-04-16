using System.Collections.Generic;

namespace BLL.DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Login { get; set; }
        //public int UserAuthorizedID { get; set; }
        public string Name { get; set; }
        public ICollection<FotoDTO> Fotos { get; set; }
        public ICollection<FotoDTO> FavoriteFotos { get; set; }

        public UserDTO()
        {
            this.Fotos = new List<FotoDTO>();
            this.FavoriteFotos = new List<FotoDTO>();
        }
    }
}