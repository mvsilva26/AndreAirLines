﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using AndreAPI.Data;
using AndreAPI.Model;
using AndreAPI.Service;

namespace AndreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VoosController : ControllerBase
    {
        private readonly AndreAPIContext _context;

        public VoosController(AndreAPIContext context)
        {
            _context = context;
        }

        // GET: api/Voos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Voo>>> GetVoo()
        {
            return await _context.Voo.Include(a => a.Aeronave)
                                     .Include(Origem => Origem.Origem.Endereco)
                                     .Include(Dest => Dest.Destino.Endereco)
                                     .Include(Pass => Pass.Passageiro.Endereco)
                                     .ToListAsync();                                   
        }

        // GET: api/Voos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Voo>> GetVoo(int id)
        {



            var voo = await _context.Voo.Include(a => a.Aeronave)
                                        .Include(Origem => Origem.Origem.Endereco)
                                        .Include(Dest => Dest.Destino.Endereco)
                                        .Include(Pass => Pass.Passageiro.Endereco)
                                        .Where(v => v.Id == id) 
                                        .FirstOrDefaultAsync();



            if (voo == null)
            {
                return NotFound();
            }

            return voo;
        }

        // PUT: api/Voos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVoo(int id, Voo voo)
        {
            if (id != voo.Id)
            {
                return BadRequest();
            }

            _context.Entry(voo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VooExists(id))
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

        // POST: api/Voos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Voo>> PostVoo(Voo voo)
        {


            var aeronave = await _context.Aeronave.Where(a => a.Id == voo.Aeronave.Id)
                                                  .FirstOrDefaultAsync();
            if (aeronave != null)
                voo.Aeronave = aeronave;

            var aeroportoOrigem = await _context.Aeroporto.Where(ao => ao.Sigla == voo.Origem.Sigla)
                                                          .FirstOrDefaultAsync();
            Endereco endereco;

            if (aeroportoOrigem != null)
                voo.Origem = aeroportoOrigem;
            
            else if ((endereco = await ViaCep.ConsultarCep(voo.Origem.Endereco.Cep)) != null)
            {
                endereco.Numero = voo.Origem.Endereco.Numero;
                voo.Origem.Endereco = endereco;
            }
            
            var aeroportoDestino = await _context.Aeroporto.Where(ad => ad.Sigla == voo.Destino.Sigla)
                                                           .FirstOrDefaultAsync();

            if (aeroportoDestino != null)
                voo.Destino = aeroportoDestino;
            
            else if ((endereco = await ViaCep.ConsultarCep(voo.Destino.Endereco.Cep)) != null)
            {
                endereco.Numero = voo.Destino.Endereco.Numero;
                voo.Destino.Endereco = endereco;
            }
            
            var passageiro = await _context.Passageiro.Where(p => p.Cpf == voo.Passageiro.Cpf)
                                                      .FirstOrDefaultAsync();

            if (passageiro != null)
                voo.Passageiro = passageiro;
            
            else if ((endereco = await ViaCep.ConsultarCep(voo.Passageiro.Endereco.Cep)) != null)
            {
                endereco.Numero = voo.Passageiro.Endereco.Numero;
                voo.Passageiro.Endereco = endereco;
            }
            

            _context.Voo.Add(voo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVoo", new { id = voo.Id }, voo);
        }

        // DELETE: api/Voos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVoo(int id)
        {
            var voo = await _context.Voo.FindAsync(id);
            if (voo == null)
            {
                return NotFound();
            }

            _context.Voo.Remove(voo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VooExists(int id)
        {
            return _context.Voo.Any(e => e.Id == id);
        }
    }
}
