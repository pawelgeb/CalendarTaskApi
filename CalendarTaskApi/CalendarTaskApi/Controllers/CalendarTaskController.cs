using CalendarTaskApi.Data;
using CalendarTaskApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CalendarTaskApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalendarTaskController : ControllerBase
    {
        private readonly CalendarTaskContext _context;

        public CalendarTaskController(CalendarTaskContext context)
        {
            _context = context;
        }

        // GET: api/CalendarTasks
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CalendarTask>>> GetTasks()
        {
            return await _context.Tasks.ToListAsync();
        }

        // GET: api/CalendarTasks/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CalendarTask>> GetCalendarTask(int id)
        {
            var calendarTask = await _context.Tasks.FindAsync(id);

            if (calendarTask == null)
            {
                return NotFound();
            }

            return calendarTask;
        }

        // PUT: api/CalendarTasks/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCalendarTask(int id, CalendarTask calendarTask)
        {
            if (id != calendarTask.Id)
            {
                return BadRequest();
            }

            _context.Entry(calendarTask).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CalendarTaskExists(id))
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
        // POST: api/CalendarTasks
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CalendarTask>> PostCalendarTask(CalendarTask calendarTask)
        {
            //if (calendarTask.Priority)
            _context.Tasks.Add(calendarTask);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCalendarTask", new { id = calendarTask.Id }, calendarTask);
        }
        // DELETE: api/CalendarTasks/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCalendarTask(int id)
        {
            var calendarTask = await _context.Tasks.FindAsync(id);
            if (calendarTask == null)
            {
                return NotFound();
            }
            _context.Tasks.Remove(calendarTask);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        private bool CalendarTaskExists(int id)
        {
            return _context.Tasks.Any(e => e.Id == id);
        }
    }
}
