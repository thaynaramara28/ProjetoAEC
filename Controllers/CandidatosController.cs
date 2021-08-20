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
    public class CandidatosController : Controller
    {
        private readonly DbContexto _context;

        public CandidatosController(DbContexto context)
        {
            _context = context;
        }

        // GET: Candidatos
        [HttpGet]
        [Route("/candidatos")]
        public async Task<IActionResult> Index()
        {
            var DbContexto = _context.Candidatos;
            return StatusCode(200, await DbContexto.ToListAsync());
        }


        [HttpPost]
        [Route("/candidatos")]
        public async Task<IActionResult> Create([Bind("Id_Candidato,Nome,Nascimento,Cep,Logradouro,Numero,Bairro,Cidade,UF,Telefone,Email")] Candidato candidato)
        {
        
                _context.Add(candidato);
                await _context.SaveChangesAsync();
                return StatusCode(201, candidato);
                
        }

        [HttpPut]
        [Route("/candidatos/{id}")]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Candidato,Nome,Nascimento,Cep,Logradouro,Numero,Bairro,Cidade,UF,Telefone,Email")] Candidato candidato)
        {
            if (id != candidato.Id_Candidato)
            {
                return NotFound();
            }

            {
                try
                {
                    _context.Update(candidato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidatoExists(candidato.Id_Candidato))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return StatusCode(200, candidato);
            }
        }

     

        [HttpGet]
        [Route("/candidatos/{id}")]
        public async Task<Candidato> Get(int id)
        {
            return await _context.Candidatos.FindAsync(id);       
        }

        [HttpDelete,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        
        [Route("/candidatos/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var candidato = await _context.Candidatos.FindAsync(id);
            _context.Candidatos.Remove(candidato);
            await _context.SaveChangesAsync();
            return StatusCode(204);
        }

        private bool CandidatoExists(int id)
        {
            return _context.Candidatos.Any(e => e.Id_Candidato == id);
        }
    }
}
