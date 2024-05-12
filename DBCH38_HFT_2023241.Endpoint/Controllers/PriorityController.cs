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
    public class PriorityController : ControllerBase
    {
        IPriorityLogic logic;
        IHubContext<SignalRHub> hub;
        public PriorityController(IPriorityLogic logic, IHubContext<SignalRHub> hub)
        {
            this.logic = logic;
            this.hub = hub;
        }

        [HttpGet]
        public IEnumerable<Priority> ReadAll()
        {
            return this.logic.ReadAll();
        }

        [HttpGet("{id}")]
        public Priority Read(int id)
        {
            return this.logic.Read(id);
        }

        [HttpPost]
        public void Create([FromBody] Priority priority)
        {
            this.logic.Create(priority);
            this.hub.Clients.All.SendAsync("PriorityCreated",priority);
        }

        [HttpPut]
        public void Put([FromBody] Priority priority)
        {
            this.logic.Update(priority);
            this.hub.Clients.All.SendAsync("PriorityUpdated", priority);

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var who = Read(id);
            this.logic.Delete(id);
            this.hub.Clients.All.SendAsync("PriorityDeleted", who);

        }

        [HttpGet]
        [Route("getprioritywithmosttasks")]
        public IEnumerable<Priority> GetPriorityWithMostTasks()
        {
            return logic.GetPriorityWithMostTasks();
        }
    }
}
