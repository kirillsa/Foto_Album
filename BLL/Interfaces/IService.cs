using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;

namespace BLL.Interfaces
{
    public interface IService : IDisposable
    {
        IEnumerable<FotoDTO> GetAllFotos();
        FotoDTO GetFoto(int? id);
        void DeleteFoto(int? id);
        void ChangeFoto(FotoDTO foto);
        void UploadFoto(FotoDTO foto);
        void ThumbsUp(int fotoId, int userId);
        void CreateUser(UserDTO userDto);
        void Dispose();
    }
}
