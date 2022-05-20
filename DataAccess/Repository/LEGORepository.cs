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
                ctx.LEGOSets.Add(LEGOSetMapper.Map(LEGOSet));
                ctx.SaveChanges();
            }
        }

        public static void UpdateLEGOSet(DTOLEGOSet LEGOSet)
        {
            using(LEGODBContext ctx = new LEGODBContext())
            {
                var LEGOSetToUpdate = ctx.LEGOSets.Find(LEGOSet.LEGOSetID);
                ctx.Entry(LEGOSetToUpdate).CurrentValues.SetValues(LEGOSet);
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

        public static DTOLEGOBrick GetLEGOBrick(int id)
        {
            using (LEGODBContext ctx =new LEGODBContext())
            {
                return LEGOBrickMapper.Map(ctx.LEGOBricks.Find(id));
            }
        }


    }
}
