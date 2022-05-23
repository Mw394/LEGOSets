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
            if (!ModelState.IsValid)
            {
                return ShowLEGOBrickNewEdit();
            }
            LEGOBLL LEGOBLL = new LEGOBLL();
            LEGOBLL.AddLEGOBrick(LEGOBrick);
            return Index();
        }

        [HttpPost]
        public ActionResult UpdateLEGOBrick(DTOLEGOBrick LEGOBrick)
        {
            if (!ModelState.IsValid)
            {
                return ShowLEGOBrickNewEdit(LEGOBrick.LEGOBrickID);
            }
            LEGOBLL LEGOBLL = new LEGOBLL();
            LEGOBLL.UpdateLEGOBrick(LEGOBrick);
            return Index();
        }

        public ActionResult ShowLEGOSetNewEdit(int id = 0)
        {
            LEGOBLL LEGOBLL = new LEGOBLL();
            var DTOLEGOSet = new DTOLEGOSet();
            DTOLEGOSet.SetBrickLinks = new List<DTOSetBrickLink>();
            var bricks = LEGOBLL.GetLEGOBricks();
            ViewBag.Bricks = bricks;
            ViewBag.Update = false;
            List<SelectListItem> selectableItems = new List<SelectListItem>();
            if (id != 0) { 
            
                DTOLEGOSet = LEGOBLL.GetLEGOSet(id);
                List<DTOSetBrickLink> links = LEGOBLL.GetSetBrickLinks(DTOLEGOSet);
                DTOLEGOSet.SetBrickLinks = links;
                foreach (var link in links)
                {
                    selectableItems.Add(new SelectListItem { Text = link.BrickInfo, Value = link.SetBrickLinkID.ToString() });
                }
                ViewBag.Update = true;
            }
            return View("LEGOSetNewEdit", DTOLEGOSet);
        }

        [HttpPost]
        public ActionResult CreateLEGOSet(DTOLEGOSet LEGOSet)
        {
            if (!ModelState.IsValid)
            {
                return ShowLEGOSetNewEdit();
            }
            LEGOBLL LEGOBLL = new LEGOBLL();
            LEGOBLL.AddLEGOSet(LEGOSet);
            return Index();
        }

        public ActionResult UpdateLEGOSet(DTOLEGOSet LEGOSet)
        {
            if (!ModelState.IsValid)
            {
                return ShowLEGOSetNewEdit(LEGOSet.LEGOSetID);
            }
            LEGOBLL LEGOBLL = new LEGOBLL();
            LEGOBLL.UpdateLEGOSet(LEGOSet);
            return Index();
        }


        public ActionResult ModalPopUp(int id = 0)
        {
            LEGOBLL LEGOBLL = new LEGOBLL();
            var DTOLEGOSet = new DTOLEGOSet();
            DTOLEGOSet.SetBrickLinks = new List<DTOSetBrickLink>();
            var bricks = LEGOBLL.GetLEGOBricks();
            ViewBag.Bricks = bricks;
            ViewBag.Update = false;
            List<SelectListItem> selectableItems = new List<SelectListItem>();
            if (id != 0)
            {

                DTOLEGOSet = LEGOBLL.GetLEGOSet(id);
                List<DTOSetBrickLink> links = LEGOBLL.GetSetBrickLinks(DTOLEGOSet);
                DTOLEGOSet.SetBrickLinks = links;
                foreach (var link in links)
                {
                    selectableItems.Add(new SelectListItem { Text = link.BrickInfo, Value = link.SetBrickLinkID.ToString() });
                }
                ViewBag.Update = true;
            }
            return View("ModalPopUp", DTOLEGOSet);
        }

        public ActionResult ShowSetBrickLinkNewEdit(int id = 0, DTOLEGOSet DTOLEGOSet = null)
        {
            var DTOSetBrickLink = new DTOSetBrickLink();
            DTOSetBrickLink.DTOLEGOSet = DTOLEGOSet;
            return PartialView("ModalPopUp", DTOSetBrickLink);
        }

        public ActionResult BrickTest()
        {
            LEGOBLL legoBLL = new LEGOBLL();
            List<DTOLEGOBrick> legoBricks = legoBLL.GetLEGOBricks();
            ViewBag.LEGOBricks = legoBricks;
            return View("BrickTest", legoBricks);
        }

        public ActionResult BrickCreate()
        {
            return PartialView("View1");
        }

    }
}