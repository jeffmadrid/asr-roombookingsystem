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
        //get room by id
        [HttpGet("{id}", Name = "Get")]
        [Route("Details")]
        public Room Get(string id)
        {
            return _manager.GetRoomData(id);
        }

        // POST: api/Room
        [HttpPost]
        [Route("Create")]
        public int Post([FromBody] Room room)
        {
           return _manager.AddRoom(room);
        }

        // PUT: api/Room/5
        [HttpPut/*("{id}")*/]
        [Route("Edit")]
        public int Put(/*string id,*/ [FromBody] Room room)
        {
            return _manager.UpdateRoom(room);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
