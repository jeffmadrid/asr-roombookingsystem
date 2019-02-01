using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asr.Models;
using AsrAngular.Data.DataManager;
using Microsoft.AspNetCore.Mvc;
using Asr.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AsrAngular.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SlotsController : Controller
    {
        private SlotManager _slotManager;

        public SlotsController(SlotManager slotManager)
        {
            _slotManager = slotManager;
        }

        // GET: api/values
        [HttpGet]
        //[Route("Index")]
        public IEnumerable<Slot> Get() => _slotManager.GetAllSlots();

        // GET api/values/5
        [HttpGet("{id}")]
        //[Route("GetBookedSlot")]
        public IEnumerable<Slot> Get(string id) =>
            _slotManager.GetSlotsOf(id);


        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        //[Route("UpdateStudent")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        //[Route("DeleteSlot")]
        public void Delete(int id)
        {
        }
    }
}
