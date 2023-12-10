using DBCH38_HFT_2023241.Logic;
using DBCH38_HFT_2023241.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Collections.Generic;

namespace DBCH38_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        ITaskLogic logic;
        public TaskController(ITaskLogic logic)
        {
            this.logic = logic;
        }

        [HttpGet]
        public IEnumerable<Task> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Task Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Task task)
        {
            this.logic.Create(task);
        }

        [HttpPut]
        public void Put([FromBody] Task task)
        {
            this.logic.Update(task);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }

        [HttpGet]
        [Route("gettaskwithmanyworkers")]
        public IEnumerable<Task> GetTaskWithManyWorkers()
        {
            return logic.GetTaskWithManyWorkers();
        }

        [HttpGet]
        [Route("gettaskwithmanyworkersurgent")]
        public IEnumerable<Task> GetTaskWithManyWorkersUrgent()
        {
            return logic.GetTaskWithManyWorkersUrgent();
        }

    }
}
