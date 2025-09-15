using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml;
using api.Config;
using api.DTOs;
using api.Mappers;
using api.Models;
using api.Utils;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography;
using System.Text;

namespace api.Controllers
{
    [ApiController]
    [Route("api/usuario")]
    public class UsuarioController : ControllerBase
    {
        private readonly AppDBContext _context;
        private Classes.Usuario? usuario { get; set; }
        public UsuarioController(AppDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var usuarios = _context.Usuarios.ToList()
                    .Select(UsuarioMapper.UsuarioToClasses);

                return Ok(usuarios);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById([FromRoute] int id)
        {
            try
            {
                var usuario = _context.Usuarios.Find(id);
                
                if(usuario == null) {
                    return NotFound();
                }

                return Ok(usuario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        

        public class PasswordHasher
        {
            private const int SaltSize = 16; 
            private const int KeySize = 32; 
            private const int Iterations = 10000; 

            public static string HashPassword(string password)
            {
                using (var algorithm = new Rfc2898DeriveBytes(password, SaltSize, Iterations, HashAlgorithmName.SHA256))
                {
                    var salt = algorithm.Salt; 
                    var key = algorithm.GetBytes(KeySize); 

                    var hash = new byte[SaltSize + KeySize];
                    Array.Copy(salt, 0, hash, 0, SaltSize);
                    Array.Copy(key, 0, hash, SaltSize, KeySize);

                    return Convert.ToBase64String(hash); 
                }
            }

            public static bool VerifyPassword(string password, string hashedPassword)
            {
                var hashBytes = Convert.FromBase64String(hashedPassword);

                var salt = new byte[SaltSize];
                Array.Copy(hashBytes, 0, salt, 0, SaltSize);

                using (var algorithm = new Rfc2898DeriveBytes(password, salt, Iterations, HashAlgorithmName.SHA256))
                {
                    var key = algorithm.GetBytes(KeySize);
                    for (int i = 0; i < KeySize; i++)
                    {
                        if (hashBytes[SaltSize + i] != key[i])
                            return false; // A senha não corresponde
                    }
                }

                return true; // A senha corresponde
            }
        }
        [HttpGet("{email}/{password}")]
        public IActionResult GetByEmail([FromRoute] string email, [FromRoute] string password)
        {
            try
            {
                var usuario = _context.Usuarios.FirstOrDefault(u => u.email == email);

                if (usuario == null)
                {
                    return Ok(new { retorno = "Email inválido" } );
                }

                var senhaValida = PasswordHasher.VerifyPassword(password, usuario.senha);

                if (!senhaValida)
                {
                    return Ok(new { retorno = "Senha inválido" });
                }

                return Ok(usuario);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

		[HttpPost]
        public IActionResult Create([FromBody] Usuario usuario)
        {
            try
            {
                if(!UsuarioUtil.EmailValido(usuario.email)) {
                    return BadRequest("Email inválido");
                }

                var usuarioExistente = _context.Usuarios.FirstOrDefault(u => u.email == usuario.email);

                if(usuarioExistente != null) {
                    return BadRequest(new { retorno = "Usuario já existente" });
                }

                if(!UsuarioUtil.SenhaValida(usuario.senha)) {
                    return BadRequest(new { retorno = "Senha Inválida" });
                }

                usuario.senha = PasswordHasher.HashPassword(usuario.senha);


                _context.Usuarios.Add(usuario);
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception e)
            {   
                return BadRequest(e.Message);
            }
        }

        [HttpPost("editar/{id}")]
        public IActionResult Edit([FromRoute] int id, [FromBody] UsuarioEdit usuarioEdit)
        {
            try
            {
                var usuario = _context.Usuarios.Find(id);

                if (usuario == null)
                {
                    return NotFound();
                }

                this.usuario = UsuarioMapper.UsuarioToClasses(usuario);

                this.usuario.EditarCadastro(usuarioEdit);

                _context.Usuarios.Update(this.usuario.usuario);

                _context.SaveChanges();

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}