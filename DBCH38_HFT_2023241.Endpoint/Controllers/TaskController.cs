using DBCH38_HFT_2023241.Endpoint.Services;
using DBCH38_HFT_2023241.Logic;
using DBCH38_HFT_2023241.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DBCH38_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class TaskController : ControllerBase
    {
        ITaskLogic logic;
        IHubContext<SignalRHub> hub;
        public TaskController(ITaskLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Models.Task> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Models.Task Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Models.Task task)
        {
            this.logic.Create(task);
            this.hub.Clients.All.SendAsync("TaskCreated", task);

        }

        [HttpPut]
        public void Put([FromBody] Models.Task task)
        {
            this.logic.Update(task);
            this.hub.Clients.All.SendAsync("TaskUpdated", task);

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var who = Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("TaskDeleted", who);

        }

        [HttpGet]
        [Route("gettaskwithmanyworkers")]
        public IEnumerable<Models.Task> GetTaskWithManyWorkers()
        {
            return logic.GetTaskWithManyWorkers();
        }

        [HttpGet]
        [Route("gettaskwithmanyworkersurgent")]
        public IEnumerable<Models.Task> GetTaskWithManyWorkersUrgent()
        {
            return logic.GetTaskWithManyWorkersUrgent();
        }

    }
}
