using DBCH38_HFT_2023241.Endpoint.Services;
using DBCH38_HFT_2023241.Logic;
using DBCH38_HFT_2023241.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Collections.Generic;

namespace DBCH38_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class WorkerController : ControllerBase
    {
        IWorkerLogic logic;
        IHubContext<SignalRHub> hub;
        public WorkerController(IWorkerLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
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
            this.hub.Clients.All.SendAsync("WorkerCreated", worker);

        }

        [HttpPut]
        public void Put([FromBody] Worker worker)
        {
            this.logic.Update(worker);
            this.hub.Clients.All.SendAsync("WorkerUpdated", worker);

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var who = Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("WorkerDeleted", who);

        }

        [HttpGet]
        [Route("getworkerswithurgenttask")]
        public IEnumerable<string> GetWorkersWithUrgentTask()
        {
            return logic.GetWorkersWithUrgentTask();
        }

        [HttpGet]
        [Route("getworkerswithnotask")]
        public IEnumerable<string> GetWorkersWithNoTask()
        {
            return logic.GetWorkersWithNoTask();

        }
    }
}
