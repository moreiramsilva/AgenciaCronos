#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AgenciaCronosAPI.Data;
using AgenciaCronosAPI.Models;
using AgenciaCronosAPI.DTO;

namespace AgenciaCronosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private readonly AgenciaCronosAPIContext _context;

        public UsuariosController(AgenciaCronosAPIContext context)
        {
            _context = context;
        }

        // GET: api/Usuarios
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UsuarioDTO>>> GetUsuario()
        {
            List<UsuarioDTO> listaUsuarioDTO = new List<UsuarioDTO>();

            var listaUsuario = await _context.Usuario
                .Join(
                    _context.IntegrantesEquipe,
                    p => p.EquipeId,
                    u => u.Id,
                    (p, u) => new
                    {
                        Id = p.Id,
                        Nome = p.Nome,
                        Papel = p.Papel,
                        Contato = p.Contato,
                        Equipe = new
                        {
                            Id = u.Id,
                            TituloEquipe = u.TituloEquipe
                        },
                    }
                ).ToListAsync();

            foreach (var usuario in listaUsuario)
            {
                UsuarioDTO usuarioDTO = new UsuarioDTO();

                usuarioDTO.Id = usuario.Id;
                usuarioDTO.Nome = usuario.Nome;
                usuarioDTO.Papel = usuario.Papel;
                usuarioDTO.Contato = usuario.Contato;

                if (usuario.Equipe != null)
                {
                    IntegrantesEquipe equipe = new IntegrantesEquipe();

                    equipe.Id = usuario.Equipe.Id;
                    equipe.TituloEquipe = usuario.Equipe.TituloEquipe;

                    usuarioDTO.Equipe = equipe;
                }
                listaUsuarioDTO.Add(usuarioDTO);
            }

            return listaUsuarioDTO;
        }

        // GET: api/Usuarios/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioDTO>> GetUsuario(int id)
        {
            UsuarioDTO usuarioDTO = new UsuarioDTO();

            var usuario = await _context.Usuario
                .Join(
                    _context.IntegrantesEquipe,
                    p => p.EquipeId,
                    u => u.Id,
                    (p, u) => new
                    {
                        Id = p.Id,
                        Nome = p.Nome,
                        Papel = p.Papel,
                        Contato = p.Contato,
                        Equipe = new
                        {
                            Id = u.Id,
                            TituloEquipe = u.TituloEquipe
                        },
                    }
                ).FirstOrDefaultAsync(m => m.Id == id);

            if(usuario != null)
            {

                usuarioDTO.Id = usuario.Id;
                usuarioDTO.Nome = usuario.Nome;
                usuarioDTO.Papel = usuario.Papel;
                usuarioDTO.Contato = usuario.Contato;

                IntegrantesEquipe equipe = new IntegrantesEquipe();

                equipe.Id = usuario.Equipe.Id;
                equipe.TituloEquipe = usuario.Equipe.TituloEquipe;

                usuarioDTO.Equipe = equipe;
            }

            if (usuarioDTO == null)
            {
                return NotFound();
            }

            return usuarioDTO;
        }

        // PUT: api/Usuarios/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutUsuario(int id, Usuario usuario)
        {
            if (id != usuario.Id)
            {
                return BadRequest();
            }

            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Usuarios

        [HttpPost]
        public async Task<ActionResult<Usuario>> PostUsuario(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.Id }, usuario);
        }

        // DELETE: api/Usuarios/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUsuario(int id)
        {
            var usuario = await _context.Usuario.FindAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }

            _context.Usuario.Remove(usuario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UsuarioExists(int id)
        {
            return _context.Usuario.Any(e => e.Id == id);
        }
    }
}
