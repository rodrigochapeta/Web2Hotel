using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web2Hotel.Models;
using Web2Hotel.Dto;
using Microsoft.AspNetCore.Authorization;

namespace Web2Hotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles="admin,client")]
    public class ReservaController : ControllerBase
    {
        private readonly Web2HotelContext _context;

        public ReservaController(Web2HotelContext context)
        {
            _context = context;
        }

        // GET: api/Reserva
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reserva>>> GetReserva()
        {
            return await _context.Reserva.ToListAsync();
        }

        // PUT: api/Reserva/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReserva(int id, Reserva reserva)
        {
            if (id != reserva.Id)
            {
                return BadRequest();
            }

            _context.Entry(reserva).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservaExists(id))
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

        // POST: api/Reserva
        [HttpPost]
        public async Task<ActionResult<Reserva>> PostReserva(ReservaDto reserva)
        {
            var userId = User.Identity.Name;
            
            if(reserva.FechaFin < reserva.FechaInicio){
                return BadRequest("Fecha de Fin de reserva pasada a la de Inicio");
            }
            if(reserva.FechaInicio < DateTime.Now){
                return BadRequest("No hacemos reservas en el pasado");
            }
            if(reserva.FechaInicio.AddDays(1).Date > reserva.FechaFin.Date){
                return BadRequest("La reserva debe durar al menos un dia");
            }
            if(reserva.FechaFin > DateTime.Now.AddYears(1)){
                return BadRequest("No hacemos reservas en un año");
            }
            foreach(int id in reserva.Habitaciones)
            {
                try{
                    var f = new Reserva();
                    f.FechaInicio = reserva.FechaInicio;
                    f.FechaFin = reserva.FechaFin;
                    f.Estado = "Activa";
                    f.CreationDate = DateTime.Now;
                    f.UsuarioId = reserva.UsusarioId;
                    f.HabitacionId = id;
                    try{
                        f.CreationId = int.Parse(userId); 
                    }catch(Exception e){
                        f.CreationId = 0; 
                    }
                    _context.Reserva.Add(f);
                }catch(Exception e){
                    return BadRequest(e);
                }
                
            }

            await _context.SaveChangesAsync();
            return Ok();
        }

        // DELETE: api/Reserva/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Reserva>> DeleteReserva(int id)
        {
            var reserva = await _context.Reserva.FindAsync(id);
            if (reserva == null)
            {
                return NotFound();
            }

            _context.Reserva.Remove(reserva);
            await _context.SaveChangesAsync();

            return reserva;
        }

        private bool ReservaExists(int id)
        {
            return _context.Reserva.Any(e => e.Id == id);
        }
    }
}


/*

Reserva Dto
duration
habitationId 

 */