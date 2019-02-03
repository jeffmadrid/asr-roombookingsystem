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

        [HttpGet]
        [Route("Index")]
        public IEnumerable<Slot> Get() => _manager.GetAllSlots();

        [HttpGet()]
        [Route("{roomId}/{startTime}")]
        public Slot Get(string roomId, string startTime) =>
            _manager.GetStudentId(roomId, startTime);

        //https://sookocheff.com/post/api/when-to-use-http-put-and-http-post/
        // so i guess create == Post; edit == Put

        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        [HttpPut()]
        [Route("Edit")]
        public void Edit([FromBody] Slot slot) =>
            _manager.UpdateBookedStudent(slot);

        [HttpDelete()]
        [Route("DeleteSlot/{roomId}/{startTime}")]
        public int DeleteSlot(string roomId, string startTime) =>
            _manager.DeleteSlot(roomId, startTime);
    }
}
