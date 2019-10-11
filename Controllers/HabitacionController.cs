using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Web2Hotel.Models;
using Microsoft.AspNetCore.Authorization;

namespace Web2Hotel.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles="admin,client")]
    public class HabitacionController : ControllerBase
    {
        private readonly Web2HotelContext _context;

        public HabitacionController(Web2HotelContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Se manda un Datetime de fecha de inicio de reserva y int de Cantidad de dias de la reserva
        /// Vuelve lista de habitaciones libres en esas fechas.
        /// </summary>
        /// <param name="fechaInicio"></param>
        /// <param name="duracion"></param>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Habitacion>>> GetHabitacionesLibres(DateTime fechaInicio,DateTime fechaFin)
        {
             /// <summary>
            /// Condicion de una habitacion libre: Nhibernate
            ///     No tiene reservas entre fecha inicio y fecha fin
            /// </summary>
            var habitacionesLibres = 
            _context.Habitacion
                .Where(x=> x.Reserva.All(y => y.FechaInicio > fechaFin || y.FechaFin < fechaInicio))
                .ToList();
            return habitacionesLibres;
        }

        // GET: api/Habitacion
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Habitacion>>> GetHabitacion()
        {
            return await _context.Habitacion.ToListAsync();
        }

        // PUT: api/Habitacion/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHabitacion(int id, Habitacion habitacion)
        {
            if (id != habitacion.Id)
            {
                return BadRequest();
            }

            _context.Entry(habitacion).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HabitacionExists(id))
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

        // POST: api/Habitacion
        [HttpPost]
        public async Task<ActionResult<Habitacion>> PostHabitacion(Habitacion habitacion)
        {
            _context.Habitacion.Add(habitacion);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetHabitacion", new { id = habitacion.Id }, habitacion);
        }

        // DELETE: api/Habitacion/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Habitacion>> DeleteHabitacion(int id)
        {
            var habitacion = await _context.Habitacion.FindAsync(id);
            if (habitacion == null)
            {
                return NotFound();
            }

            _context.Habitacion.Remove(habitacion);
            await _context.SaveChangesAsync();

            return habitacion;
        }

        private bool HabitacionExists(int id)
        {
            return _context.Habitacion.Any(e => e.Id == id);
        }
    }
}
