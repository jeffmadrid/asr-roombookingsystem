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

        [HttpGet]
        [Route("Index")]
        public IEnumerable<Room> Get() => _manager.GetAllRooms();


        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        [HttpPost]
        [Route("CreateRoom")]
        public int Post([FromBody] Room room)
        {
           return _manager.AddRoom(room);
        }

        [HttpDelete]
        [Route("DeleteRoom/{roomId}")]
        public void Delete(string roomId) =>
            _manager.DeleteRoom(roomId);
       
    }
}
