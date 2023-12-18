using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using MMORPG_API;
using System.Threading.Tasks;
using MMORPG_API.Entiteti;

namespace MMORPG_API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LikController : ControllerBase
    {
        [HttpGet(Name ="VratiLikove")]
        public IEnumerable<LikPregled> Get()
        {
            return DTOManager.vratiLikove().ToArray();
        }

        [HttpDelete(Name = "DeleteLik")]
        public ActionResult Delete(int id)
        {
            try
            {
                DTOManager.obrisiLika(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost(Name = "AddLik")]
        public ActionResult Post(LikBasic lik, string klasaLika, string rasaLika, int igracID, int zamke, int buka, string religija,
            string blagoslov, char lecenje, char luksamostrel, int oklop, char oberuke, char stit, string magije)
        {
            try
            {
                DTOManager.sacuvajLika(lik, klasaLika, rasaLika, igracID, zamke, buka, religija, blagoslov, lecenje, luksamostrel, oklop, oberuke, stit, magije);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.ToString());
            }
        }
        [HttpPut(Name = "UpdateLik")]
        public async Task<ActionResult> Put(LikBasic lik, int id)
        {
            try
            {
                if (lik.Klasa == "LOPOV")
                {
                    DTOManager.izmeniLopova((MMORPG_API.LopovBasic)lik, id);
                    return Ok();
                }
                else if (lik.Klasa == "SVESTENIK")
                {
                    DTOManager.izmeniSvestenika((MMORPG_API.SvestenikBasic)lik, id);
                    return Ok();
                }
                else if (lik.Klasa == "STRELAC")
                {
                    DTOManager.izmeniStrelca((MMORPG_API.StrelacBasic)lik, id);
                    return Ok();
                }
                else if (lik.Klasa == "OKLOPNIK")
                {
                    DTOManager.izmeniOklopnika((MMORPG_API.OklopnikBasic)lik, id);
                    return Ok();
                }
                else if (lik.Klasa == "BORAC")
                {
                    DTOManager.izmeniBorca((MMORPG_API.BoracBasic)lik, id);
                    return Ok();
                }
                else if (lik.Klasa == "CAROBNJAK")
                {
                    DTOManager.izmeniCarobnjaka((MMORPG_API.CarobnjakBasic)lik, id);
                    return Ok();
                }
                else
                {
                    return BadRequest();
                }     
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
