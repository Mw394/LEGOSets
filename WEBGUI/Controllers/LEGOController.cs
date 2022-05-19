using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTO.Model;
using BusinessLogic.BLL;

namespace WEBGUI.Controllers
{
    public class LEGOController : Controller
    {
        // GET: LEGO
        public ActionResult Index()
        {
            LEGOBLL legoBLL = new LEGOBLL();
            List<DTOLEGOSet> legoSets = legoBLL.GetLEGOSets();
            List<DTOLEGOBrick> legoBricks = legoBLL.GetLEGOBricks();
            ViewBag.LEGOBricks = legoBricks;
            ViewBag.LEGOSets = legoSets;
            return View("LEGOHome");
        }

        public ActionResult ShowLEGOBrickNewEdit(int id = 0)
        {
            var DTOLEGOBrick = new DTOLEGOBrick();
            ViewBag.Update = false;
            if (id != 0)
            {
                LEGOBLL legoBLL = new LEGOBLL();
                DTOLEGOBrick = legoBLL.GetLEGOBrick(id);
                ViewBag.Update = true;
            }

            return View("LEGOBrickNewEdit", DTOLEGOBrick);
        }

        [HttpPost]
        public ActionResult CreateLEGOBrick(DTOLEGOBrick LEGOBrick)
        {
            LEGOBLL LEGOBLL = new LEGOBLL();
            LEGOBLL.AddLEGOBrick(LEGOBrick);
            return Index();
        }

        [HttpPost]
        public ActionResult UpdateLEGOBrick(DTOLEGOBrick LEGOBrick)
        {
            LEGOBLL LEGOBLL = new LEGOBLL();
            LEGOBLL.UpdateLEGOBrick(LEGOBrick);
            return Index();
        }
    }
}