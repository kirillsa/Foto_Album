using System.Collections.Generic;

namespace BLL.DTO
{
    public class FotoDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Link { get; set; }
        public int UserOwnerId { get; set; }
        public ICollection<UserDTO> UsersWithLike { get; set; }

        public FotoDTO()
        {
            UsersWithLike = new List<UserDTO>();
        }
    }
}
