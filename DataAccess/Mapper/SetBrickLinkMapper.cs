using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Model;

namespace DataAccess.Mapper
{
    internal class SetBrickLinkMapper
    {

        public static DTO.Model.DTOSetBrickLink Map(SetBrickLink SetBrickLink)
        {
            return new DTO.Model.DTOSetBrickLink(LEGOBrickMapper.Map(SetBrickLink.LEGOBrick), LEGOSetMapper.Map(SetBrickLink.LEGOSet), SetBrickLink.Amount, SetBrickLink.SetBrickLinkID);
        }

        public static SetBrickLink Map(DTO.Model.DTOSetBrickLink SetBrickLink)
        {
            return new SetBrickLink(SetBrickLink.Amount);
        }

        public static List<SetBrickLink> Map(List<DTO.Model.DTOSetBrickLink> SetBrickLinks)
        {
            List<SetBrickLink> setBrickLinks = new List<SetBrickLink>();
            foreach (var link in SetBrickLinks)
            {
                setBrickLinks.Add(Map(link));
            }
            return setBrickLinks;
        }

        public static List<DTO.Model.DTOSetBrickLink> Map(List<SetBrickLink> SetBrickLinks)
        {
            List<DTO.Model.DTOSetBrickLink> setBrickLinks = new List<DTO.Model.DTOSetBrickLink>();
            foreach (var link in SetBrickLinks)
            {
                setBrickLinks.Add(Map(link));
            }
            return setBrickLinks;
        }
    }
}
