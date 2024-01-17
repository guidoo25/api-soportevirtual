using api_soportevirtual.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using System.Security.Cryptography;
using System.Text;

namespace Api_Soportecnico.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly Test1Context _context;
        public LoginController(Test1Context context)
        {
            _context = context;
        }
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] Usuario user)
        {
            var userdb = await _context.Usuarios.SingleOrDefaultAsync(x => x.NombreUsuario == user.NombreUsuario);
            if (userdb == null)
            {
                return Unauthorized("username invalido");
            }
            var hashedPassword = GeneratePasswordHash(user.Passwordhash, Convert.FromBase64String(userdb.PasswordSalt!));
            if (userdb.Passwordhash != hashedPassword)
            {
                return Unauthorized("Invalid password");
            }

            return Ok(userdb);


        }

        private String GeneratePasswordHash(string password, byte[] key = null)


        {
            using var hmac = new HMACSHA512(key);
            return Convert.ToBase64String(hmac.ComputeHash(Encoding.UTF8.GetBytes(password)));
        }

        [HttpPost("registro")]
        public async Task<IActionResult> Registro([FromBody] RegistroModel registroModel)
        {
            var user = registroModel.Usuario;
            var empleado = registroModel.Empleado;

          
            var userdb = await _context.Usuarios.SingleOrDefaultAsync(x => x.NombreUsuario == user.NombreUsuario);
            if (userdb != null)
            {
                return BadRequest("El usuario ya existe");
            }

           
            using var hmac = new HMACSHA512();
            user.Passwordhash = GeneratePasswordHash(user.Passwordhash, hmac.Key);
            user.PasswordSalt = Convert.ToBase64String(hmac.Key);

           
            await _context.Empleados.AddAsync(empleado);
            await _context.SaveChangesAsync();

            user.EmpleadoId = empleado.EmpleadoId;

            await _context.Usuarios.AddAsync(user);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}