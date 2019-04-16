using BLL.DTO;
using System.Collections.Generic;

namespace BLL.Interfaces
{
    public interface IAdminServices
    {
        IEnumerable<UserDTO> GetAllUsers();
        UserDTO GetUser(int? id);
        void DeleteUser(int? id);
        void ChangeUser(UserDTO foto);
        void UpdateUser(UserDTO foto);
        void Dispose();
    }
}
