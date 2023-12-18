using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using MMORPG_API;

namespace MMORPG_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TimController : ControllerBase
    {
        [HttpGet(Name = "GetTimovi")]
        public IEnumerable<TimPregled> Get()
        {
            return DTOManager.vratiTimove().ToArray();
        }

        [HttpDelete(Name = "DeleteTim")]
        public ActionResult Delete(string naziv)
        {
            try
            {
                DTOManager.obrisiTim(naziv);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(Name = "AddTim")]
        public ActionResult Post(TimBasic tim)
        {
            try
            {
                DTOManager.sacuvajTim(tim);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut(Name = "UpdateTim")]
        public ActionResult Put(TimBasic tim, string naziv)
        {
            try
            {
                DTOManager.izmeniTim(tim, naziv);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}