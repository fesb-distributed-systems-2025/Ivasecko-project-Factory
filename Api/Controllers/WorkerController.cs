using Application.DTOs;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        //private EmailRespository _emailRespository;
        public WorkerController(WorkerController emailRespository)
        {
            //_emailRespository = emailRespository;
        }

        [HttpGet("Workers")]
        public IEnumerable<Worker> GetAllWorkers()
        {
            //return _emailRespository.Emails;

            return Enumerable.Empty<Worker>();
        }

        [HttpGet("Workers/{id}")]
        public Worker GetWorkerById()
        {
            //return _emailRespository.Emails;

            return new Worker();
        }

        [HttpPost("new")]
        public int AddWorker([FromBody] PostWorkerDTO newWorker)
        {
            //_emailRespository.Emails.Add(email);
            //return _emailRespository.Emails;

            return 0;
        }

        [HttpPut("edit")]
        public int EditWorker([FromBody] Worker Worker)
        {
            //var oldEmail = _emailRespository.Emails.FirstOrDefault(x => x.Id == id);

            //if (oldEmail == null)
            //{
            //    return _emailRespository.Emails;
            //}

            //oldEmail.Sender = newEmail.Sender;
            //oldEmail.Recepient = newEmail.Recepient;
            //oldEmail.Subject = newEmail.Subject;
            //oldEmail.Message = newEmail.Message;

            //return _emailRespository.Emails;

            return 0;
        }

        [HttpDelete("delete/{id}")]
        public int DeleteEmail([FromRoute] int id)
        {
            //_emailRespository.Emails = _emailRespository.Emails.Where(x => x.Id != id).ToList();
            //return _emailRespository.Emails;

            return 0;
        }
    }
}