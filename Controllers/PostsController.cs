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
using System.Data.Entity.Core.Objects;
using AgenciaCronosAPI.DTO;

namespace AgenciaCronosAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly AgenciaCronosAPIContext _context;

        public PostsController(AgenciaCronosAPIContext context)
        {
            _context = context;
        }

        // GET: api/Posts
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PostDTO>>> GetPost()
        {
            List<PostDTO> listaPostDTO = new List<PostDTO>();

            var listaPost = await _context.Post
                .Join(
                    _context.Usuario,
                    p => p.CriadorId,
                    u => u.Id,
                    (p, u) => new
                    {
                        Id = p.Id,
                        TituloPost = p.TituloPost,
                        Publicacao = p.Publicacao,
                        DataPublicacao = p.DataPublicacao,
                        Criador = new
                        {
                            Id = u.Id,
                            Nome = u.Nome,
                            Papel = u.Papel,
                            Contato = u.Contato
                        },
                    }
                ).ToListAsync();

            foreach (var post in listaPost)
            {
                PostDTO postDTO = new PostDTO();

                postDTO.Id = post.Id;
                postDTO.Publicacao = post.Publicacao;
                postDTO.TituloPost = post.TituloPost;
                postDTO.DataPublicacao = post.DataPublicacao;

                if (post.Criador != null)
                {
                    Usuario Criador = new Usuario();

                    Criador.Id = post.Criador.Id;
                    Criador.Nome = post.Criador.Nome;
                    Criador.Papel = post.Criador.Papel;
                    Criador.Contato = post.Criador.Contato;

                    postDTO.Criador = Criador;
                }
                listaPostDTO.Add(postDTO);
            }

            return listaPostDTO;
        }

        // GET: api/Posts/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PostDTO>> GetPost(int id)
        {
            var postDTO = new PostDTO();
            var post = await _context.Post
                .Join(
                    _context.Usuario,
                    p => p.CriadorId,
                    u => u.Id,
                    (p, u) => new
                    {
                        Id = p.Id,
                        TituloPost = p.TituloPost,
                        Publicacao = p.Publicacao,
                        DataPublicacao = p.DataPublicacao,
                        Criador = new
                        {
                            Id = u.Id,
                            Nome = u.Nome,
                            Papel = u.Papel,
                            Contato = u.Contato
                        },
                    }
                ).FirstOrDefaultAsync(m => m.Id == id);

            if (post != null)
            {
                postDTO.Id = post.Id;
                postDTO.Publicacao = post.Publicacao;
                postDTO.TituloPost = post.TituloPost;
                postDTO.DataPublicacao = post.DataPublicacao;

                if (post.Criador != null) {
                Usuario Criador = new Usuario();

                Criador.Id = post.Criador.Id;
                Criador.Nome = post.Criador.Nome;
                Criador.Papel = post.Criador.Papel;
                Criador.Contato = post.Criador.Contato;

                postDTO.Criador = Criador;
                }
            }

            if (post == null)
            {
                return NotFound();
            }

            return postDTO;
        }

        // PUT: api/Posts/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPost(int id, Post post)
        {
            if (id != post.Id)
            {
                return BadRequest();
            }

            _context.Entry(post).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PostExists(id))
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

        // POST: api/Posts
        [HttpPost]
        public async Task<ActionResult<Post>> PostPost(Post post)
        {
            _context.Post.Add(post);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPost", new { id = post.Id }, post);
        }

        // DELETE: api/Posts/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePost(int id)
        {
            var post = await _context.Post.FindAsync(id);
            if (post == null)
            {
                return NotFound();
            }

            _context.Post.Remove(post);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PostExists(int id)
        {
            return _context.Post.Any(e => e.Id == id);
        }
    }
}
