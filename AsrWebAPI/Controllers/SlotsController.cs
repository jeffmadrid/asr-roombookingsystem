﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Asr.Models;
using AsrWebAPI.Data.DataManager;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AsrWebAPI.Controllers
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
        public void Delete(int id)
        {
        }
    }
}