using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using MMORPG_API;

namespace MMORPG_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PomocnikController : ControllerBase
    {
        [HttpGet(Name = "GetPomocnici")]
        public IEnumerable<PomocnikPregled> Get()
        {
            return DTOManager.vratiPomocnike().ToArray();
        }

        [HttpDelete(Name = "DeletePomocnik")]
        public ActionResult Delete(int id)
        {
            try
            {
                DTOManager.obrisiPomocnika(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(Name = "AddPomocnik")]
        public ActionResult Post(PomocnikBasic pom, string idigraca)
        {
            try
            {
                DTOManager.sacuvajPomocnika(pom, idigraca);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut(Name = "UpdatePomocnik")]
        public ActionResult Put(PomocnikBasic pomocnik, int id)
        {
            try
            {
                DTOManager.izmeniPomocnika(pomocnik, id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
