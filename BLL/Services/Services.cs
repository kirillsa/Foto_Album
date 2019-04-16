using BLL.DTO;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using DAL.Interfaces;
using AutoMapper;
using BLL.Infrastructure;
using DAL;
using DAL.DBContext.Models;

namespace BLL
{
    public class Services : IService
    {
        private IUnitOfWork _dataBase;

        /*public Services()
        {
            _dataBase = new EF_UnitOfWork();
        }*/

        public Services(IUnitOfWork uow)
        {
            _dataBase = uow;
        }

        public IEnumerable<FotoDTO> GetAllFotos()
        {
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Foto, FotoDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Foto>, List<FotoDTO>>(_dataBase.Fotos.GetAll());
        }

        public FotoDTO GetFoto(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("Null ID while getting foto","id = null");
            }
            else if (id.Value <= 0)
            {
                throw new ValidationException("Wrong ID while getting foto", $" id={id.Value}");
            }
            var foto = _dataBase.Fotos.Get(id.Value);
            if (foto == null)
            {
                throw new ValidationException("Foto is not found",$"id={id.Value}");
            }
            return new FotoDTO()
            {
                Id = foto.Id,
                Link = foto.Link,
                Name = foto.Name,
                UserOwnerId = foto.UserOwnerId
            };
        }

        public void DeleteFoto(int? id)
        {
            try
            {
                _dataBase.Fotos.Delete(id.Value);
                _dataBase.Save();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new ValidationException("Error while deleting foto with id=", $"{id.Value}");
            }
        }

        public void ChangeFoto(FotoDTO editedFoto)
        {
            if (editedFoto == null || editedFoto.Link == null)
            {
                throw new ValidationException("Null foto input", "null");
            }

            try
            {
                var fotoToEdit = GetFoto(editedFoto.Id);
                var newFoto = new Foto()
                {
                    Id = editedFoto.Id,
                    Link = editedFoto.Link,
                    Name = editedFoto.Name,
                    UserOwnerId = fotoToEdit.UserOwnerId
                };
                foreach (var userDTO in fotoToEdit.UsersWithLike)
                {
                    var user = _dataBase.Users.Get(userDTO.Id);
                    newFoto.UsersWithLike.Add(user);
                }
                _dataBase.Fotos.Update(newFoto);
                _dataBase.Save();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new ValidationException("Error while uploading foto", "");
            }
        }

        public void UploadFoto(FotoDTO foto)
        {
            if (foto == null || foto.Link == null)
            {
                throw new ValidationException("Null foto input", "null");
            }

            var user = _dataBase.Users.Get(foto.UserOwnerId);
            if (user == null)
            {
                throw new ValidationException("User not found", "null");
            }

            try
            {
                var newFoto = new Foto()
                {
                    Link = foto.Link,
                    Name = foto.Name,
                    UserOwnerId = foto.UserOwnerId
                };
                foreach (var userDTO in foto.UsersWithLike)
                {
                    var bufUser = _dataBase.Users.Get(userDTO.Id);
                    newFoto.UsersWithLike.Add(bufUser);
                }
                _dataBase.Fotos.Create(newFoto);
                user.Fotos.Add(newFoto);
                _dataBase.Save();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new ValidationException("Error while uploading foto", "");
            }
        }

        public void ThumbsUp(int fotoId, int userId)
        {
            var foto = _dataBase.Fotos.Get(fotoId);
            var user = _dataBase.Users.Get(userId);
            if (foto == null || user == null)
            {
                throw new ValidationException("Null input data while ThumbsUp", "null");
            }
            foto.UsersWithLike.Add(user);
            user.FavoriteFotos.Add(foto);
            _dataBase.Save();
        }
        
        public void CreateUser(UserDTO userDto)
        {
            if (userDto == null)
            {
                throw new ValidationException("Null user input while creating new user", "null");
            }
            var user = new User()
            {
                Login = userDto.Login
            };
            _dataBase.Users.Create(user);
            _dataBase.Save();
        }

        public void Dispose()
        {
            _dataBase.Dispose();
        }
    }
}
