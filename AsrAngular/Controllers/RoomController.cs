using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsrAngular.Data.DataManager;
using AsrAngular.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AsrAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private WebAPIManager _manager;

        public RoomController(WebAPIManager slotManager)
        {
            _manager = slotManager;
        }

        // GET: api/Room
        [HttpGet]
        [Route("Index")]
        public IEnumerable<Room> Get() => _manager.GetAllRooms();


        // GET: api/Room/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Room
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Room/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
