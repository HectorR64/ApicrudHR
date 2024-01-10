using ApicrudHR.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace ApicrudHR.Controllers
{
    public class UserController : ApiController
    {
        private static List<Usuarios> usuarios = new List<Usuarios>
        {
            new Usuarios { Id = 1, Name = "Usuario1", Email = "email1@example.com", Password = "pass1" },
            new Usuarios { Id = 2, Name = "Usuario2", Email = "email2@example.com", Password = "pass2" }
        };
        // GET: api/User
        public IEnumerable<Usuarios> Get()
        {
            return usuarios;
        }

        public Usuarios Get(int id)
        {
            return usuarios.FirstOrDefault(u => u.Id == id);
        }

        // POST: api/User
        public IHttpActionResult Post([FromBody] Usuarios usuario)
        {
            usuarios.Add(usuario);
            return CreatedAtRoute("DefaultApi", new { id = usuario.Id }, usuario);
        }
        // PUT: api/User/5
        public IHttpActionResult Put(int id, [FromBody] Usuarios usuario)
        {
            if (usuario == null || usuario.Id != id)
            {
                return BadRequest();
            }

            var usuarioExistente = usuarios.FirstOrDefault(u => u.Id == id);
            if (usuarioExistente == null)
            {
                return NotFound();
            }

            usuarioExistente.Name = usuario.Name;
            usuarioExistente.Email = usuario.Email;
            usuarioExistente.Password = usuario.Password;


            return Ok(usuarioExistente);
        }

        // DELETE: api/User/5
        public IHttpActionResult Delete(int id)
        {
            var usuario = usuarios.FirstOrDefault(u => u.Id == id);
            if (usuario == null)
            {
                return NotFound();
            }

            usuarios.Remove(usuario);

            return Ok("usuario: "+usuario.Id+" eliminado correcctamente");
        }


    }
}
