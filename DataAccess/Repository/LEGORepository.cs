using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;
using DataAccess.DBContext;
using DataAccess.Mapper;
using DTO.Model;

namespace DataAccess.Repository
{
    public class LEGORepository
    {

        public static DTOLEGOSet GetLEGOSet(int id)
        {
            using (LEGODBContext context = new LEGODBContext())
            {
                return LEGOSetMapper.Map(context.LEGOSets.Find(id));
            }
        }

        public static void AddLEGOSet(DTOLEGOSet LEGOSet)
        {
            using (LEGODBContext ctx = new LEGODBContext())
            {
                var newSet = ctx.LEGOSets.Add(LEGOSetMapper.Map(LEGOSet));
                AddSetBrickLinks(LEGOSet.SetBrickLinks, newSet, ctx);
                ctx.SaveChanges();
            }
        }

        public static void UpdateLEGOSet(DTOLEGOSet LEGOSet, List<DTOSetBrickLink> toRemove)
        {
            using(LEGODBContext ctx = new LEGODBContext())
            {
                var LEGOSetToUpdate = ctx.LEGOSets.Find(LEGOSet.LEGOSetID);
                UpdateSetBrickLinks(LEGOSet.SetBrickLinks, ctx, LEGOSetToUpdate);
                ctx.Entry(LEGOSetToUpdate).CurrentValues.SetValues(LEGOSet);
                DeleteListOfSetBrickLinks(toRemove);
                ctx.SaveChanges();
            }
        }

        public static void DeleteLEGOSet(int id)
        {
            using (LEGODBContext ctx = new LEGODBContext())
            {
                var LEGOSetToDelete = ctx.LEGOSets.Find(id);
                DeleteSetBrickLinks(LEGOSetMapper.Map(LEGOSetToDelete));
                ctx.LEGOSets.Remove(LEGOSetToDelete);
                ctx.SaveChanges();
            }
        }

        public static List<DTOLEGOSet> GetLEGOSets()
        {
            using(LEGODBContext ctx = new LEGODBContext())
            {
                return LEGOSetMapper.Map(ctx.LEGOSets.ToList<LEGOSet>());
            }
        }

        public static List<DTOLEGOBrick> GetLEGOBricks()
        {
            using(LEGODBContext ctx = new LEGODBContext())
            {
                return LEGOBrickMapper.Map(ctx.LEGOBricks.ToList<LEGOBrick>());
            }

        }

        public static void AddLEGOBrick(DTOLEGOBrick LEGOBrick)
        {
            using(LEGODBContext ctx = new LEGODBContext())
            {
                ctx.LEGOBricks.Add(LEGOBrickMapper.Map(LEGOBrick));
                ctx.SaveChanges();
            }
        }

        public static void UpdateLEGOBrick(DTOLEGOBrick LEGOBrick)
        {
            using(LEGODBContext ctx = new LEGODBContext())
            {
                var LEGOBricktoUpdate = ctx.LEGOBricks.Find(LEGOBrick.LEGOBrickID);
                ctx.Entry(LEGOBricktoUpdate).CurrentValues.SetValues(LEGOBrick);
                ctx.SaveChanges();
            }
        }

        public static void DeleteLEGOBrick(int id)
        {
            using (LEGODBContext ctx = new LEGODBContext())
            {
                var brick = ctx.LEGOBricks.Find(id);
                ctx.LEGOBricks.Remove(brick);
                ctx.SaveChanges();
            }
        }

        public static DTOLEGOBrick GetLEGOBrick(int id)
        {
            using (LEGODBContext ctx =new LEGODBContext())
            {
                return LEGOBrickMapper.Map(ctx.LEGOBricks.Find(id));
            }
        }

        public static List<DTOSetBrickLink> GetSetBrickLinks(DTOLEGOSet DTOLEGOSet) 
        {
            using (LEGODBContext ctx = new LEGODBContext())
            {
                return SetBrickLinkMapper.Map(ctx.SetBrickLinks.Where(x => x.LEGOSet.LEGOSetID == DTOLEGOSet.LEGOSetID).ToList());
            }
        }

        public static void DeleteSetBrickLinks(DTOLEGOSet DTOLEGOSet)
        {
            using (LEGODBContext ctx = new LEGODBContext())
            {
                var links = ctx.SetBrickLinks.Where(link => link.LEGOSet.LEGOSetID == DTOLEGOSet.LEGOSetID);
                ctx.SetBrickLinks.RemoveRange(links);
                ctx.SaveChanges();
            }
        }

        public static DTOSetBrickLink GetSetBrickLink(int id)
        {
            using (LEGODBContext ctx = new LEGODBContext())
            {
                return SetBrickLinkMapper.Map(ctx.SetBrickLinks.Find(id));
            }
        }

        public static void UpdateSetBrickLinks(List<DTOSetBrickLink> links, LEGODBContext ctx, LEGOSet originalSet)
        {
            foreach (DTOSetBrickLink link in links)
            {
                if (link.NewObject)
                {
                    var newLink = SetBrickLinkMapper.Map(link);
                    newLink.LEGOSet = originalSet;
                    newLink.LEGOBrick = ctx.LEGOBricks.Find(link.LEGOBrickID);
                    ctx.SetBrickLinks.Add(newLink);
                }
                else
                {
                    var linkToUpdate = ctx.SetBrickLinks.Find(link.SetBrickLinkID);
                    if (linkToUpdate != null)
                    {
                        ctx.Entry(linkToUpdate).CurrentValues.SetValues(link);
                    }
                }
            }
        }

        public static void DeleteListOfSetBrickLinks(List<DTOSetBrickLink> toRemove)
        {
            using (LEGODBContext ctx = new LEGODBContext())
            {
                toRemove.ForEach(item =>
                {
                    var link = ctx.SetBrickLinks.Find(item.SetBrickLinkID);
                    if (link != null)
                    {
                        ctx.SetBrickLinks.Remove(link);
                    }
                });
                ctx.SaveChanges();
            }
        }

        public static void AddSetBrickLinks(List<DTOSetBrickLink> linksToAdd, LEGOSet newSet, LEGODBContext ctx)
        {
            foreach (var item in linksToAdd)
            {
                var brick = ctx.LEGOBricks.Find(item.LEGOBrickID);
                var newLink = SetBrickLinkMapper.Map(item);
                newLink.LEGOSet = newSet;
                newLink.LEGOBrick = brick;
                ctx.SetBrickLinks.Add(newLink);
            }
        }

    }
}
