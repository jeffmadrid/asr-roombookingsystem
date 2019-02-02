using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AsrAngular.Models;
using AsrAngular.Data.DataManager;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AsrAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlotController : Controller
    {
        private WebAPIManager _manager;

        public SlotController(WebAPIManager slotManager)
        {
            _manager = slotManager;
        }

        // GET: api/values
        [HttpGet]
        [Route("Index")]
        public IEnumerable<Slot> Get() => _manager.GetAllSlots();

        // GET api/values/5
        [HttpGet("{id}")]
        public IEnumerable<Slot> Get(string id) =>
            _manager.GetSlotsOf(id);

        //https://sookocheff.com/post/api/when-to-use-http-put-and-http-post/
        // so i guess create == Post; edit == Put

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut()]
        [Route("UpdateBookedStudent/{roomId}/{startTime}/{studentId}")]
        public void UpdateBookedStudent(string roomId, string startTime, string studentId) =>
            _manager.UpdateBookedStudent(roomId, startTime, studentId);

        // DELETE api/values/5
        [HttpDelete()]
        [Route("DeleteSlot/{roomId}/{startTime}")]
        public int DeleteSlot(string roomId, string startTime) =>
            _manager.DeleteSlot(roomId, startTime);
    }
}
