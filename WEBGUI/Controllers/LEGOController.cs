using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DTO.Model;
using BusinessLogic.BLL;
using Newtonsoft.Json;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace WEBGUI.Controllers
{
    public class LEGOController : Controller
    {


        // GET: LEGO
        public ActionResult Index()
        {
            this.Session.Clear();
            return View("LEGOHome");
        }

        private List<DTOLEGOBrick> GetLEGOBricks()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44372/api/LEGO/legobricks");
                client.DefaultRequestHeaders.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string response = client.GetStringAsync("https://localhost:44372/api/LEGO/legobricks").Result;
                List<DTOLEGOBrick> legoBricks = JsonConvert.DeserializeObject<List<DTOLEGOBrick>>(response);
                return legoBricks;
            }
        }

        private List<DTOLEGOSet> GetLEGOSets()
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:44372/api/LEGO/legosets");
                client.DefaultRequestHeaders.Clear();
                //client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                string response = client.GetStringAsync(client.BaseAddress).Result;
                List<DTOLEGOSet> legoSets = JsonConvert.DeserializeObject<List<DTOLEGOSet>>(response);
                return legoSets;
            }
        }



        public ActionResult ShowLEGOBricksList()
        {
            List<DTOLEGOBrick> legoBricks = GetLEGOBricks();
            this.Session.Clear();
            return View("LEGOBrick/ShowLEGOBricksList", legoBricks);
        }

        public ActionResult ShowLEGOSetsList()
        {
            List<DTOLEGOSet> legoSets = GetLEGOSets();
            this.Session.Clear();
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

        public ActionResult DeleteLEGOBrick(int id)
        {
            var bll = new LEGOBLL();
            bll.DeleteLEGOBrick(id);
            return ShowLEGOBricksList();
        }

        public ActionResult ShowLEGOSetCreate()
        {
            var newSet = this.Session["LEGOSet"] ?? new DTOLEGOSet();
            this.HttpContext.Session["LEGOSet"] = newSet;
            this.HttpContext.Session["NEW"] = true;
            ViewBag.DetailSite = false;
            return View("LEGOSet/LEGOSetCreate", newSet);
        }

        [HttpPost]
        public ActionResult CreateLEGOSet(string submit, DTOLEGOSet LEGOSet)
        {
            var links = (List<DTOSetBrickLink>)this.HttpContext.Session["links"];
            LEGOBLL LEGOBLL = new LEGOBLL();
            if (submit == "Add Brick")
            {
                ViewBag.LEGOBricks = LEGOBLL.GetLEGOBricks();
                ViewBag.NEW = this.Session["NEW"];
                ViewBag.LEGOSet = LEGOSet;
                this.Session["LEGOSet"] = LEGOSet;
                var newLink = new DTOSetBrickLink
                {
                    NewObject = true
                };
                return View("LEGOSetBrickLink/SetBrickLinkCreate", newLink);
            }
            if (!ModelState.IsValid)
            {
                return ShowLEGOSetCreate();
            }
            LEGOSet.SetBrickLinks = links;
            LEGOBLL.AddLEGOSet(LEGOSet);
            this.Session.Clear();
            return ShowLEGOSetsList();
        }

        [HttpPost]
        public ActionResult UpdateLEGOSet(string submit, DTOLEGOSet LEGOSet)
        {
            LEGOBLL LEGOBLL = new LEGOBLL();
            if (submit == "Add Brick")
            {
                ViewBag.LEGOBricks = LEGOBLL.GetLEGOBricks();
                ViewBag.LEGOSet = LEGOSet.LEGOSetID;
                ViewBag.NEW = this.Session["NEW"];
                this.Session["LEGOSet"] = LEGOSet;
                var newLink = new DTOSetBrickLink
                {
                    NewObject = true
                };
                return View("LEGOSetBrickLink/SetBrickLinkCreate",newLink);
            }
            if (!ModelState.IsValid)
            {
                return ShowLEGOSetEdit(LEGOSet.LEGOSetID);
            }
            var links = (List<DTOSetBrickLink>)this.HttpContext.Session["links"];
            var linksToRemove = (List<DTOSetBrickLink>)this.HttpContext.Session["linksToRemove"] ?? new List<DTOSetBrickLink>();
            LEGOSet.SetBrickLinks = links ?? new List<DTOSetBrickLink>();
            LEGOBLL.UpdateLEGOSet(LEGOSet, linksToRemove);
            this.Session.Clear();
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
            var links = (List<DTOSetBrickLink>)this.Session["links"] ?? bll.GetSetBrickLinks(set);
            set.SetBrickLinks = links;
            this.HttpContext.Session["LEGOSet"] = set;
            this.HttpContext.Session["NEW"] = false;
            this.HttpContext.Session["links"] = links;
            return View("LEGOset/LEGOSetEdit", set);
        }

        [HttpPost]
        public ActionResult SetBrickLinkCreate(DTOSetBrickLink setBrickLink)
        {
            var newLinks = (List<DTOSetBrickLink>)this.HttpContext.Session["links"] ?? new List<DTOSetBrickLink>();
            var set = (DTOLEGOSet)this.HttpContext.Session["LEGOSet"];
            LEGOBLL bll = new LEGOBLL();
            setBrickLink.LEGOBrick = bll.GetLEGOBrick(setBrickLink.LEGOBrickID);
            setBrickLink.DTOLEGOSet = set;
            if (setBrickLink.NewObject)
            {
                setBrickLink.SetBrickLinkID = newLinks.Count+1;
            }
            newLinks.Add(setBrickLink);
            set.SetBrickLinks.AddRange(newLinks);
            this.HttpContext.Session["links"] = newLinks;
            ViewBag.DetailSite = false;
            ViewBag.LEGOset = set.LEGOSetID;
            if ((bool)this.Session["NEW"])
            {
                return View("LEGOSet/LEGOSetCreate", set);
            }
            return View("LEGOSet/LEGOSetEdit", set);
        }

        public ActionResult ShowSetBrickLinkEdit(int id)
        {
            LEGOBLL bll = new LEGOBLL();
            var sessionLinks = (List<DTOSetBrickLink>)this.HttpContext.Session["links"];
            var link = sessionLinks.Where(item => item.SetBrickLinkID == id).FirstOrDefault();
            var set = (DTOLEGOSet)this.HttpContext.Session["LEGOSet"];
            ViewBag.LEGOBricks = bll.GetLEGOBricks();
            ViewBag.New = (bool)this.HttpContext.Session["NEW"];
            ViewBag.LEGOSet = set.LEGOSetID;
            return View("LEGOSetBrickLink/SetBrickLinkEdit", link);
        }

        public ActionResult UpdateSetBrickLink(DTOSetBrickLink SetBrickLink)
        {
            LEGOBLL bll = new LEGOBLL();
            var set = (DTOLEGOSet)this.HttpContext.Session["LEGOSet"];
            SetBrickLink.DTOLEGOSet = set;
            SetBrickLink.LEGOBrick = bll.GetLEGOBrick(SetBrickLink.LEGOBrickID);
            var linkToRemove = set.SetBrickLinks.Where(item => item.SetBrickLinkID == SetBrickLink.SetBrickLinkID).First();
            set.SetBrickLinks.Remove(linkToRemove);
            set.SetBrickLinks.Add(SetBrickLink);
            this.HttpContext.Session["links"] = set.SetBrickLinks;
            ViewBag.New = (bool)this.HttpContext.Session["NEW"];
            ViewBag.DetailSite = false;
            if ((bool)this.HttpContext.Session["NEW"])
            {
                return View("LEGOSet/LEGOSetCreate", set);
            }
            return View("LEGOSet/LEGOSetEdit", set);
        }

        public ActionResult DeleteSetBrickLink(int id)
        {
            var set = (DTOLEGOSet)this.HttpContext.Session["LEGOSet"];
            var linkToRemove = set.SetBrickLinks.Where(item => item.SetBrickLinkID == id).First();
            set.SetBrickLinks.Remove(linkToRemove);
            UpdateLinksSessionVariable(linkToRemove);
            var NEW = (bool)this.HttpContext.Session["NEW"];
            if (NEW)
            {
                return View("LEGOSet/LEGOSetCreate", set);
            }
            return View("LEGOSet/LEGOSetEdit", set);
        }

        public void UpdateLinksSessionVariable(DTOSetBrickLink toRemove)
        {
            var linksToRemove = (List<DTOSetBrickLink>)this.Session["linksToRemove"] ?? new List<DTOSetBrickLink>();
            var links = (List<DTOSetBrickLink>)this.HttpContext.Session["links"];
            links.Remove(toRemove);
            linksToRemove.Add(toRemove);
            this.Session["linksToRemove"] = linksToRemove;
        }
    }
}