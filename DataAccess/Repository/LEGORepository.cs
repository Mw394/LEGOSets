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

        public static List<DTOLEGOSet> GetLEGOSets()
        {
            using(LEGODBContext ctx = new LEGODBContext())
            {
                return LEGOSetMapper.Map(ctx.LEGOSets.ToList<LEGOSet>());
            }
        }


    }
}
