using DBCH38_HFT_2023241.Logic;
using DBCH38_HFT_2023241.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DBCH38_HFT_2023241.Endpoint.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PriorityController : ControllerBase
    {
        IPriorityLogic logic;
        public PriorityController(IPriorityLogic logic)
        {
            this.logic = logic;
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
        }

        [HttpPut]
        public void Put([FromBody] Priority priority)
        {
            this.logic.Update(priority);
        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            this.logic.Delete(id);
        }
    }
}
