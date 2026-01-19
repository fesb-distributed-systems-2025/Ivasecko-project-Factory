using Application.DTOs;
using Application.Interfaces.Services;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        private readonly IWorkerService _workerService;

        public WorkerController(IWorkerService workerService)
        {
            _workerService = workerService;
        }

        // GET: api/Worker
        [HttpGet]
        public ActionResult<IEnumerable<Worker>> GetAllWorkers()
        {
            var workers = _workerService.GetAllWorkers();
            return Ok(workers);
        }

        // GET: api/Worker/5
        [HttpGet("{id}")]
        public ActionResult<Worker> GetWorkerById(int id)
        {
            var worker = _workerService.GetWorkerById(id);
            if (worker == null)
                return NotFound($"Worker with Id {id} not found.");

            return Ok(worker);
        }

        // POST: api/Worker
        [HttpPost]
         public async Task<IActionResult> PostWorker([FromBody] PostWorkerDTO worker)
        {
            var result = await _workerService.AddWorker(worker);
            return Ok(result);
        }

        // PUT: api/Worker/5
        [HttpPut("{id}")]
         public async Task<IActionResult> EditWorker([FromBody] PutWorkerDTO worker)
        {
            var result = await _workerService.UpdateWorker(worker);
            return Ok(result);
        }

        // DELETE: api/Worker/5
        [HttpDelete("{id}")]
         public async Task<IActionResult> DeleteWorker(int id)
        {
            var result = await _workerService.DeleteWorker(id);
            return Ok(result);
        }
    }
}
