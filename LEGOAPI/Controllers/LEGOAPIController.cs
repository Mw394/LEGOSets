using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using DataAccess.Repository;
using DTO.Model;

namespace LEGOAPI.Controllers
{
    public class LEGOAPIController : ApiController
    {

        [HttpGet]
        [Route("api/LEGO/legosets/{id}")]
        public DTOLEGOSet GetLEGOSet(int id)
        {
            var legoSet = LEGORepository.GetLEGOSet(id);
            legoSet.SetBrickLinks = LEGORepository.GetSetBrickLinks(legoSet);
            return legoSet;
        }

        [HttpGet]
        [Route("api/LEGO/legosets")]
        public List<DTOLEGOSet> GetLEGOSets()
        {
            var LEGOSets = LEGORepository.GetLEGOSets();
            foreach (var item in LEGOSets) 
            {
                item.SetBrickLinks = LEGORepository.GetSetBrickLinks(item);
            }
            return LEGOSets;
        }

        [HttpPost]
        [Route("api/LEGO/legosets")]
        public HttpResponseMessage LEGOSetCreate([FromBody] DTOLEGOSet legoSet)
        {
            if (ModelState.IsValid)
            {
                LEGORepository.AddLEGOSet(legoSet);
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }


        [HttpGet]
        [Route("api/LEGO/legobricks")]
        public List<DTOLEGOBrick> GetLEGOBricks()
        {
            return LEGORepository.GetLEGOBricks();
        }

        [HttpGet]
        [Route("api/LEGO/legobricks/{id}")]
        public DTOLEGOBrick GetLEGOBricks(int id)
        {
            return LEGORepository.GetLEGOBrick(id);
        }

        [HttpPost]
        [Route("api/LEGO/legobricks")]
        public HttpResponseMessage LEGOBrickCreate([FromBody] DTOLEGOBrick legoBrick)
        {
            if (ModelState.IsValid)
            {
                LEGORepository.AddLEGOBrick(legoBrick);
                return new HttpResponseMessage(HttpStatusCode.Created);
            }
            return new HttpResponseMessage(HttpStatusCode.BadRequest);
        }


    }
}
