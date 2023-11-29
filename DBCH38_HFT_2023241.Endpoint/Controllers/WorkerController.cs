using DBCH38_HFT_2023241.Logic;
using DBCH38_HFT_2023241.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DBCH38_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        IWorkerLogic logic;
        public WorkerController(IWorkerLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Worker> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Worker Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Worker worker)
        {
            this.logic.Create(worker);
        }

        [HttpPut]
        public void Put([FromBody] Worker worker)
        {
            this.logic.Update(worker);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
