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
    public class IntegrantesEquipesController : ControllerBase
    {
        private readonly AgenciaCronosAPIContext _context;

        public IntegrantesEquipesController(AgenciaCronosAPIContext context)
        {
            _context = context;
        }

        // GET: api/IntegrantesEquipes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<IntegrantesEquipeDTO>>> GetIntegrantesEquipe()
        {
            List<IntegrantesEquipeDTO> equipeDTO = new List<IntegrantesEquipeDTO>();

            var listaEquipes = await _context.IntegrantesEquipe
                .Join(
                    _context.Servicos,
                    p => p.ServicosId,
                    u => u.Id,
                    (p, u) => new
                    {
                        Id = p.Id,
                        TituloEquipe = p.TituloEquipe,
                        Servico = new
                        {
                            Id = u.Id,
                            TituloServico = u.TituloServico,
                            Descricao = u.Descricao,
                            DataInicioServico = u.DataInicioServico,
                            DataFimServico = u.DataInicioServico
                        },
                    }
                ).ToListAsync();

            foreach (var eq in listaEquipes)
            {
                IntegrantesEquipeDTO integrantesEquipeDTO = new IntegrantesEquipeDTO();

                integrantesEquipeDTO.Id = eq.Id;
                integrantesEquipeDTO.TituloEquipe = eq.TituloEquipe;

                if (eq.Servico != null)
                {
                    Servicos servico = new Servicos();

                    servico.Id = eq.Servico.Id;
                    servico.TituloServico = eq.Servico.TituloServico;
                    servico.Descricao = eq.Servico.Descricao;
                    servico.DataInicioServico = eq.Servico.DataInicioServico;
                    servico.DataFimServico = eq.Servico.DataInicioServico;

                    integrantesEquipeDTO.Servicos = servico;
                }
                integrantesEquipeDTO.MembroEquipe = await _context.Usuario.Where(a => a.EquipeId == eq.Id).ToListAsync();

                equipeDTO.Add(integrantesEquipeDTO);
            }

            return equipeDTO;
        }

        // GET: api/IntegrantesEquipes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IntegrantesEquipeDTO>> GetIntegrantesEquipe(int id)
        {
            var integrantesEquipe = await _context.IntegrantesEquipe.FindAsync(id);

            IntegrantesEquipeDTO equipeDTO = new IntegrantesEquipeDTO();

            var listaEquipes = await _context.IntegrantesEquipe
                .Join(
                    _context.Servicos,
                    p => p.ServicosId,
                    u => u.Id,
                    (p, u) => new
                    {
                        Id = p.Id,
                        TituloEquipe = p.TituloEquipe,
                        Servico = new
                        {
                            Id = u.Id,
                            TituloServico = u.TituloServico,
                            Descricao = u.Descricao,
                            DataInicioServico = u.DataInicioServico,
                            DataFimServico = u.DataInicioServico
                        },
                    }
                ).FirstOrDefaultAsync(m => m.Id == id);

            if (listaEquipes != null)
            {

                equipeDTO.Id = listaEquipes.Id;
                equipeDTO.TituloEquipe = listaEquipes.TituloEquipe;

                if (listaEquipes.Servico != null) {
                Servicos servico = new Servicos();

                servico.Id = listaEquipes.Servico.Id;
                servico.TituloServico = listaEquipes.Servico.TituloServico;
                servico.Descricao = listaEquipes.Servico.Descricao;
                servico.DataInicioServico = listaEquipes.Servico.DataInicioServico;
                servico.DataFimServico = listaEquipes.Servico.DataInicioServico;

                equipeDTO.Servicos = servico;
                }

                equipeDTO.MembroEquipe = await _context.Usuario.Where(a => a.EquipeId == listaEquipes.Id).ToListAsync();

            }

            if (integrantesEquipe == null)
            {
                return NotFound();
            }

            return equipeDTO;
        }

        // PUT: api/IntegrantesEquipes/5

        [HttpPut("{id}")]
        public async Task<IActionResult> PutIntegrantesEquipe(int id, IntegrantesEquipe integrantesEquipe)
        {
            if (id != integrantesEquipe.Id)
            {
                return BadRequest();
            }

            _context.Entry(integrantesEquipe).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IntegrantesEquipeExists(id))
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

        // POST: api/IntegrantesEquipes
        [HttpPost]
        public async Task<ActionResult<IntegrantesEquipe>> PostIntegrantesEquipe(IntegrantesEquipe integrantesEquipe)
        {
            _context.IntegrantesEquipe.Add(integrantesEquipe);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIntegrantesEquipe", new { id = integrantesEquipe.Id }, integrantesEquipe);
        }

        // DELETE: api/IntegrantesEquipes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIntegrantesEquipe(int id)
        {
            var integrantesEquipe = await _context.IntegrantesEquipe.FindAsync(id);
            if (integrantesEquipe == null)
            {
                return NotFound();
            }

            _context.IntegrantesEquipe.Remove(integrantesEquipe);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IntegrantesEquipeExists(int id)
        {
            return _context.IntegrantesEquipe.Any(e => e.Id == id);
        }
    }
}
