using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using MMORPG_API;
using MMORPG_API.Entiteti;
using System.Threading.Tasks;

namespace MMORPG_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StazaController : ControllerBase
    {
        [HttpGet(Name ="GetStaze")]
        public IEnumerable<StazaPregled> Get()
        {
            return DTOManager.vratiStaze().ToArray();
        }

        [HttpDelete(Name = "DeleteStaza")]
        public ActionResult Delete(string naziv)
        {
            try
            {
                DTOManager.obrisiStazu(naziv);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(Name = "AddStaza")]
        public ActionResult Post(StazaBasic staza, string tipStaze, int brigr, int brUb, int igrId, string tim)
        {
            try
            {
                DTOManager.sacuvajStazu(staza, tipStaze, brigr, brUb, igrId, tim);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut(Name = "UpdateStaza")]
        public async Task<ActionResult> Put(StazaBasic staza, string naziv)
        {
            try
            {
                if (staza.Tip == "IGRAC")
                {
                    DTOManager.izmeniStazuZaIgraca((MMORPG_API.StazaZaIgracaBasic)staza, naziv);
                    return Ok();
                }
                else
                {
                    DTOManager.izmeniStazuZaTim((MMORPG_API.StazaZaTimBasic)staza, naziv);
                    return Ok();
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
