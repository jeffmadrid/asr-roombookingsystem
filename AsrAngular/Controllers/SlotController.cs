﻿using System;
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
        private SlotManager _slotManager;

        public SlotController(SlotManager slotManager)
        {
            _slotManager = slotManager;
        }

        // GET: api/values
        [HttpGet]
        public IEnumerable<Slot> Get() => _slotManager.GetAllSlots();

        // GET api/values/5
        [HttpGet("{id}")]
        public IEnumerable<Slot> Get(string id) =>
            _slotManager.GetSlotsOf(id);

        // POST api/values
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public int DeleteSlot(Slot slot) =>
            _slotManager.DeleteSlot(slot);
    }
}
