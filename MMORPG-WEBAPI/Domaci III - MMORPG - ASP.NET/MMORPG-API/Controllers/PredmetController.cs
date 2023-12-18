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
    public class PredmetController : ControllerBase
    {
        [HttpGet(Name = "GetPredmeti")]
        public IEnumerable<PredmetPregled> Get()
        {
            return DTOManager.vratiPredmete().ToArray();
        }

        [HttpDelete(Name = "DeletePredmet")]
        public ActionResult Delete(string naziv)
        {
            try
            {
                DTOManager.obrisiPredmet(naziv);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(Name = "AddPredmet")]
        public ActionResult Post(PredmetBasic pr, string tipPredmeta, string nadimci, int bonisk, string rase, string staza)
        {
            try
            {
                DTOManager.sacuvajPredmet(pr, tipPredmeta, nadimci, bonisk, rase, staza);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut(Name = "UpdatePredmet")]
        public async Task<ActionResult> Put(PredmetBasic predmet, string naziv)
        {
            try
            {
                if (predmet.Tip == "KLJUCNI")
                {
                    DTOManager.izmeniKljucniPredmet((MMORPG_API.KljucniPredmetBasic)predmet, naziv);
                    return Ok();
                }
                else
                {
                    DTOManager.izmeniPredmetXP((MMORPG_API.PredmetXPBasic)predmet, naziv);
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
