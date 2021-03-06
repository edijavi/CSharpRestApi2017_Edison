﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VideoAppBLL;
using VideoAppBLL.BusinessObjects;

namespace VideoRestAPI.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    public class VideosController : Controller
    {
        BLLFacade facade = new BLLFacade();

        // GET: api/Videos
        [HttpGet]
        public IEnumerable<VideoBO> Get()
        {
            return facade.VideoService.GetAll();
        }

        // GET: api/Videos/5
        [HttpGet("{id}", Name = "Get")]
        public VideoBO Get(int id)
        {
            return facade.VideoService.Get(id);
        }
        
        // POST: api/Videos
        [HttpPost]
        public IActionResult Post([FromBody]VideoBO vid)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }        

            return Ok(facade.VideoService.Create(vid));
        }
        
        // PUT: api/Videos/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]VideoBO vid)
        {
            if (id != vid.Id)
            {
                return BadRequest("Path Id does not match Video ID in Json object");
            }

            try
            {
                var video = facade.VideoService.Update(vid);
                return Ok(video);
            }
            catch (InvalidOperationException e)
            {
                return StatusCode(404, e.Message);
            }
        }
        
        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            facade.VideoService.Delete(id);
        }
    }
}
