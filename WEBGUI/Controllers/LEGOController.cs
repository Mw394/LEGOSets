﻿using System;
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
            return View("LEGOHome");
        }

        public ActionResult ShowLEGOBricksList()
        {
            LEGOBLL legoBLL = new LEGOBLL();
            List<DTOLEGOBrick> legoBricks = legoBLL.GetLEGOBricks();
            return View("LEGOBrick/ShowLEGOBricksList", legoBricks);
        }

        public ActionResult ShowLEGOSetsList()
        {
            LEGOBLL legoBLL = new LEGOBLL();
            List<DTOLEGOSet> legoSets = legoBLL.GetLEGOSets();
            return View("LEGOSet/ShowLEGOSetsList", legoSets);
        }

        public ActionResult ShowLEGOBrickCreate()
        {
            DTOLEGOBrick newBrick = new DTOLEGOBrick();
            return View("LEGOBrick/LEGOBrickCreate", newBrick);
        }

        [HttpPost]
        public ActionResult CreateLEGOBrick(DTOLEGOBrick LEGOBrick)
        {
            if (!ModelState.IsValid)
            {
                return ShowLEGOBrickCreate();
            }
            LEGOBLL LEGOBLL = new LEGOBLL();
            LEGOBLL.AddLEGOBrick(LEGOBrick);
            return ShowLEGOBricksList();
        }

        public ActionResult ShowLEGOBrickEdit(int id) 
        {
            LEGOBLL bll = new LEGOBLL();
            var brick = bll.GetLEGOBrick(id);
            return View("LEGOBrick/LEGOBrickEdit", brick);
        }

        [HttpPost]
        public ActionResult UpdateLEGOBrick(DTOLEGOBrick LEGOBrick)
        {
            if (!ModelState.IsValid)
            {
                return ShowLEGOBrickEdit(LEGOBrick.LEGOBrickID);
            }
            LEGOBLL bll = new LEGOBLL();
            bll.UpdateLEGOBrick(LEGOBrick);
            return ShowLEGOBricksList();
        }

        public ActionResult ShowLEGOBrickDetails(int id)
        {
            LEGOBLL bll = new LEGOBLL();
            var brick = bll.GetLEGOBrick(id);
            return View("LEGOBrick/LEGOBrickDetails", brick);
        }

        public ActionResult DeleteLEGOBrick(int id)
        {
            var bll = new LEGOBLL();
            bll.DeleteLEGOBrick(id);
            return ShowLEGOBricksList();
        }

        public ActionResult ShowLEGOSetCreate()
        {
            DTOLEGOSet newSet = new DTOLEGOSet();
            return View("LEGOSet/LEGOSetCreate", newSet);
        }

        [HttpPost]
        public ActionResult CreateLEGOSet(DTOLEGOSet LEGOSet)
        {
            if (!ModelState.IsValid)
            {
                return ShowLEGOSetCreate();
            }
            LEGOBLL LEGOBLL = new LEGOBLL();
            LEGOBLL.AddLEGOSet(LEGOSet);
            return ShowLEGOSetsList();
        }

        [HttpPost]
        public ActionResult UpdateLEGOSet(DTOLEGOSet LEGOSet)
        {
            if (!ModelState.IsValid)
            {
                return ShowLEGOSetEdit(LEGOSet.LEGOSetID);
            }
            LEGOBLL LEGOBLL = new LEGOBLL();
            LEGOBLL.UpdateLEGOSet(LEGOSet);
            return ShowLEGOSetsList();
        }

        public ActionResult DeleteLEGOSet(int id)
        {
            LEGOBLL LEGOBLL = new LEGOBLL();
            LEGOBLL.DeleteLEGOSet(id);
            return ShowLEGOSetsList();
        }

        public ActionResult ShowLEGOSetEdit(int id)
        {
            LEGOBLL bll = new LEGOBLL();
            var set = bll.GetLEGOSet(id);
            var links = bll.GetSetBrickLinks(set);
            set.SetBrickLinks = links;
            this.HttpContext.Session["LEGOSet"] = set;
            return View("LEGOset/LEGOSetEdit", set);
        }

        public ActionResult ShowLEGOSetDetails(int id)
        {
            LEGOBLL bll = new LEGOBLL();
            var set = bll.GetLEGOSet(id);
            return View("LEGOSet/LEGOSetDetails", set);
        }

        public ActionResult ShowSetBrickLinkCreate()
        {
            DTOSetBrickLink newLink = new DTOSetBrickLink();
            var set = (DTOLEGOSet)this.HttpContext.Session["LEGOSet"];
            newLink.LEGOSetID = set.LEGOSetID;
            newLink.DTOLEGOSet = set;
            LEGOBLL bll = new LEGOBLL();
            ViewBag.LEGOBricks = bll.GetLEGOBricks();
            ViewBag.LEGOSet = set.LEGOSetID;
            return View("LEGOSetBrickLink/SetBrickLinkCreate", newLink);
        }

        [HttpPost]
        public ActionResult SetBrickLinkCreate(DTOSetBrickLink setBrickLink)
        {
            var set = (DTOLEGOSet)this.HttpContext.Session["LEGOSet"];
            LEGOBLL bll = new LEGOBLL();
            setBrickLink.LEGOBrick = bll.GetLEGOBrick(setBrickLink.LEGOBrickID);
            set.SetBrickLinks.Add(setBrickLink);
            return View("LEGOSet/LEGOSetEdit", set);
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


    }
}