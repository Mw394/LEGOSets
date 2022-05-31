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
        public DTOLEGOSet GetLEGOSet(int id)
        {
            return LEGORepository.GetLEGOSet(id);
        }

        [HttpGet]
        public List<DTOLEGOSet> GetLEGOSets()
        {
            var LEGOSets = LEGORepository.GetLEGOSets();
            foreach (var item in LEGOSets) 
            {
                item.SetBrickLinks = LEGORepository.GetSetBrickLinks(item);
            }
            return LEGOSets;
        }


    }
}
