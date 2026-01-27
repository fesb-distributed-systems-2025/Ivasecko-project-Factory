// using Application.Interfaces.Services;
// using Domain.Models;
// using Microsoft.AspNetCore.Mvc;

// namespace Api.Controllers
// {
//     [ApiController]
//     [Route("api/[controller]")]
//     public class ShiftController : ControllerBase
//     {
//         private readonly IShiftService _shiftService;

//         public ShiftController(IShiftService shiftService)
//         {
//             _shiftService = shiftService;
//         }

//         [HttpGet]
//         public IActionResult GetAll()
//         {
//             return Ok(_shiftService.GetAll());
//         }

//         [HttpGet("{id}")]
//         public IActionResult GetById(int id)
//         {
//             return Ok(_shiftService.GetById(id));
//         }

//         [HttpPost]
//         public IActionResult Create([FromBody] Shift shift)
//         {
//             return Ok(_shiftService.Create(shift));
//         }

//         [HttpPut("{id}")]
//         public IActionResult Update(int id, [FromBody] Shift shift)
//         {
//             return Ok(_shiftService.Update(id, shift));
//         }

//         [HttpDelete("{id}")]
//         public IActionResult Delete(int id)
//         {
//             return Ok(_shiftService.Delete(id));
//         }
//     }
// }
