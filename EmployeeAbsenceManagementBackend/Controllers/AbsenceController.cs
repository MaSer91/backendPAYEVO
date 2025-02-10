using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAbsenceManagementBackend.Controllers
{
    // Absence Controller
    [ApiController]
    [Route("api/[controller]")]
    public class AbsenceController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IHubContext<AbsenceHub> _hubContext;

        public AbsenceController(AppDbContext context, IHubContext<AbsenceHub> hubContext)
        {
            _context = context;
            _hubContext = hubContext;
        }

        [HttpPost]
        public async Task<IActionResult> AddAbsence([FromBody] Absence absence)
        {
            _context.Absences.Add(absence);
            await _context.SaveChangesAsync();
            await _hubContext.Clients.All.SendAsync("UpdateAbsence", absence);
            return CreatedAtAction(nameof(GetAbsences), new { id = absence.AbsenceID }, absence);
        }

        [HttpGet]
        public async Task<IActionResult> GetAbsences()
        {
            //var absences = await _context.Absences.Include(a => a.Employee).ToListAsync();
            var absences = await _context.Set<Absence>().Include(a => a.Employee).ToListAsync();

            return Ok(absences);
        }

        [HttpGet("byEmployee/{employeeId}")]
        public async Task<IActionResult> GetAbsencesByEmployee(int employeeId)
        {
            var absences = await _context.Absences.Where(a => a.EmployeeId == employeeId).ToListAsync();
            return Ok(absences);
        }
    }
}
