using BLL.DTO;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BLL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace PresentationLayer.Controllers
{
    [Authorize]
    public class ValuesController : ApiController
    {
        private IService _service;

        /*public ValuesController()
        {
            _service = new Services();
        }*/

        public ValuesController(IService serv)
        {
            _service = serv;
        }

        // GET api/values
        [AllowAnonymous]
        public IEnumerable<FotoDTO> Get()
        {
            return _service.GetAllFotos();
        }

        // GET api/values/5
        public FotoDTO Get(int id)
        {
            return _service.GetFoto(id);
        }

        // POST api/values
        public IHttpActionResult Post([FromBody]FotoDTO data)
        {
            _service.UploadFoto(data);
            return Ok();
        }

        // POST api/values
        [Route("api/values/{id}/thumbs")]
        public IHttpActionResult PostThumbsUp(int id, [FromBody]UserDTO user)
        {
            if (user != null && user.Id != 0)
            { 
                _service.ThumbsUp(id, user.Id);
                return Ok();
            }

            return BadRequest("null inputed");
        }

        // PUT api/values/5
        public IHttpActionResult Put(int id, [FromBody]FotoDTO data)
        {
            _service.ChangeFoto(data);
            return Ok();
        }

        // DELETE api/values/5
        public IHttpActionResult Delete(int id)
        {
            _service.DeleteFoto(id);
            return Ok();
        }
    }
}
