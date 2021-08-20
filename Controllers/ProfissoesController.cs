using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ProjetoAEC.Models;
using ProjetoAEC.Servcos;

namespace ProjetoAEC.Controllers
{
     [ApiController]
    public class ProfissoesController : ControllerBase
    {
        private readonly DbContexto _context;

        public ProfissoesController(DbContexto context)
        {
            _context = context;
        }

        // GET: Profissoes
        [HttpGet]
        [Route("/profissoes")]
        public async Task<IActionResult> Index()
        {
            var DbContexto = _context.Profissoes;
            return StatusCode(200, await DbContexto.ToListAsync());
        }


        [HttpPost]
        
        [Route("/profissoes")]
        public async Task<IActionResult> Create([Bind("Id,Descricao")] Profissao profissao)
        {

                if(_context.Profissoes.Where(p => p.Descricao == profissao.Descricao).Count()> 0)
                {
                    return StatusCode(400, new {
                        Mensagem = $"já existe uma profissão criada com o nome {profissao.Descricao}"
                    });
                }
        
                _context.Add(profissao);
                await _context.SaveChangesAsync();
                return StatusCode(201, profissao);
                
        }

        [HttpPut]
        
        [Route("/profissoes/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descricao")] Profissao profissao)
        {
            if (id != profissao.Id)
            {
                return NotFound();
            }

            {
                try
                {
                    _context.Update(profissao);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProfissaoExists(profissao.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return StatusCode(200, profissao);
            }
        }

     

        [HttpGet]
        [Route("/profissoes/{id}")]
        public async Task<Profissao> Get(int id)
        {
            return await _context.Profissoes.FindAsync(id);       
        }

        [HttpDelete]
        [Route("/profissoes/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var profissao = await _context.Profissoes.FindAsync(id);
            _context.Profissoes.Remove(profissao);
            await _context.SaveChangesAsync();
            return StatusCode(204);
        }

        private bool ProfissaoExists(int id)
        {
            return _context.Profissoes.Any(e => e.Id == id);
        }
    }
}
