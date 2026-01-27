using Application.DTOs;
using Api.Common;
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
        [HttpGet("all")]
        public async Task<IActionResult> GetAllWorkers()
        {
            var result = await _workerService.GetAllWorkers();
            return this.HandleResult(result);
        }

        // GET: api/Worker/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetWorkerById(int id)
        {
            var result = await _workerService.GetWorkerById(id);
            if (result == null)
                return NotFound($"Worker with Id {id} not found.");

            return this.HandleResult(result);
        }

        // POST: api/Worker
        [HttpPost]
         public async Task<IActionResult> PostWorker([FromBody] PostWorkerDTO worker)
        {
            var result = await _workerService.AddWorker(worker);
            return this.HandleResult(result);
        }

        // PUT: api/Worker/5
        [HttpPut("{id}")]
         public async Task<IActionResult> EditWorker([FromBody] PutWorkerDTO worker)
        {
            var result = await _workerService.UpdateWorker(worker);
            return this.HandleResult(result);
        }

        // DELETE: api/Worker/5
        [HttpDelete("{id}")]
         public async Task<IActionResult> DeleteWorker(int id)
        {
            var result = await _workerService.DeleteWorker(id);
            return this.HandleResult(result);
        }
    }
}
