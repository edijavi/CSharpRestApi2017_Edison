﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using VideoAppBLL.BusinessObjects;

namespace VideoRestAPI.Controllers
{
    [Route("api/[controller]")]
    public class ValuesController : Controller
    {
        // GET api/values
        // R in CRUD
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        // R in CRUD
        [HttpGet("{id}")]
        public string Get(string id)
        {
            return "value -->" + id ;
        }

        // POST api/values
        // C in CRUD

        // BO comes from JSON using Modelbinding
        [HttpPost]
        public void Post([FromBody]VideoBO vid)
        {
        }

        // PUT api/values/5
        // Update in CRUD
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        // Delete in CRUD
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
